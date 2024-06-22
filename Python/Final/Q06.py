def is_armstrong(num):
    num_str = str(num)
    num_digits = len(num_str)
    armstrong_sum = sum(int(digit) ** num_digits for digit in num_str)
    if armstrong_sum == num:
        return True
    else:
        return False

def find_armstrong_numbers(start, end):
    armstrong_numbers = []
    for num in range(start, end + 1):
        if is_armstrong(num):
            armstrong_numbers.append(num)
    return armstrong_numbers

while True:
    try:
        start = int(input("Enter the starting number: "))
        end = int(input("Enter the ending number: "))
        if start <= end:
            break
        else:
            print("Starting number should be equal to or less than the ending number.")
    except ValueError:
        print("Please enter a valid integer.")

armstrong_numbers = find_armstrong_numbers(start, end)
print("Armstrong numbers:", armstrong_numbers)