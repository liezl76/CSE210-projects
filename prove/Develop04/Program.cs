using System;

class Program
{
    public void DisplayWelcomeMessage()
    {
        Console.WriteLine("\nWelcome to the Program!");
    }
    public void DisplayActivityMenu()
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
    
    static void Main(string[] args)
    {
        Program menu = new Program();
        menu.DisplayActivityMenu();
        Console.ReadLine();
    }
}