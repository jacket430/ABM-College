import re

def validate_email(email):
    pattern = r"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$"
    if re.match(pattern, email):
        return True
    else:
        return False

email = input("Please enter email for verification: ")

if validate_email(email):
    print("The email is valid.")
else:
    print("The email is not valid.")