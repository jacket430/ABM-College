class Stack:
    def __init__(self):
        self.stack = []
        print("Stack initialized.")

    def push(self, item):
        self.stack.append(item)
        print(f"Item '{item}' pushed to stack.")

    def pop(self):
        if len(self.stack) > 0:
            item = self.stack.pop()
            print(f"Item '{item}' popped from stack.")
            return item
        else:
            print("Stack is empty, nothing to pop.")
            return None

    def is_empty(self):
        empty = len(self.stack) == 0
        print(f"Stack is {'empty' if empty else 'not empty'}.")
        return empty
    
if __name__ == "__main__":
    my_stack = Stack()
    print("New stack created.")

    my_stack.push("tina")
    my_stack.push("tommy")
    my_stack.push("misty")
    print("Three items pushed onto the stack.")

    print("Checking if stack is empty.")
    my_stack.is_empty()

    print("Popping stack.")
    my_stack.pop()

    print("Checking if stack is empty again.")
    my_stack.is_empty()

    print("Popping remaining items.")
    my_stack.pop()
    my_stack.pop()
    print("All items popped from the stack.")

    print("Attempting to pop empty stack.")
    my_stack.pop()