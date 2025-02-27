#include <iostream>
#include <iomanip>
#include <string>
#include <limits>
using namespace std;

class HolidayPackage {
private:
    int packageId;
    string packageName;
    double pricePerPerson;
    int availability;

public:
    HolidayPackage() : packageId(0), packageName(""), pricePerPerson(0.0), availability(0) {}

    HolidayPackage(int id, const string& name, double price, int spots) 
        : packageId(id), packageName(name), pricePerPerson(price), availability(spots) {}

    int getPackageId() const { return packageId; }
    string getPackageName() const { return packageName; }
    double getPricePerPerson() const { return pricePerPerson; }
    int getAvailability() const { return availability; }

    void bookPackage(int numPersons) {
        if (numPersons > 0) {
            if (availability >= numPersons) {
                availability -= numPersons;
                cout << "Successfully booked for " << numPersons << " person(s)" << endl;
                cout << "Total cost: $" << fixed << setprecision(2) << (pricePerPerson * numPersons) << endl;
                cout << "Remaining spots: " << availability << endl;
            } else {
                cout << "Error: Not enough spots available." << endl;
                cout << "Available spots: " << availability << endl;
                cout << "Requested spots: " << numPersons << endl;
            }
        } else {
            cout << "Error: Invalid number of persons." << endl;
        }
    }

    void cancelBooking(int numPersons) {
        if (numPersons > 0) {
            availability += numPersons;
            cout << "\nSuccessfully cancelled booking for: " << numPersons << " person(s)" << endl;
            cout << "Updated availability: " << availability << " spots" << endl;
        } else {
            cout << "Error: Invalid cancellation request." << endl;
        }
    }

    void displayPackageDetails() const {
        cout << "\n-- Package Details --" << endl;
        cout << "ID: " << packageId << endl;
        cout << "Package: " << packageName << endl;
        cout << "Price per person: $" << fixed << setprecision(2) << pricePerPerson << endl;
        cout << "Available spots: " << availability << endl;
        cout << "---------------------\n" << endl;
    }
};

bool isValidPackageId(int packageId, HolidayPackage packages[], int numPackages) {
    for (int i = 0; i < numPackages; i++) {
        if (packages[i].getPackageId() == packageId) {
            return true;
        }
    }
    return false;
}

int main() {
    const int NUM_PACKAGES = 3;
    HolidayPackage packages[NUM_PACKAGES] = {
        HolidayPackage(1, "Mountain Adventure", 199.99, 20),
        HolidayPackage(2, "Lake Louise Tour", 299.99, 30),
        HolidayPackage(3, "Ski Experience", 399.99, 15)
    };
    int choice;

    do {
        cout << "Banff Tours Booking System\n======= Menu =======" << endl;
        cout << "1.) View all packages" << endl;
        cout << "2.) Book a package" << endl;
        cout << "3.) Cancel booking" << endl;
        cout << "4.) Exit" << endl;
        cout << "====================" << endl;        
        cout << "Enter a selection: ";
        cin >> choice;

        if (cin.fail() || choice < 1 || choice > 4) {
            cin.clear();
            cin.ignore(numeric_limits<streamsize>::max(), '\n');
            cout << "Invalid entry. Please enter a valid selection." << endl;
            continue;
        }

        switch (choice) {
            case 1: {
                cout << "\nAvailable Holiday Packages:" << endl;
                for (int i = 0; i < NUM_PACKAGES; i++) {
                    packages[i].displayPackageDetails();
                }
                break;
            }
            case 2: {
                int packageId, numPersons;
                cout << "Enter package ID: ";
                cin >> packageId;

                if (!isValidPackageId(packageId, packages, NUM_PACKAGES)) {
                    cout << "Error: Package not found. Please check the ID." << endl;
                    break;
                }

                cout << "Enter number of persons: ";
                cin >> numPersons;

                if (cin.fail() || numPersons <= 0) {
                    cin.clear();
                    cin.ignore(numeric_limits<streamsize>::max(), '\n');
                    cout << "Error: Invalid number of persons." << endl;
                    break;
                }

                for (int i = 0; i < NUM_PACKAGES; i++) {
                    if (packages[i].getPackageId() == packageId) {
                        packages[i].bookPackage(numPersons);
                        break;
                    }
                }
                break;
            }
            case 3: {
                int packageId, numPersons;
                cout << "Enter package ID: ";
                cin >> packageId;

                if (!isValidPackageId(packageId, packages, NUM_PACKAGES)) {
                    cout << "Error: Package not found. Please check the ID." << endl;
                    break;
                }

                cout << "Enter number of persons to cancel: ";
                cin >> numPersons;

                if (cin.fail() || numPersons <= 0) {
                    cin.clear();
                    cin.ignore(numeric_limits<streamsize>::max(), '\n');
                    cout << "Error: Invalid number of persons." << endl;
                    break;
                }

                for (int i = 0; i < NUM_PACKAGES; i++) {
                    if (packages[i].getPackageId() == packageId) {
                        packages[i].cancelBooking(numPersons);
                        break;
                    }
                }
                break;
            }
            case 4:
                cout << "Thank you for using Banff Tours Booking System. Goodbye!" << endl;
                break;
            default:
                cout << "Invalid selection. Please try again." << endl;
        }
    } while (choice != 4);

    return 0;
}
