def lookup_element(list, index):
    try:
        index = int(index)
        return list[index]
    except ValueError:
        raise Exception("Input is not a valid integer.")
    except IndexError:
        raise Exception("Index is out of range.")

list = ['Walter White', 'Jesse Pinkman', 'Skyler White', 'Hank Schrader', 'Saul Goodman']

while True:
    index = input("Enter an index to look up: ")
    try:
        print(lookup_element(list, index))
    except Exception as e:
        print(e)