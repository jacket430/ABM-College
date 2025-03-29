#include <iostream>
using namespace std;

int main(){
    int num, backwNum = 0;
    cout << "Enter a number to flip: ";
    cin >> num;

    while (num > 0){
        int number= num % 10;
        backwNum = backwNum * 10 + number;
        num = num / 10;
    }
    cout << "Flipped number: " << backwNum << endl;
    return 0;
}




#include <iostream>
using namespace std;

int main(){
    int total = 0;
    for (int i = 1; i <= 10; i++){
        total += i;
    }
    cout << "Natural number printer 🖨️\nSum of the first 10 natural numbers: " << total << endl;
}