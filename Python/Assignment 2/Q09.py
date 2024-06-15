try:
    with open('filename.txt', 'r') as file:
        data = file.read()
except FileNotFoundError:
    print("File not found.")
except IOError:
    print("Error reading file.")