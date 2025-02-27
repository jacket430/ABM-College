#include <iostream>
#include <map>
#include <string>
#include <limits>

// Class representing a delivery
class Delivery {
private:
    int deliveryId; // Unique ID for the delivery
    std::string customerName; // Name of the customer
    std::string address; // Delivery address
    double cost; // Cost of the delivery
    bool delivered; // Delivery status

public:
    // Default constructor
    Delivery() : deliveryId(0), customerName(""), address(""), cost(0.0), delivered(false) {}

    // Parameterized constructor
    Delivery(int id, const std::string& name, const std::string& addr, double c)
        : deliveryId(id), customerName(name), address(addr), cost(c), delivered(false) {}

    // Display delivery details
    void displayDetails() const {
        std::cout << "Delivery ID: " << deliveryId << "\n"
                    << "Customer Name: " << customerName << "\n"
                    << "Address: " << address << "\n"
                    << "Cost: $" << cost << "\n"
                    << "Delivered: " << (delivered ? "Yes" : "No") << "\n";
    }

    // Update delivery status
    void updateStatus(bool status) {
        delivered = status;
    }

    // Get delivery ID
    int getDeliveryId() const {
        return deliveryId;
    }
};

// Class for managing deliveries
class DeliveryManagement {
private:
    std::map<int, Delivery> deliveries; // Map of deliveries

public:
    // Add a new delivery
    void addDelivery(const Delivery& delivery) {
        deliveries[delivery.getDeliveryId()] = delivery;
        std::cout << "Delivery added.\n";
    }

    // Update the status of a delivery
    void updateDeliveryStatus(int deliveryId, bool status) {
        auto it = deliveries.find(deliveryId);
        if (it != deliveries.end()) {
            it->second.updateStatus(status);
            std::cout << "Delivery status updated.\n";
        } else {
            std::cout << "Delivery ID " << deliveryId << " not found.\n";
        }
    }

    // Display all deliveries
    void displayAllDeliveries() const {
        for (const auto& pair : deliveries) {
            pair.second.displayDetails();
            std::cout << "*-------------------------*\n";
        }
    }

    // Search for a delivery by ID
    void searchDelivery(int deliveryId) const {
        auto it = deliveries.find(deliveryId);
        if (it != deliveries.end()) {
            it->second.displayDetails();
        } else {
            std::cout << "Delivery ID " << deliveryId << " not found.\n";
        }
    }
};

int main() {
    DeliveryManagement management; // Instance of DeliveryManagement
    int choice; // User's menu choice

    do {
        // Display menu
        std::cout << "\n";
        std::cout << "*************************************\n";
        std::cout << "*      Delivery Management System   *\n";
        std::cout << "*************************************\n";
        std::cout << "* 1) Add Delivery                   *\n";
        std::cout << "* 2) Update Delivery Status         *\n";
        std::cout << "* 3) Display All Deliveries         *\n";
        std::cout << "* 4) Search for Delivery            *\n";
        std::cout << "* 5) Exit                           *\n";
        std::cout << "*************************************\n";
        std::cout << "Enter your choice: ";
        std::cin >> choice;

        switch (choice) {
            case 1: {
                int id;
                std::string name, address;
                double cost;
                // Input delivery details
                std::cout << "Enter delivery ID: ";
                while (!(std::cin >> id)) {
                    std::cout << "Invalid. Please enter a numeric delivery ID: ";
                    std::cin.clear();
                    std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
                }
                std::cin.ignore();
                std::cout << "Enter customer name: ";
                std::getline(std::cin, name);
                std::cout << "Enter address: ";
                std::getline(std::cin, address);
                std::cout << "Enter cost: ";
                while (!(std::cin >> cost)) {
                    std::cout << "Invalid. Please enter a numeric cost: ";
                    std::cin.clear();
                    std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
                }
                management.addDelivery(Delivery(id, name, address, cost));
                break;
            }
            case 2: {
                int id;
                bool status;
                // Input delivery ID and new status
                std::cout << "Enter delivery ID to update status: ";
                while (!(std::cin >> id)) {
                    std::cout << "Invalid input. Please enter a numeric delivery ID: ";
                    std::cin.clear();
                    std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
                }
                std::cout << "Enter new status (1 for delivered, 0 for not delivered): ";
                while (!(std::cin >> status)) {
                    std::cout << "Invalid input. Please enter 1 or 0: ";
                    std::cin.clear();
                    std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
                }
                management.updateDeliveryStatus(id, status);
                break;
            }
            case 3:
                // Display all deliveries
                management.displayAllDeliveries();
                break;
            case 4: {
                int id;
                // Input delivery ID to search
                std::cout << "Enter delivery ID to search: ";
                while (!(std::cin >> id)) {
                    std::cout << "Invalid input. Please enter a numeric delivery ID: ";
                    std::cin.clear();
                    std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
                }
                management.searchDelivery(id);
                break;
            }
            case 5:
                // Exit the program
                std::cout << "Goodbye!\n";
                break;
            default:
                // Invalid menu selection
                std::cout << "Invalid selection. Please try again.\n";
        }
    } while (choice != 5);

    return 0;
}
