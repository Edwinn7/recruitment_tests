/*
con node y el gestor de dependencias npm, me conecto a la base de datos y hago la respectiva consulta,
aunque lo hice mas facil desde MySQL WorkBench
*/
const mysql = require('mysql');

const connection = mysql.createConnection({
  host: "20.190.239.235",
  user: "test01",
  password: "q_fIK94Kv5eYV4m9mE1rU9Vm",
  database: "db_selection_01",
  port: "52347"
});

// Connect to the database
connection.connect((err) => {
  if (err) throw err;
  console.log('Connected to the remote MariaDB database!');
});

// Perform a query on the database
connection.query('SELECT Country.name FROM Country LEFT JOIN Person ON Country.id = Person.country_id WHERE Person.name IS NULL;', (err, rows) => {
  if (err) throw err;
  console.log('Data received from the remote MariaDB database:');
  console.log(rows);
});

//Close the database connection
connection.end((err) => {
  if (err) throw err;
  console.log('Disconnected from the remote MariaDB database.');
});