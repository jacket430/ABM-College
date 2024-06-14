def add_digits(num):
    while num >= 10:
        num = sum(int(digit) for digit in str(num))
    return num

input_num = int(input("Enter a number: "))
result = add_digits(input_num)
print("Output:", result)