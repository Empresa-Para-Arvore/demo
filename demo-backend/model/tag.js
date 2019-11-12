let mongoose = require('mongoose');
let Schema = mongoose.Schema;

let schema = new Schema({
    description : String,
    path : String,
});

module.exports = mongoose.model('TagModel', schema);