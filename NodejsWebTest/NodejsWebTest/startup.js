var http = require('http');
var port = process.env.port || 1337;

http.createServer(app).listen(port);