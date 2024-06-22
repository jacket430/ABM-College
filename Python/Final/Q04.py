def shiftLetters(s, shifts):
    s_list = list(s)
    total_shifts = 0

    for i in range(len(shifts) - 1, -1, -1):
        total_shifts += shifts[i]
        new_char = chr((ord(s_list[i]) - ord('a') + total_shifts) % 26 + ord('a'))
        s_list[i] = new_char

    return ''.join(s_list)

s = "abc"
shifts = [3, 5, 9]
print (shiftLetters(s, shifts))