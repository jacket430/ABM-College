def uniqueElementSubset(nums):
    results = [[]]
    for num in nums:
        results += [curr + [num] for curr in results]
    return results

nums = [1, 2, 3]
print (uniqueElementSubset(nums))