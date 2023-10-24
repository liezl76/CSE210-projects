using System;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;

public class Activity
{
    private List<Activity> activities = new List<Activity>();
    public void ActivityMenuDisplay()
    {
        bool isRunning = true;
        while (isRunning)
        {
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("Start breathing activity");
            Console.WriteLine("Start reflecting activity");
            Console.WriteLine("Start listing activity");
            Console.WriteLine("Quit");
            Console.WriteLine();
            Console.WriteLine("Select a choice from the menu: ");
            int choice = Int32.Parse(Console.ReadLine());

            switch(choice)
            {
                case 1:
                break;

                case 2:
                break;

                case 3:
                break;

                case 4:
                    isRunning = false;
                    break;
            }
        }
    }
    public void DisplayWelcomeMessage()
    {
        Console.WriteLine("\nWelcome to the Program!");
    }

}