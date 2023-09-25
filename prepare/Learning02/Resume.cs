using System;

public class Resume
{
    public string _name;

    public List<Job> _jobs = new List<Job>();

    public void DisplayResumeDetails()
    {
        Console.WriteLine($"\nName: {_name}");
        Console.WriteLine("Jobs:");

        foreach (Job job in _jobs)
        {
            job.DisplayDetails(); //calls the DisplayDetails method on each job
        }
    }
}