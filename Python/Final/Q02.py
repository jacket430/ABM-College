def sum_of_divisors_with_four_divisions(nums):
    def sum_divisors(n):
        divisors = [1, n]
        for i in range (2, int(n**0.5) + 1):
            if n % i == 0:
                divisors.extend([i, n//i])
        return sum(set(divisors)) if len(set(divisors)) == 4 else 0
    
    return sum(sum_divisors(num) for num in nums)

nums = [21, 4, 7]
print(sum_of_divisors_with_four_divisions(nums))