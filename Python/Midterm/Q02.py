def subsetsWithDup(nums):
    def backtrack(start, curr):
        res.append(list(curr))
        for i in range(start, len(nums)):
            if i > start and nums[i] == nums[i-1]:
                continue
            curr.append(nums[i])
            backtrack(i + 1, curr)
            curr.pop()

    nums.sort()
    res = []
    backtrack(0, [])
    return res

print(subsetsWithDup([1,2,2]))