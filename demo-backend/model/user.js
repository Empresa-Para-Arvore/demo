let mongoose = require('mongoose');
let Schema = mongoose.Schema;

let itemSchema = new Schema({
    title : String,
    description : String,
    score: Number,
    tags : [String],
});

let jobSchema = new Schema({
    company : String,
    title : String,
    time : Number,
    description : String,
});

let UserSchema = new Schema({
    name : String,
    email : String,
    password : String,
    age: Number,
    jobs: [jobSchema],
    items: [itemSchema],
    tree: {}
}); 

module.exports = mongoose.model('UserModel', UserSchema);