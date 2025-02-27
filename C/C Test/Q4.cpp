#include <iostream>
#include <string>

// I wasn't sure if this was supposed to have a menu or not,
// but I ended up just hard coding everything for this one.


// Base class representing a person
class Person {
protected:
    std::string name; // Name of the person
    int age; // Age of the person

public:
    // Method to set the details of the person
    void setPersonDetails(const std::string &name, int age) {
        this->name = name;
        this->age = age;
    }

    // Method to display the details of the person
    void displayPersonDetails() const {
        std::cout << "Name: " << name << "\n"
                    << "Age: " << age << "\n";
    }
};

// Derived class representing a student
class Student : public Person {
private:
    int studentId; // ID of the student
    double grade; // Grade of the student

public:
    // Method to set the details of the student
    void setStudentDetails(int id, double grade) {
        this->studentId = id;
        this->grade = grade;
    }

    // Method to display the details of the student
    void displayStudentDetails() const {
        std::cout << "Student ID: " << studentId << "\n"
                    << "Grade: " << grade << "\n";
        // Display inherited person details
        displayPersonDetails();
    }
};

int main() {
    Student student; // Create an object of the Student class

    // Set person details
    student.setPersonDetails("Avery Hogan", 27);

    // Set student details
    student.setStudentDetails(197032007, 3.8);

    // Display student details
    student.displayStudentDetails();

    return 0;
}
