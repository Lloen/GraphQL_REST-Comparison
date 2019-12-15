const express = require('express');
var graphqlHTTP  = require('express-graphql');
const schema = require('./schema.js')
const bodyParser = require('body-parser');
const apiDVD = require('./app/api/api.js');
const db = require('./models');

const app = express();


app.use(bodyParser.json());
app.use(express.static(__dirname + '/static'));
app.use('/graphql', graphqlHTTP({
    schema: schema,
    graphiql: true
}))

apiDVD(app, db);



app.listen(3000, () => {
  console.log('Server is up on port 3000');
});