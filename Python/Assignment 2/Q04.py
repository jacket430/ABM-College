def shift_string(s, goal):
    if len(s) != len(goal):
        return False
    for i in range(len(s)):
        if s == goal:
            return True
        s = s[1:] + s[0]
        print(s)
    return False

input = "abcde"
s = input
goal = "cdeab"
print(shift_string(s, goal))