using System;

public class Program
{
    static void Main()
    {
        Person person1 = new Person();
        person1.Name = "Avery";
        person1.Age = 27;

        Person person2 = new Person();
        person2.Name = "Ethan";
        person2.Age = 38;

        Person person3 = new Person();
        person3.Name = "Hila";
        person3.Age = 36;

        Person person4 = new Person();
        person4.Name = "Dan";
        person4.Age = 39;

        Console.WriteLine(person1.Name + " is " + person1.Age + " years old.");
        Console.WriteLine(person2.Name + " is " + person2.Age + " years old.");        
        Console.WriteLine(person3.Name + " is " + person3.Age + " years old.");
        Console.WriteLine(person4.Name + " is " + person4.Age + " years old.");

    }
}

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
}