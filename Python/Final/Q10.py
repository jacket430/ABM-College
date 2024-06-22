with open('names.txt', 'r', encoding='utf-8') as file:
    names = file.readlines()

names = [name.strip() for name in names]
names.sort()

with open('names.txt', 'w', encoding='utf-8') as file:
    for name in names:
        file.write(name + '\n')