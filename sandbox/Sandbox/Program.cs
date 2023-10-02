using System;
using System.Diagnostics;

public class Program
{

     static void Main(string[] args)
    {
        int answer = 1;
        while(answer != 0)
        {
            Console.WriteLine("What would you like to do?");
            answer = Int32.Parse(Console.ReadLine());

            switch(answer)
            {
                case 1:
                    Console.WriteLine("You have selected 1");
                    break;
                case 2:
                    Console.WriteLine("You have selected 2");
                    break;
                case 3:
                    Console.WriteLine("You have selected 3");
                    break;
                default:
                    Console.WriteLine("You have selected more than 3");
                    break;
            }
        }
        
    }
   
}