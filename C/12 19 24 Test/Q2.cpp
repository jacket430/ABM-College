#include <iostream>
#include <iomanip>
#include <string>
#include <limits>
using namespace std;

class HotelRoom {
private:
    int roomNumber;
    string roomType;
    bool isAvailable;
    double pricePerNight;

public:
    HotelRoom(int number, string type, double price) 
        : roomNumber(number), roomType(type), isAvailable(true), pricePerNight(price) {}

    bool bookRoom() {
        if (isAvailable) {
            isAvailable = false;
            cout << "\nSuccessfully booked room: " << roomNumber << endl;
            cout << "Room status: Booked" << endl;
            return true;
        } else {
            cout << "Error: Room " << roomNumber << " is already booked." << endl;
            return false;
        }
    }

    bool cancelBooking() {
        if (!isAvailable) {
            isAvailable = true;
            cout << "\nSuccessfully cancelled booking for room: " << roomNumber << endl;
            cout << "Room status: Available" << endl;
            return true;
        } else {
            cout << "Error: Room " << roomNumber << " is not currently booked." << endl;
            return false;
        }
    }

    void displayRoomDetails() const {
        cout << "-- Room Details --" << endl;
        cout << "Number: " << roomNumber << endl;
        cout << "Type: " << roomType << endl;
        cout << "Price per night: $" << fixed << setprecision(2) << pricePerNight << endl;
        cout << "Status: " << (isAvailable ? "Available" : "Booked") << endl;
        cout << "----------------\n" << endl;
    }

    int getRoomNumber() const { return roomNumber; }
};

bool isValidRoomNumber(int roomNum, HotelRoom hotel[], int numRooms) {
    for (int i = 0; i < numRooms; i++) {
        if (hotel[i].getRoomNumber() == roomNum) {
            return true;
        }
    }
    return false;
}

void clearInputBuffer() {
    cin.clear();
    cin.ignore(numeric_limits<streamsize>::max(), '\n');
}

int main() {
    const int NUM_ROOMS = 5;
    HotelRoom hotel[NUM_ROOMS] = {
        HotelRoom(101, "Single", 100.0),
        HotelRoom(102, "Single", 100.0),
        HotelRoom(201, "Double", 150.0),
        HotelRoom(202, "Double", 150.0),
        HotelRoom(301, "Suite", 250.0)
    };

    int choice;
    do {
        cout << "Avery's Hotel Booking System\n======= Menu =======" << endl;
        cout << "1.) View all rooms" << endl;
        cout << "2.) Book a room" << endl;
        cout << "3.) Cancel booking" << endl;
        cout << "4.) Exit" << endl;
        cout << "====================" << endl;
        cout << "Enter a selection: ";

        if (!(cin >> choice)) {
            cout << "Error: Invalid input. Please enter a number." << endl;
            clearInputBuffer();
            continue;
        }

        switch (choice) {
            case 1: {
                cout << "\nCurrent Room Status:\n" << endl;
                for (int i = 0; i < NUM_ROOMS; i++) {
                    hotel[i].displayRoomDetails();
                }
                break;
            }
            case 2: {
                int roomNum;
                cout << "Enter room number to book: ";
                if (!(cin >> roomNum)) {
                    cout << "Error: Invalid input. Please enter a valid room number." << endl;
                    clearInputBuffer();
                    break;
                }

                if (!isValidRoomNumber(roomNum, hotel, NUM_ROOMS)) {
                    cout << "Error: Room not found. Are you sure you entered the correct number?" << endl;
                    break;
                }

                for (int i = 0; i < NUM_ROOMS; i++) {
                    if (hotel[i].getRoomNumber() == roomNum) {
                        hotel[i].bookRoom();
                        break;
                    }
                }
                break;
            }
            case 3: {
                int roomNum;
                cout << "Enter room number to cancel booking: ";
                if (!(cin >> roomNum)) {
                    cout << "Error: Invalid input. Please enter a valid room number." << endl;
                    clearInputBuffer();
                    break;
                }

                if (!isValidRoomNumber(roomNum, hotel, NUM_ROOMS)) {
                    cout << "Error: Room not found. Double-check the number." << endl;
                    break;
                }

                for (int i = 0; i < NUM_ROOMS; i++) {
                    if (hotel[i].getRoomNumber() == roomNum) {
                        hotel[i].cancelBooking();
                        break;
                    }
                }
                break;
            }
            case 4:
                cout << "Exiting. Goodbye!" << endl;
                break;
            default:
                cout << "Invalid selection. Please try again." << endl;
        }
    } while (choice != 4);

    return 0;
}
