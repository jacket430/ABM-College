from flask import Flask

app = Flask(__name__)

@app.route('/abm/<name> <password>')
def hello(name, password):
    if name == 'avery' and password == '2263634':
        return 'Login successful'
    else:
        return 'Error: Invalid credentials'

if __name__ == '__main__':
    app.run(debug=True)