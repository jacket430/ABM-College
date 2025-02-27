#include <iostream>
#include <string>

class MyName {
private:
    std::string name;

public:
    MyName() : name("Avery") {
        std::cout << "Name: " << name << std::endl;
    }

    std::string getName() const {
        return name;
    }
};

void printNameByValue(MyName myName) {
    std::cout << "Passed by value: " << myName.getName() << std::endl;
}

int main() {
    MyName myNameInstance;
    printNameByValue(myNameInstance);
    return 0;
}
