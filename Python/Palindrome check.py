def main():
    input_string = input("Enter a word: ")
    
    char_array = list(input_string)
    char_array.reverse()
    
    reversed_string = ''.join(char_array)
    
    is_palindrome = input_string == reversed_string
    
    if is_palindrome:
        print("The input is a palindrome.")
    else:
        print("The input is not a palindrome.")

if __name__ == "__main__":
    main()
