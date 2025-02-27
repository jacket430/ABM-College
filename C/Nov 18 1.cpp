#include <iostream>
using namespace std;

voice welcomeMe(string name){
    cout << "Hello, " << name << "!" << endl;
}

int main(){
    string name="Avery Hogan";
    welcomeMe(name);
    return 0;
}