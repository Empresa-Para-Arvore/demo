var express = require('express');
var router = express.Router();

let userBase = require('../model/user')
let tagBase = require('../model/tag')

/* GET home page. */
router.get('/', function(req, res, next) {
  res.render('index', { title: 'Express' });
});

router.delete('/', function(req, res, next) {
  userBase.remove({})
  .then(() => tagBase.remove().then(res.send()))
  .catch((err => res.status(500).send(err)))
});

module.exports = router;
