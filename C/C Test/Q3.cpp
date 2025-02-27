#include <iostream>
#include <cmath>
#include <limits>

#ifndef M_PI
#define M_PI 3.14159265358979323846
#endif

class Calculator {
public:
    // Addition of two integers
    int calculate(int a, int b) {
        return a + b;
    }

    // Addition of two floating-point numbers
    double calculate(double a, double b) {
        return a + b;
    }

    // Multiplication of three integers
    int calculate(int a, int b, int c) {
        return a * b * c;
    }

    // Multiplication of three floating-point numbers
    double calculate(double a, double b, double c) {
        return a * b * c;
    }

    // Area of a circle
    double calculateCircleArea(double radius) {
        return M_PI * radius * radius;
    }

    // Area of a rectangle
    double calculateRectangleArea(double length, double width) {
        return length * width;
    }
};

int main() {
    Calculator calc;
    int choice;

    do {
    std::cout << "\n";
    std::cout << "****************************************\n";
    std::cout << "*                 Menu                 *\n";
    std::cout << "****************************************\n";
    std::cout << "* 1) Add two numbers                   *\n";
    std::cout << "* 2) Multiply three numbers            *\n";
    std::cout << "* 3) Calculate the area of a circle    *\n";
    std::cout << "* 4) Calculate the area of a rectangle *\n";
    std::cout << "* 5) Exit                              *\n";
    std::cout << "****************************************\n";
    std::cout << "Enter your choice: ";
    std::cin >> choice;

        if (std::cin.fail()) {
            std::cin.clear();
            std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
            std::cout << "Invalid. Please enter a number.\n";
            continue;
        }

        switch (choice) {
            case 1: {
                std::cout << "Enter two numbers: ";
                double a, b;
                std::cin >> a >> b;
                if (std::cin.fail()) {
                    std::cin.clear();
                    std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
                    std::cout << "Invalid. Please enter numbers.\n";
                } else {
                    std::cout << "Result: " << calc.calculate(a, b) << "\n";
                }
                break;
            }
            case 2: {
                std::cout << "Enter three numbers (int or double): ";
                double a, b, c;
                std::cin >> a >> b >> c;
                if (std::cin.fail()) {
                    std::cin.clear();
                    std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
                    std::cout << "Invalid. Please enter numbers.\n";
                } else {
                    std::cout << "Result: " << calc.calculate(a, b, c) << "\n";
                }
                break;
            }
            case 3: {
                std::cout << "Enter the radius of the circle: ";
                double radius;
                std::cin >> radius;
                if (std::cin.fail()) {
                    std::cin.clear();
                    std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
                    std::cout << "Invalid. Please enter a number.\n";
                } else {
                    std::cout << "Area of the circle: " << calc.calculateCircleArea(radius) << "\n";
                }
                break;
            }
            case 4: {
                std::cout << "Enter length and width of rectangle: ";
                double length, width;
                std::cin >> length >> width;
                if (std::cin.fail()) {
                    std::cin.clear();
                    std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
                    std::cout << "Invalid. Please enter numbers.\n";
                } else {
                    std::cout << "Area of the rectangle: " << calc.calculateRectangleArea(length, width) << "\n";
                }
                break;
            }
            case 5:
                std::cout << "Exiting...\n";
                break;
            default:
                std::cout << "Invalid. Please try again.\n";
        }
    } while (choice != 5);

    return 0;
}
