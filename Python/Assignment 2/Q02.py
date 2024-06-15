# I'm not sure if this code actually works, as I didn't create a database to connect to, but it should..? In theory?

import mysql.connector

cnx = mysql.connector.connect(
    host="host_name",
    user="username",
    password="password",
    database="database"
)

cursor = cnx.cursor()
cursor.execute("SELECT * FROM employees")
rows = cursor.fetchall()

for row in rows:
    print(row)

cnx.close()