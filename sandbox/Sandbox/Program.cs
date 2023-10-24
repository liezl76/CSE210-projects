using System;

class Program

{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Develop04 World!");

        // for (int i = 5; i > 0; i--)
        // {
        //     Console.Write(i);
        //     Thread.Sleep(1000);
        //     Console.Write("\b \b");
        // }

        // 
        List<string> animationStrings = new List<string>();
        animationStrings.Add("|");
        animationStrings.Add("/");
        animationStrings.Add("-");
        animationStrings.Add("\\");
        animationStrings.Add("|");
        animationStrings.Add("/");
        animationStrings.Add("-");
        animationStrings.Add("\\");

        foreach (string s in animationStrings)
        {
            Console.Write(s);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
        
        Console.WriteLine("Done.");
    }
}