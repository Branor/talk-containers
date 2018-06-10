'use strict';

const express = require('express');
var os = require('os');

// Constants
const PORT = 6060;

// App
const app = express();
app.get('/', function (req, res) {
  res.send('[' + os.hostname() + '] Hello world!\n');
});

app.get('/monitoring/health', function (req, res) {
  res.send('[' + os.hostname() + '] All good!');
});

app.get('/monitoring/ready', function (req, res) {
  res.send('[' + os.hostname() + '] Ready to go!');
});

app.listen(PORT);
console.log('Running on http://localhost:' + PORT);
