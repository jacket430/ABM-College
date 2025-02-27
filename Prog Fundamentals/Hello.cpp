#include <iostream>

using namespace std;

int main(){
    int a = 10;
    int b = 50;
    cout << "Pre swap: a = " << a << ", b = " << b << endl;
    
    int temp = a;
    a = b;
    b = temp;
    cout << "Post swap: a = " << a << ", b = " << b << endl;
}