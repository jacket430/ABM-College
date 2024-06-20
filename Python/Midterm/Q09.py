def file_operations(filename):
    try:
        file = open(filename, 'r')
    except IOError:
        print(f"File '{filename}' not found.")
        return
    try:
        content = file.read()
        print(content)
    except IOError:
        print(f"Failed to read '{filename}'.")
    finally:
        file.close()

file_operations('test.txt')