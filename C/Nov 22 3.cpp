#include <iostream>
#include <string>
#include <stdexcept>

class Person {
private:
    int age;
    std::string firstName, lastName;
    std::string emailId, phoneNumber;
    std::string gender;

    // Validation helper functions
    bool isValidAge(const int& a) const {
        return (a > 0 && a < 150); // Reasonable age range
    }

    bool isValidEmail(const std::string& email) const {
        return !email.empty() && email.find('@') != std::string::npos;
    }

    bool isValidPhone(const std::string& phone) const {
        return !phone.empty() && phone.length() >= 10;
    }

public:
    Person(int a, const std::string& email, const std::string& phone, 
           const std::string& gen, const std::string& first, const std::string& last) {
        
        // Validate age
        if (!isValidAge(a)) {
            throw std::invalid_argument("Invalid age. Expected number between 1-150.");
        }
        
        // Validate email
        if (!isValidEmail(email)) {
            throw std::invalid_argument("Invalid email format. Must contain '@' symbol.");
        }

        // Validate phone
        if (!isValidPhone(phone)) {
            throw std::invalid_argument("Invalid phone number. Must be at least 10 digits.");
        }

        // Validate names
        if (first.empty() || last.empty()) {
            throw std::invalid_argument("First name and last name cannot be empty.");
        }

        // Validate gender
        if (gen.empty()) {
            throw std::invalid_argument("Gender cannot be empty.");
        }

        // If all validations pass, assign values
        age = a;
        emailId = email;
        phoneNumber = phone;
        gender = gen;
        firstName = first;
        lastName = last;
    }

    void printInfo() const {
        std::cout << "Personal Info:\n"
                  << "-------------------\n"
                  << "Name: " << firstName << " " << lastName << "\n"
                  << "Age: " << age << "\n"
                  << "Email: " << emailId << "\n"
                  << "Phone: " << phoneNumber << "\n"
                  << "Gender: " << gender << "\n"
                  << "-------------------\n";
    }
};

int main() {
    try {
        // Invalid age
        Person invalidAge(-5, "validemail@example.com", "4035551234", "Male", "Avery", "Hogan");
        invalidAge.printInfo();
    }
    catch (const std::invalid_argument& e) {
        std::cerr << "\nError: " << e.what() << std::endl;
    }

    try {
        // Invalid email
        Person invalidEmail(27, "invalidemail", "4035551234", "Male", "Avery", "Hogan");
        invalidEmail.printInfo();
    }
    catch (const std::invalid_argument& e) {
        std::cerr << "\nError: " << e.what() << std::endl;
    }

    try {
        // Invalid phone
        Person invalidPhone(27, "validemail@example.com", "123", "Male", "Avery", "Hogan");
        invalidPhone.printInfo();
    }
    catch (const std::invalid_argument& e) {
        std::cerr << "\nError: " << e.what() << std::endl;
    }

    try {
        // Empty first name
        Person emptyFirstName(27, "validemail@example.com", "4035551234", "Male", "", "Hogan");
        emptyFirstName.printInfo();
    }
    catch (const std::invalid_argument& e) {
        std::cerr << "\nError: " << e.what() << std::endl;
    }

    try {
        // Empty last name
        Person emptyLastName(27, "validemail@example.com", "4035551234", "Male", "Avery", "");
        emptyLastName.printInfo();
    }
    catch (const std::invalid_argument& e) {
        std::cerr << "\nError: " << e.what() << std::endl;
    }

    try {
        // Empty gender
        Person emptyGender(27, "validemail@example.com", "4035551234", "", "Avery", "Hogan");
        emptyGender.printInfo();
    }
    catch (const std::invalid_argument& e) {
        std::cerr << "\nError: " << e.what() << std::endl;
    }

    return 0;
}
