using System;

class MainClass {
    public static void Main(string[] args)
    {
        fncDivofTen();
    }

    public static void fncDivofTen(){
        var start = 1;
        var end = 100;

        Console.WriteLine ("Numbers divisible by 10 up to 100:");
        
        for (var i = start; i <= end; i++) {
            if (i % 10 == 0){
                Console.WriteLine(i);
            }
        }
     }
}

