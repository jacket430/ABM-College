#include <iostream>
#include <vector>
#include <string>
#include <limits>

// Class representing a Book
class Book {
private:
    int bookID; // Unique identifier for the book
    std::string title; // Title of the book
    std::string author; // Author of the book
    bool isAvailable; // Availability status of the book

public:
    // Constructor to initialize a book with an ID, title, and author
    Book(int id, const std::string& t, const std::string& a)
        : bookID(id), title(t), author(a), isAvailable(true) {}

    // Display the details of the book
    void displayDetails() const {
        std::cout << "Book ID: " << bookID << "\n"
                    << "Title: " << title << "\n"
                    << "Author: " << author << "\n"
                    << "Availability: " << (isAvailable ? "Available" : "Unavailable") << "\n";
    }

    // Borrow the book if it is available
    void borrowBook() {
        if (isAvailable) {
            isAvailable = false;
            std::cout << "Successfully borrowed book: " << title << "\n";
        } else {
            std::cout << "Book currently unavailable. Enter new selection.\n";
        }
    }

    // Return the book, making it available again
    void returnBook() {
        isAvailable = true;
        std::cout << "Successfully returned book: " << title << "\n";
    }

    // Get the book ID
    int getBookID() const {
        return bookID;
    }
};

// Class representing a Library
class Library {
private:
    std::vector<Book> books; // Collection of books in the library

public:
    // Add a new book to the library
    void addBook(const Book& book) {
        books.push_back(book);
        std::cout << "Book added successfully.\n";
    }

    // List all books in the library
    void listBooks() const {
        for (const auto& book : books) {
            book.displayDetails();
            std::cout << "-------------------\n";
        }
    }

    // Borrow a book by its ID
    void borrowBookByID(int bookID) {
        for (auto& book : books) {
            if (book.getBookID() == bookID) {
                book.borrowBook();
                return;
            }
        }
        std::cout << "Book ID " << bookID << " not found.\n";
    }

    // Return a book by its ID
    void returnBookByID(int bookID) {
        for (auto& book : books) {
            if (book.getBookID() == bookID) {
                book.returnBook();
                return;
            }
        }
        std::cout << "Book ID " << bookID << " not found.\n";
    }
};

int main() {
    Library library; // Create a library object
    int choice; // Variable to store user choice

    do {
        // Display menu options
        std::cout << "\n";
        std::cout << "*************************************\n";
        std::cout << "*        Library Management         *\n";
        std::cout << "*************************************\n";
        std::cout << "* 1) Add New Book                   *\n";
        std::cout << "* 2) List All Books                 *\n";
        std::cout << "* 3) Borrow Book by ID              *\n";
        std::cout << "* 4) Return Book by ID              *\n";
        std::cout << "* 5) Exit                           *\n";
        std::cout << "*************************************\n";
        std::cout << "Enter your choice: ";
        std::cin >> choice;

        switch (choice) {
            case 1: {
                int id;
                std::string title, author;
                // Prompt user for book details
                std::cout << "Enter book ID: ";
                while (!(std::cin >> id)) {
                    std::cout << "Invalid input. Please enter a numeric book ID: ";
                    std::cin.clear();
                    std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
                }
                std::cin.ignore();
                std::cout << "Enter book title: ";
                std::getline(std::cin, title);
                std::cout << "Enter book author: ";
                std::getline(std::cin, author);
                library.addBook(Book(id, title, author)); // Add book to library
                break;
            }
            case 2:
                library.listBooks(); // List all books
                break;
            case 3: {
                int id;
                // Prompt user for book ID to borrow
                std::cout << "Enter book ID to borrow: ";
                while (!(std::cin >> id)) {
                    std::cout << "Invalid input. Please enter a numeric book ID: ";
                    std::cin.clear();
                    std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
                }
                library.borrowBookByID(id); // Borrow book by ID
                break;
            }
            case 4: {
                int id;
                // Prompt user for book ID to return
                std::cout << "Enter book ID to return: ";
                while (!(std::cin >> id)) {
                    std::cout << "Invalid input. Please enter a numeric book ID: ";
                    std::cin.clear();
                    std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
                }
                library.returnBookByID(id); // Return book by ID
                break;
            }
            case 5:
                std::cout << "Exiting the program. Goodbye!\n"; // Exit the program
                break;
            default:
                std::cout << "Invalid selection. Please try again.\n"; // Handle invalid menu selection
        }
    } while (choice != 5); // Continue until user chooses to exit

    return 0;
}
