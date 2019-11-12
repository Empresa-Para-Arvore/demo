var express = require('express');
var router = express.Router();
let service = require('../services/user')

router.post('/', function(req, res, next) {
  service.login(req.body['email'], req.body['password'])
  .then(result => res.status(result ? 200 : 401).send(result))
  .catch(err => res.status(500).send())
});

module.exports = router;
