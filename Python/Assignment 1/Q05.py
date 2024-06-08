input_list = ["Rock Band", "Rock Band 2", "Rock Band", "Rock Band 3", "The Beatles Rock Band", "Rock Band 2", "Green Day Rock Band", "Rock Band 3", "Green Day Rock Band"]

uniques = []
for item in input_list:
    if item not in uniques:
        uniques.append(item)

print("List without duplicates:", uniques)