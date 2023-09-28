using System;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Sandbox World!");
        Console.WriteLine("This is in C#.");

        Console.WriteLine("What is your favorite color? ");
        string color = Console.ReadLine();
        Console.WriteLine($"Your color is {color}");
    }
}