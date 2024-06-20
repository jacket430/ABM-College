def countNumbersWithUniqueDigits(n):
    if n == 0:
        return 1
    
    total = 10
    uniqueDigits = 9

    for i in range(2, n+1):
        uniqueDigits *= 10 - (i - 1)
        total += uniqueDigits
    return total

n = 2
print(f"Unique number of digits for {n} is {countNumbersWithUniqueDigits(n)}.")