def smallestFactorization(n):
    if n == 1:
        return "1"
    factors = []
    for i in range(9, 1, -1):
        while n % i == 0:
            n = n // i
            factors.append(str(i))
    if n != 1:
        return "-1"
    factors.reverse()
    return "".join(factors)

n = 105
print(smallestFactorization(n))