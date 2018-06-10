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

app.listen(PORT);
console.log('Running on http://localhost:' + PORT);
