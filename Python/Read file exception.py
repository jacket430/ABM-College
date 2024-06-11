import os

def read_file(filename):
    if not os.path.exists(filename):
        raise FileNotFoundError(f"{filename} does not exist.")
    try:
        with open(filename, 'r') as file:
            print(file.read())
    except IOError:
        raise IOError(f"Error occurred while reading {filename}.")

read_file("test.txt")