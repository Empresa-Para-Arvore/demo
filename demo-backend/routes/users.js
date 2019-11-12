var express = require('express');
var router = express.Router();
let userBase = require('../model/user')
let userService = require('../services/user')

/* GET users listing. */
router.get('/', function(req, res, next) {
    userBase.find()
    .then(result => res.status(200).send(result))
    .catch(err => res.status(500).send(err))
});

router.post('/', function(req, res, next) {
    return userService.createUser(
        req.body['name'],
        req.body['email'],
        req.body['password'],
        req.body['age'],
        req.body['jobs'],
        req.body['additionalBranches'],
        req.body['activity'],
    )
    .then(result => res.status(201).json(result))
    .catch(err => res.status(500).json(err))
});

router.post('/item/', function(req, res, next) {
    return userService.createItem(
        req.body['userId'],
        req.body['item'],
    )
    .then(result => res.status(201).json(result))
    .catch(err => res.status(500).json(err))
});

router.post('/job/', function(req, res, next) {
    return userService.createJob(
        req.body['userId'],
        req.body['job'],
    )
    .then(result => res.status(201).json(result))
    .catch(err => res.status(500).json(err))
});


router.delete('/item/', function(req, res, next) {
    return userService.deleteItem(
        req.body['userId'],
        req.body['itemId'],
    )
    .then(result => res.status(200).json(result))
    .catch(err => res.status(500).json(err))
});

module.exports = router;
