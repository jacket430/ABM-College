#include <iostream>
#include <iomanip>
#include <string>
#include <limits>
using namespace std;

class BankAccount {
private:
    int accountNumber;
    string accountHolderName;
    double balance;

public:
    BankAccount() : accountNumber(0), accountHolderName(""), balance(0.0) {}

    BankAccount(int accNumber, const string& holderName, double initialBalance) 
        : accountNumber(accNumber), accountHolderName(holderName), balance(initialBalance) {}

    int getAccountNumber() const { return accountNumber; }
    string getAccountHolderName() const { return accountHolderName; }
    double getBalance() const { return balance; }

    void deposit(double amount) {
        if (amount > 0) {
            balance += amount;
            cout << "Successfully deposited: $" << amount << endl;
            cout << "Updated balance: $" << balance << endl;
        } else {
            cout << "Error: Deposit amount must be positive." << endl;
        }
    }

    void withdraw(double amount) {
        if (amount > 0) {
            if (balance >= amount) {
                balance -= amount;
                cout << "\nSuccessfully withdrew: $" << amount << endl;
                cout << "Updated balance: $" << balance << endl;
                cout << "\n" << amount << endl;
            } else {
                cout << "Error: Insufficient funds to complete withdrawal." << endl;
                cout << "Current balance: $" << balance << endl;
                cout << "Withdrawal amount: $" << amount << endl;
            }
        } else {
            cout << "Error: Invalid withdrawal." << endl;
        }
    }

    void displayAccountDetails() const {
        cout << "\n-- Account Details --" << endl;
        cout << "Number: " << accountNumber << endl;
        cout << "Name: " << accountHolderName << endl;
        cout << "Balance: $" << fixed << setprecision(2) << balance << endl;
        cout << "----------------------\n" << endl;
    }
};

bool isValidAccountNumber(int accNumber, BankAccount accounts[], int numAccounts) {
    for (int i = 0; i < numAccounts; i++) {
        if (accounts[i].getAccountNumber() == accNumber) {
            return true;
        }
    }
    return false;
}

int main() {
    const int MAX_ACCOUNTS = 10;
    BankAccount accounts[MAX_ACCOUNTS];
    int numAccounts = 0;
    int choice;

    do {
        cout << "Avery's Banking System\n======= Menu =======" << endl;
        cout << "1.) New Account" << endl;
        cout << "2.) Deposit" << endl;
        cout << "3.) Withdraw" << endl;
        cout << "4.) Display all accounts" << endl;
        cout << "5.) Exit" << endl;
        cout << "====================" << endl;        
        cout << "Enter a selection: ";
        cin >> choice;

        if (cin.fail() || choice < 1 || choice > 5) {
            cin.clear();
            cin.ignore(numeric_limits<streamsize>::max(), '\n');
            cout << "Invalid entry. Please enter a valid selection." << endl;
            continue;
        }

        switch (choice) {
            case 1: {
                if (numAccounts >= MAX_ACCOUNTS) {
                    cout << "Maximum number of accounts reached. Cannot have more than 10 accounts." << endl;
                    break;
                }

                int accNumber;
                string holderName;
                double initialBalance;

                cout << "Enter account number: ";
                cin >> accNumber;

                if (cin.fail() || accNumber <= 0) {
                    cin.clear();
                    cin.ignore(numeric_limits<streamsize>::max(), '\n');
                    cout << "Error: Account number cannot be negative." << endl;
                    break;
                }

                cout << "Enter account holder name: ";
                cin.ignore();
                getline(cin, holderName);
                cout << "Enter initial balance: $";
                cin >> initialBalance;

                if (cin.fail() || initialBalance < 0) {
                    cin.clear();
                    cin.ignore(numeric_limits<streamsize>::max(), '\n');
                    cout << "Error: Initial balance can't be negative. Are you sure you entered the balance correctly?" << endl;
                    break;
                }

                accounts[numAccounts++] = BankAccount(accNumber, holderName, initialBalance);
                cout << "Successfully created new account." << endl;
                break;
            }
            case 2: {
                int accNumber;
                double amount;
                cout << "Enter account number: ";
                cin >> accNumber;

                if (!isValidAccountNumber(accNumber, accounts, numAccounts)) {
                    cout << "Error: Account not found. Are you sure you entered the correct number?" << endl;
                    break;
                }

                cout << "Enter deposit amount: $";
                cin >> amount;

                if (cin.fail() || amount < 0) {
                    cin.clear();
                    cin.ignore(numeric_limits<streamsize>::max(), '\n');
                    cout << "Error: Deposit can't be negative. Are you trying to withdrawal?" << endl;
                    break;
                }

                for (int i = 0; i < numAccounts; i++) {
                    if (accounts[i].getAccountNumber() == accNumber) {
                        accounts[i].deposit(amount);
                        break;
                    }
                }
                break;
            }
            case 3: {
                int accNumber;
                double amount;
                cout << "Enter account number: ";
                cin >> accNumber;

                if (!isValidAccountNumber(accNumber, accounts, numAccounts)) {
                    cout << "Error: Account not found. Double-check the number." << endl;
                    break;
                }

                cout << "Enter withdrawal amount: $";
                cin >> amount;

                if (cin.fail() || amount < 0) {
                    cin.clear();
                    cin.ignore(numeric_limits<streamsize>::max(), '\n');
                    cout << "Error: Withdrawal can't be negative. Are you trying to make a deposit?" << endl;
                    break;
                }

                for (int i = 0; i < numAccounts; i++) {
                    if (accounts[i].getAccountNumber() == accNumber) {
                        accounts[i].withdraw(amount);
                        break;
                    }
                }
                break;
            }
            case 4: {
                if (numAccounts == 0) {
                    cout << "There are currently no accounts." << endl;
                } else {
                    cout << "\nAll accounts:" << endl;
                    for (int i = 0; i < numAccounts; i++) {
                        accounts[i].displayAccountDetails();
                    }
                }
                break;
            }
            case 5:
                cout << "Exiting. Goodbye!" << endl;
                break;
            default:
                cout << "Invalid selection. Please try again." << endl;
        }
    } while (choice != 5);

    return 0;
}