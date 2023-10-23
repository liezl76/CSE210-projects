using System;

class Program
{
    static void Main(string[] args)
    {
        // Assignment a1 = new Assignment("Juan Ramos", "Difference");
        // Console.WriteLine(a1.GetSummary());

        // MathAssignment a2 = new MathAssignment("Juan Ramos", "Difference", "7-12", "8-9");
        // Console.WriteLine(a2.GetSummary());
        // Console.WriteLine(a2.GetHomeworkList());

        WritingAssignment a3 = new WritingAssignment("Juan Ramos", "Chinese Story", "The Life of Pi");
        Console.WriteLine(a3.GetSummary());
        Console.WriteLine(a3.GetWritingInformation());
    }
}