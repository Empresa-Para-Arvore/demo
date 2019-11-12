var express = require('express');
var router = express.Router();

let userBase = require('../model/user')
let tagBase = require('../model/tag')

router.get('/tag', function(req, res, next) {
    tagBase.create([
        {
            description : 'Idiomas',
            path: 'Comunicação->Idiomas',
        },
        {
            description : 'Java',
            path: 'Logica->Tecnologia->Java',
        },
        {
            description : 'DotNET',
            path: 'Logica->Tecnologia->DotNET',
        },
        {
            description : 'Ingles',
            path: 'Comunicação->Idiomas->Ingles',
        },
        {
            description : 'Liderança',
            path: 'Interpessoal->Liderança',
        },
        {
            description : 'Networking',
            path: 'Intrapessoal->Networking',
        },
        {
            description : 'Auto-Conhecimento',
            path: 'Interpessoal->Networking',
        },
    ])
    .then(result => res.status(201).send(result))
    .catch(err => res.status(500).send(err))
});

module.exports = router;
