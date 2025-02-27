#include <iostream>

class MyClass {
private:
    int privateInt;

public:
    int publicInt;

    MyClass(int priv, int pub) : privateInt(priv), publicInt(pub) {}
};

int main() {
    MyClass obj(10, 20);

    std::cout << "Public Int: " << obj.publicInt << std::endl;

    //std::cout << "Private Int: " << obj.privateInt << std::endl;

    return 0;
}
