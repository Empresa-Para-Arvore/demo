var express = require('express');
var router = express.Router();
let tagBase = require('../model/tag')

/* GET users listing. */
router.get('/', function(req, res, next) {
    tagBase.find()
    .then(result => res.status(200).send(result))
    .catch(err => res.status(500).send(err))
});

router.post('/', function(req, res, next) {
    tagBase.create({
        description : req.body['description'],
        path: req.body['path'],
    })
    .then(result => res.status(200).send(result))
    .catch(err => res.status(500).send(err))
});

module.exports = router;
