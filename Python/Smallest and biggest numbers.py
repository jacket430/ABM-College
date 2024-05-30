numbers = [2, 5, 9, 7, 11, 23, 56, 25]

smallest_number = numbers[0]
biggest_number = numbers[0]

for number in numbers:
    if number < smallest_number:
        smallest_number = number
    if number > biggest_number:
        biggest_number = number

print("Smallest -", smallest_number, "Largest -", biggest_number)