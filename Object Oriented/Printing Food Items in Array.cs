using System;

public class FoodThing
{
    public static void Main(string[] args)
    {
        fncFood();
    }

    public static void fncFood(){
        string [] Dishes={"Macaroni","Meatballs","Straight-Up Rat Poison"};

        foreach(var item in Dishes){
            Console.WriteLine (item);
        }
    }
}