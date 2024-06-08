class base_class:
    def __init__(self, name):
        self.name = name
        
    def line(self):
            return "ERROR!"

# Polymorphism is changing an the way an object responds to the same method calls. 
# In this example, I am creating a base class that will an error when called.

class First(base_class):
    def line(self):
        return "First Success!"
    
class Second(base_class):
    def line(self):
        return "Second Success!"

# Here are two child classes, note that they have overwritten the "line" call from the base class.
# Let's try calling them.

first = First("Avery")
second = Second("Harman")

print (first.name + " says, " + first.line())
print (second.name + " says, " + second.line())

# You'll notice that they properly say the overwritten "line" calls. You could, in theory,
# replace those with whatever you wanted and create completely different functions that
# can be called the same way.