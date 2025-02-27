#include <iostream>
#include <string>

class Employee {
private:
    std::string name;
    int salary;

public:
    Employee(const std::string& empName) : name(empName), salary(1500) {}

    std::string getName() const {
        return name;
    }
    void setName(const std::string& empName) {
        name = empName;
    }

    int getSalary() const {
        return salary;
    }
    void setSalary(int empSalary) {
        salary = empSalary;
    }

    void adjustSalary() {
        if (name == "Basant") {
            salary = 1500;
        } else if (name == "Kyle") {
            salary = 1600;
        } else if (name == "Robert") {
            salary = 1700;
        }
    }
};

int main() {
    Employee emp1("Basant");
    emp1.adjustSalary();
    std::cout << "Name: " << emp1.getName() << ", Salary: " << emp1.getSalary() << std::endl;

    Employee emp2("Kyle");
    emp2.adjustSalary();
    std::cout << "Name: " << emp2.getName() << ", Salary: " << emp2.getSalary() << std::endl;

    Employee emp3("Robert");
    emp3.adjustSalary();
    std::cout << "Name: " << emp3.getName() << ", Salary: " << emp3.getSalary() << std::endl;

    return 0;
}
