import threading
import multiprocessing

def cpu_task():
    print("CPU: Calculating square of 1000")
    square = 1000 * 1000
    print(f"CPU: Square of 1000 is {square}!")

def io_task():
    print("I/O: Writing to the console")
    print("I/O: I/O task complete!")

if __name__ == "__main__":
    thread = threading.Thread(target=io_task)
    process = multiprocessing.Process(target=cpu_task)
    
    thread.start()
    process.start()
    
    thread.join()
    process.join()