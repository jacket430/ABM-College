#include <iostream>
#include <limits>

// Currency Converter class
class CurrencyConverter {
private:
    double exchangeRateUSDToEUR;
    double exchangeRateEURToINR;
    double exchangeRateUSDtoINR;

public:
    // Constructor to initialize exchange rates
    CurrencyConverter()
        : exchangeRateUSDToEUR(0.85), exchangeRateEURToINR(89.0), exchangeRateUSDtoINR(75.0) {}

    // Convert USD to EUR
    double convertUSDToEUR(double amount) {
        return amount * exchangeRateUSDToEUR;
    }

    // Convert EUR to INR
    double convertEURToINR(double amount) {
        return amount * exchangeRateEURToINR;
    }

    // Convert USD to INR
    double convertUSDtoINR(double amount) {
        return amount * exchangeRateUSDtoINR;
    }

    // Display current exchange rates
    void displayRates() {
        std::cout << "Current Exchange Rates:\n"
                    << "USD to EUR: " << exchangeRateUSDToEUR << "\n"
                    << "EUR to INR: " << exchangeRateEURToINR << "\n"
                    << "USD to INR: " << exchangeRateUSDtoINR << "\n";
    }
};

int main() {
    CurrencyConverter converter;
    int choice;
    double amount;

    do {
        std::cout << "\n";
        std::cout << "****************************************\n";
        std::cout << "*            Currency Converter        *\n";
        std::cout << "****************************************\n";
        std::cout << "* 1) Convert USD to EUR                *\n";
        std::cout << "* 2) Convert EUR to INR                *\n";
        std::cout << "* 3) Convert USD to INR                *\n";
        std::cout << "* 4) Display current exchange rates    *\n";
        std::cout << "* 5) Exit                              *\n";
        std::cout << "****************************************\n";
        std::cout << "Enter your choice: ";
        std::cin >> choice;

        if (std::cin.fail()) {
            std::cin.clear();
            std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
            std::cout << "Invalid input. Please enter a number.\n";
            continue;
        }

        switch (choice) {
            case 1:
                std::cout << "Enter amount in USD: ";
                std::cin >> amount;
                if (!std::cin.fail()) {
                    std::cout << "Converted amount in EUR: " << converter.convertUSDToEUR(amount) << "\n";
                }
                break;
            case 2:
                std::cout << "Enter amount in EUR: ";
                std::cin >> amount;
                if (!std::cin.fail()) {
                    std::cout << "Converted amount in INR: " << converter.convertEURToINR(amount) << "\n";
                }
                break;
            case 3:
                std::cout << "Enter amount in USD: ";
                std::cin >> amount;
                if (!std::cin.fail()) {
                    std::cout << "Converted amount in INR: " << converter.convertUSDtoINR(amount) << "\n";
                }
                break;
            case 4:
                converter.displayRates();
                break;
            case 5:
                std::cout << "Exiting the program...\n";
                break;
            default:
                std::cout << "Invalid selection. Please try again.\n";
        }
    } while (choice != 5);

    return 0;
}
