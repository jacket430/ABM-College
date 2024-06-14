def is_child_in_order(parent, child):
    index = 0
    for char in child:
        found = parent.find(char, index)
        if found == -1:
            return False
        index = found + 1
    return True

parent = "abcdefghijk"
child1 = "bdg"
child2 = "jcd"

print(is_child_in_order(parent, child1))
print(is_child_in_order(parent, child2))