def count_lines(file_path):
    try:
        with open(file_path, 'r') as file:
            lines = file.readlines()
            return len(lines)
    except FileNotFoundError:
        return "File not found."

file_path = 'Q6Lines.txt' ## 30 lines in the included file
total_lines = count_lines(file_path)
print(f'Total number of lines: {total_lines}')
