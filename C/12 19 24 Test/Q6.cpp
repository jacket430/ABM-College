#include <iostream>
#include <limits>
using namespace std;

void generateFibonacci(int n) {
    long long first = 0, second = 1, next;
    
    cout << "\n-- Fibonacci Sequence --" << endl;
    cout << "First " << n << " terms:" << endl;
    
    for (int i = 0; i < n; i++) {
        if (i <= 1) {
            next = i;
        } else {
            next = first + second;
            first = second;
            second = next;
        }
        cout << next;
        if (i < n - 1) cout << ", ";
    }
    cout << "\n------------------------\n" << endl;
}

int main() {
    int choice, terms;

    do {
        cout << "Fibonacci Generator\n=================" << endl;
        cout << "1.) Generate series" << endl;
        cout << "2.) Exit" << endl;
        cout << "=================" << endl;
        cout << "Enter your choice: ";
        cin >> choice;

        if (cin.fail() || choice < 1 || choice > 2) {
            cin.clear();
            cin.ignore(numeric_limits<streamsize>::max(), '\n');
            cout << "Invalid entry. Please enter 1 or 2." << endl;
            continue;
        }

        switch (choice) {
            case 1: {
                cout << "Enter number of terms (positive integer): ";
                cin >> terms;

                if (cin.fail() || terms <= 0) {
                    cin.clear();
                    cin.ignore(numeric_limits<streamsize>::max(), '\n');
                    cout << "Error: Please enter a positive integer." << endl;
                    break;
                }

                generateFibonacci(terms);
                break;
            }
            case 2:
                cout << "Exiting program. Goodbye!" << endl;
                break;
            default:
                cout << "Invalid selection. Please try again." << endl;
        }
    } while (choice != 2);

    return 0;
}
