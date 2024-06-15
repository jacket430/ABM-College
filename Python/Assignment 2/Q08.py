def is_prime(num):
    if num < 2:
        return False
    for i in range(2, int(num**0.5) + 1):
        if num % i == 0:
            return False
    return True

def count_prime(n):
    count = 0
    for i in range(2, n):
        if is_prime(i):
            count += 1
    return count

n = 10
prime_count = count_prime(n)
print(f"There are {prime_count} prime numbers less than {n}, they are {', '.join(str(i) for i in range(2, n) if is_prime(i))}.")