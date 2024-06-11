class InvalidAgeValue(Exception):
    pass

def validate_age(age):
    if not isinstance(age, int):
        raise TypeError("Age must be an integer.")
    if age > 150:
        raise InvalidAgeValue("Age cannot be above 150.")

try:
    age = int(input("Enter your age: "))
    validate_age(age)
except InvalidAgeValue as e:
    print(e)
except ValueError:
    print("Invalid input. Please enter an integer.")