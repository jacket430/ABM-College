#include <iostream>
#include <string>
#include <limits>

class BankAccount {
private:
    std::string accountHolder; // Name of the account holder
    std::string accountNumber; // Unique account number
    double balance; // Current balance

public:
    // Constructor
    BankAccount() : balance(0.0) {}

    // Create a new account
    void createAccount(const std::string& holder, const std::string& accNumber) {
        accountHolder = holder;
        accountNumber = accNumber;
        balance = 0.0;
        std::cout << "Account created successfully.\n";
    }

    // Deposit money into the account
    void deposit(double amount) {
        if (amount > 0) {
            balance += amount;
            std::cout << "Deposited: $" << amount << "\n";
        } else {
            std::cout << "Invalid deposit amount.\n";
        }
    }

    // Withdraw money from the account
    bool withdraw(double amount) {
        if (amount > 0 && amount <= balance) {
            balance -= amount;
            std::cout << "Withdrew: $" << amount << "\n";
            return true;
        } else {
            std::cout << "Insufficient balance or invalid amount.\n";
            return false;
        }
    }

    // Check the current balance
    void checkBalance() const {
        std::cout << "Current balance: $" << balance << "\n";
    }

    // Display account information
    void displayAccountInfo() const {
        std::cout << "Account Holder: " << accountHolder << "\n"
                    << "Account Number: " << accountNumber << "\n"
                    << "Balance: $" << balance << "\n";
    }
};

int main() {
    BankAccount account;
    int choice;

    do {
        std::cout << "\n";
        std::cout << "*************************************\n";
        std::cout << "*          Banking System           *\n";
        std::cout << "*************************************\n";
        std::cout << "* 1) Create a new account           *\n";
        std::cout << "* 2) Deposit money                  *\n";
        std::cout << "* 3) Withdraw money                 *\n";
        std::cout << "* 4) Check balance                  *\n";
        std::cout << "* 5) Display account information    *\n";
        std::cout << "* 6) Exit                           *\n";
        std::cout << "*************************************\n";
        std::cout << "Enter your choice: ";
        std::cin >> choice;

        if (std::cin.fail()) {
            std::cin.clear();
            std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
            std::cout << "Invalid input. Please enter a number.\n";
            continue;
        }

        switch (choice) {
            case 1: {
                std::string holder, accNumber;
                std::cout << "Enter account holder name: ";
                std::cin.ignore();
                std::getline(std::cin, holder);
                std::cout << "Enter account number: ";
                std::getline(std::cin, accNumber);
                account.createAccount(holder, accNumber);
                break;
            }
            case 2: {
                double amount;
                std::cout << "Enter amount to deposit: ";
                std::cin >> amount;
                account.deposit(amount);
                break;
            }
            case 3: {
                double amount;
                std::cout << "Enter amount to withdraw: ";
                std::cin >> amount;
                account.withdraw(amount);
                break;
            }
            case 4:
                account.checkBalance();
                break;
            case 5:
                account.displayAccountInfo();
                break;
            case 6:
                std::cout << "Exiting the program. Goodbye!\n";
                break;
            default:
                std::cout << "Invalid selection. Please try again.\n";
        }
    } while (choice != 6);

    return 0;
}
