using System;

class Program
{
    static void Main(string[] args)
    {
        //This is prep 2
        Console.Write("Enter grade: ");
        string answer = Console.ReadLine();
        int grade = int.Parse(answer);

        string letter = "";

        if(grade >= 90)
        {
            letter = "A";
        }
        else if (grade >= 80){

            letter = "B";

        }
        else if (grade >= 70){

            letter = "C";

        }
        else if (grade >= 60){

            letter = "D";

        }
        else
        {
            letter = "F";
        }
        Console.WriteLine($"Your grade is: {letter}");
        
        if (grade >= 70)
        {
            Console.WriteLine("Congratulation, you passed!");
        }
        else
        {
            Console.WriteLine("Do your best next time!");
        }
    }
}