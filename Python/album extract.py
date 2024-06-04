input = "a@v@e%r^^y h&og@a^n! 1@2^*3&$4&@$5"
cleaned = ''.join(char for char in input if char.isalnum() or char.isspace())
print(cleaned)
