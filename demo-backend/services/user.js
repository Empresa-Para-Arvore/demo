let userBase = require('../model/user')
let tagBase = require('../model/tag')

let users = {}

users.login = (email, password) => {
    return userBase.findOne({
        email: email,
        password: password,
    })
}

const addBranchByTag = async (tree, tagDesc) => {
    let createBranch = (branch, item)  => {
        branch.branches[item] = {
            description: item,
            branches: {},
            leafs: [],
        }
        return branch.branches[item]
    }

    let addTag = (selectedTag)  => {
        if(!selectedTag) {
            return;
        }

        path = selectedTag.path.split('->')
        currentBranch = tree
        
        for(item of path) {
            currentBranch = currentBranch.branches[item.trim()] || createBranch(currentBranch, item.trim())    
        }
    }
    
    addTag(await tagBase.findOne({description: tagDesc}))
}

const addLeafByActivity = async (tree, activity) => {
    let createBranch = (branch, item)  => {
        branch.branches[item] = {
            description: item,
            branches: {},
            leafs: [],
        }
        return branch.branches[item]
    }

    let addTag = (selectedTag)  => {
        if(!selectedTag) {
            return;
        }

        path = selectedTag.path.split('->')
        currentBranch = tree
        
        if(!currentBranch.branches) {
            currentBranch.branches = {}
        }
        
        for(item of path) {
            currentBranch = currentBranch.branches[item.trim()] || createBranch(currentBranch, item.trim())    
        }

        return currentBranch
    }
    
    for(tag of activity.tags) {
        let branch = addTag(await tagBase.findOne({description: tag}))
        if(!branch) continue
        
        leaf = { score: activity.score / 10, }
        branch.leafs.push(leaf)
    }
}

users.createUser = async (name, email, password, age, jobs, additionalBranches, activity) => {
    let userTree = {
        description: '',
        height: age * 10,
        width: jobs.map(job => job.time).reduce((val, acc) => val + acc, 0),
        branches: {},
        roots: jobs.map(job => ({
            description: job.company,
            height: Math.min(job.time * 5, 200),
            width: job.description.split(' ').length, 
        })),
    }

    for(let val of additionalBranches) { await addBranchByTag(userTree, val) }
    for(let a of activity) { await addLeafByActivity(userTree, a) }
    
    return userBase.create({
        name: name,
        email: email,
        password: password,
        age: age,
        jobs: jobs,
        items: activity,
        tree: userTree,
    })
}

users.createItem = async (userId, item) => {
    userBase
    .findById(userId)
    .then(async (user) =>  {
        user.items.push(item)
        await addLeafByActivity(user.tree, item)

        return userBase.updateOne({ _id: userId }, {$set: user}).then(console.log)
    })
}

users.createJob = async (userId, job) => {
    userBase
    .findById(userId)
    .then(async (user) =>  {
        user.jobs.push(job)
        user.tree.width = user.jobs.map(job => job.time).reduce((val, acc) => val + acc, 0)
        user.tree.roots.push({
            description: job.company,
            height: Math.min(job.time * 5, 200),
            width: job.description.split(' ').length, 
        })

        return userBase.updateOne({ _id: userId }, {$set: user}).then(console.log)
    })
}

module.exports = users