using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dec_13_2024
{
    class Guitar
    {
        public string brand = "Fender";
        public void intro()
        {
            Console.WriteLine("This is a Guitar!");
        }
    }

    class Strat : Guitar
    {
        public string modelName = "Stratocaster";
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Strat myStrat = new Strat();
            myStrat.intro();
            Console.WriteLine("The model is a " + myStrat.brand + " " + myStrat.modelName + "!");
        }
    }
}
