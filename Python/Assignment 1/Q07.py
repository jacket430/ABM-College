class Cat:
    def __init__(self, name, breed):
        self.name = name
        self.breed = breed
    def speak(self):
        return "*Generic Cat Meow*"

# Inheritance is when a child class inherits the properties of a parent class.
# I like cats so I'm going to use famous internet cats as examples.
# Above, we've created the base class that our child Cat classes will inherit.

class Bingus(Cat):
    def speak(self):
        return "Everybody do the Bingus!"

# Here we've created a class for Bingus, and defined his "speak" string, overwriting the "Generic Cat Meow".
# Note how we didn't have to initialize a name, or breed value as they were inherited from the "Cat" class.

class Floppa(Cat):
    def speak(self):
        return "I love it when you call me Big Floppa! (In the tune of Big Poppa)"

# We've just created a class for Floppa, following the same reasoning as above.

bingus = Bingus("Bingus the Hairless Cat", "Sphynx")
floppa = Floppa("Big Floppa", "Caracal")

# Here, we're setting the "Name" and "Breed" values, as initialized in the parent class.
# That's all we need to do!
# This saves a lot of time needing to rewrite the same code over and over.

print(f"{bingus.name} says: {bingus.speak()}")
print(f"{floppa.name} says: {floppa.speak()}")

# Here, we are calling on bingus and floppa to state their names and say their speak lines.
# You'll notice that they're using names properly as they're pulling from the parent class.
# The "speak" lines are properly overwritten as requested.

print (f"{bingus.name} is a {bingus.breed}")
print (f"{floppa.name} is a {floppa.breed}")

# Finally, we're printing their names again, plus the breed values we also set on lines 26 and 27.
# All done without needing to initialize name and breed specifically for the child classes.