#include <iostream>
#include <string>
#include <cctype>
#include <algorithm>
#include <limits>
using namespace std;

bool isPalindrome(const string& str) {
    string cleanStr;
    
    for (char c : str) {
        if (isalnum(c)) {
            cleanStr += tolower(c);
        }
    }
    
    string reverseStr = cleanStr;
    reverse(reverseStr.begin(), reverseStr.end());
    
    return cleanStr == reverseStr;
}

void displayResult(const string& str, bool isPal) {
    cout << "\n-- Palindrome Check Result --" << endl;
    cout << "Original string: " << str << endl;
    cout << "Result: " << (isPal ? "IS a palindrome" : "IS NOT a palindrome") << endl;
    cout << "-----------------------------\n" << endl;
}

int main() {
    string input;
    int choice;

    do {
        cout << "Palindrome Checker\n================" << endl;
        cout << "1.) Check a string" << endl;
        cout << "2.) Exit" << endl;
        cout << "=================" << endl;
        cout << "Enter your choice: ";
        cin >> choice;

        if (cin.fail() || choice < 1 || choice > 2) {
            cin.clear();
            cin.ignore(numeric_limits<streamsize>::max(), '\n');
            cout << "Invalid entry. There are only 2 options, man..." << endl;
            continue;
        }

        switch (choice) {
            case 1: {
                cout << "Enter a string: ";
                cin.ignore();
                getline(cin, input);

                if (input.empty()) {
                    cout << "Error: Empty string is not valid." << endl;
                    break;
                }

                bool result = isPalindrome(input);
                displayResult(input, result);
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
