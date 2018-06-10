'use strict';

const express = require('express');
var winston = require('winston');
require('winston-logstash');

var logger = new (winston.Logger)({
  transports: [
       new (winston.transports.Logstash)({
           port: 5000,
           host: 'logstash',
           max_connect_retries: 1,
           node_name: 'logger',
       }),
       new (winston.transports.File)({
        name: 'info-file',
        filename: 'filelog-info.log',
        level: 'info'
        }),
        new winston.transports.Console()
  ]
});

logger.log('info', 'Logger demo service started');

// Constants
const PORT = 8080;

// App
const app = express();
app.get('/', function (req, res) {
  logger.info('Logger: hello world endpoint called');
  res.send('Hello world, how are you?\n');
});

app.listen(PORT);
console.log('Running on http://localhost:' + PORT);