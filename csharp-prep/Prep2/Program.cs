using System;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        //This is prep 2
        Console.Write("Enter grade: ");
        string valueFromUser = Console.ReadLine();

        int grade = int.Parse(valueFromUser);

        if(grade >= 90)
        {
            Console.WriteLine("A");
            Console.WriteLine("Congratulations!, You Pass.");
        }
        else if (grade >= 80){

            Console.WriteLine("B");
            Console.WriteLine("Congratulations!, You Pass.");

        }
        else if (grade >= 70){

            Console.WriteLine("C");
            Console.WriteLine("Congratulations!, You Pass.");

        }
        else if (grade >= 60){

            Console.WriteLine("D");
            Console.WriteLine("Sorry, You Failed.");

        }
        else if (grade < 60)
        { 

            Console.WriteLine("F");
            Console.WriteLine("Sorry, You Failed");

        }
        else
        {
            Console.WriteLine("Sorry, You Failed");
        }
    }
}