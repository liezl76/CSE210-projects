using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        int userNum = -1;
        while (userNum != 0)
        {
            Console.Write("Enter a number (0 to quit): ");

            string userResponse = Console.ReadLine();
            userNum = int.Parse(userResponse);

            // Add the number to the list if it is not 0
            if (userNum != 0)
            {
                numbers.Add(userNum);
            }
        }
        // Compute the sum
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }

        Console.Write($"The sum is {sum}");
        //Compute the average
        float average = ((float)sum) / numbers.Count;
        Console.WriteLine();
        Console.WriteLine($"The average is: {average}");

        // Find the max
        int max = numbers[0];

        foreach (int number in numbers)
        {
            if (number > max)
            {
                max = number;
            }
        }
        Console.WriteLine($"The max is: {max}");
    }
}