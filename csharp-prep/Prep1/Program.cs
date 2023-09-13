using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep1 World!");
        Console.WriteLine("What is your first name? ");
        Console.WriteLine("What is your last name? ");
        string firstname = Console.ReadLine();
        string lastname = Console.ReadLine();
        Console.WriteLine($"Your name is {firstname}, {firstname} {lastname}.");

    }
}