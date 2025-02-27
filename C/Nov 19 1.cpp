#include <iostream>
#include <string>
using namespace std;

int main() {
    int age;
    static int lastCheckedAge = -1;
    char applicationType;
    
    cout << "Please enter your age: ";
    cin >> age;
    
    if (age >= 18) {
        if (age == lastCheckedAge) {
            cout << "You have already been confirmed eligible for a driver's license!" << endl;
        } else {
            cout << "You are eligible to apply for a driver's license!" << endl;
            lastCheckedAge = age;
        }
        
        cout << "\nAre you renewing (R) or applying for the first time (F)? ";
        cin >> applicationType;
        
        if (toupper(applicationType) == 'R') {
            cout << "You have selected to RENEW your driver's license." << endl;
        } else if (toupper(applicationType) == 'F') {
            cout << "You have selected to apply for your FIRST driver's license." << endl;
        } else {
            cout << "Invalid selection. Please choose 'R' for renewal or 'F' for first time." << endl;
        }
    } else {
        cout << "Sorry, you are not old enough to apply for a driver's license." << endl;
        lastCheckedAge = age;
    }
    
    return 0;
}
