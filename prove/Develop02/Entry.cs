using System;
using System.Collections.Generic;
using System.Text;

public class Entry
{
    public string _entry;
    public DateTime currentDateTime = DateTime.Now;
    public int _choice;
    public int _result;
    public string _userMood;

    public void MenuDisplay()
    {
        Console.WriteLine("\nPlease select one of the following: ");
        Console.WriteLine("1. Write");
        Console.WriteLine("2. Display");
        Console.WriteLine("3. Load");
        Console.WriteLine("4. Save");
        Console.WriteLine("5. Quit");

        Console.Write("\nEnter your choice:\t");
        _choice = Convert.ToInt32(Console.ReadLine());

        if (_choice == 1)
        {
            
        }
        else if (_choice == 2)
        {

        }
        else if (_choice == 3)
        {

        }
        else if (_choice == 4)
        {

        }
        else if (_choice == 5)
        {

        }
        else
        {
            Console.WriteLine("Invalid option. Try again");
        }

    }

}
