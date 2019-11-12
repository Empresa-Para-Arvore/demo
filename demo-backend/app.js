var express = require('express');
var path = require('path');
var cookieParser = require('cookie-parser');
var logger = require('morgan');

var indexRouter = require('./routes/index');
var usersRouter = require('./routes/users');
let loginRouter = require('./routes/login');
let initRouter = require('./routes/init');
let tagRouter = require('./routes/tag');

const cors = require('cors')

var app = express();

app.use(logger('dev'));
app.use(express.json());
app.use(express.urlencoded({ extended: false }));
app.use(cookieParser());
app.use(express.static(path.join(__dirname, 'public')));

app.use('/', cors(), indexRouter);
app.use('/users', cors(), usersRouter);
app.use('/login', cors(), loginRouter);
app.use('/init', initRouter);
app.use('/tag', tagRouter);

let mongoose = require('mongoose');
mongoose.connect('mongodb://localhost:27017/demo', { useNewUrlParser: true });
mongoose.connection.on('error', console.error.bind(console, 'MongoDB connection error:'));;

module.exports = app;
