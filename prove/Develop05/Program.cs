class Program
{
    static List<Goal> goals = new List<Goal>();
    static int score = 0;

    static void Main(string[] args)
    {
        LoadGoals(); // Load previously saved goals and score

        while (true)
        {
            Console.WriteLine("Welcome to the Eternal Quest Program!");
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("1. Create new Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Load Goals");
            Console.WriteLine("4. Record Events");
            Console.WriteLine("5. Exit\n");
            Console.WriteLine();
            Console.WriteLine("Select a choice from the menu: ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoals();
                    break;
                case "3":
                    LoadGoals();
                    break;
                case "4":
                    RecordEvents();
                    break;
                case "5":
                    SaveGoals();
                    return;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }

            Console.WriteLine();
        }
    }

    static void CreateGoal()
    {
        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();

        Console.WriteLine("Select goal type:");
        Console.WriteLine("1. Simple goal");
        Console.WriteLine("2. Eternal goal");
        Console.WriteLine("3. Checklist goal");

        string typeChoice = Console.ReadLine();
        int value = 0;
        int targetTimes = 0;
        int bonus = 0;

        switch (typeChoice)
        {
            case "1":
                Console.Write("Enter value for completing the goal: ");
                value = int.Parse(Console.ReadLine());
                SimpleGoal simpleGoal = new SimpleGoal(name, "Simple", value, 0);
                goals.Add(simpleGoal);
                break;
            case "2":
                Console.Write("Enter value for each time the goal is recorded: ");
                value = int.Parse(Console.ReadLine());
                EternalGoal eternalGoal = new EternalGoal(name, "Eternal", value, 0);
                goals.Add(eternalGoal);
                break;
            case "3":
                Console.Write("Enter value for each time the goal is recorded: ");
                value = int.Parse(Console.ReadLine());
                Console.Write("Enter target number of times the goal should be completed: ");
                targetTimes = int.Parse(Console.ReadLine());
                Console.Write("Enter bonus points for achieving the target number of times: ");
                bonus = int.Parse(Console.ReadLine());
                ChecklistGoal checklistGoal = new ChecklistGoal(name, "Checklist", value, targetTimes);
                goals.Add(checklistGoal);
                break;
            default:
                Console.WriteLine("Invalid choice");
                return;
        }

        Console.WriteLine("Goal created successfully");
    }

    static void RecordEvents()
    {
        Console.Write("Enter the name of the goal you completed: ");
        string name = Console.ReadLine();

        Goal goal = goals.Find(g => g.ToString().Contains(name, StringComparison.OrdinalIgnoreCase));

        if (goal == null)
        {
            Console.WriteLine("Goal not found");
            return;
        }

        goal.MarkCompleted();
        goal.RecordEvent();

        if (goal is ChecklistGoal checklistGoal && checklistGoal.IsCompleted())
        {
            score += checklistGoal._value + checklistGoal._bonusPoints;
        }
        else
        {
            score += goal._value;
        }

        Console.WriteLine("Event recorded successfully");
    }

    static void ListGoals()
    {
        Console.WriteLine("Goals:");

        foreach (var goal in goals)
        {
            Console.Write($"- {goal._goalName}");

            if (goal.IsCompleted())
            {
                Console.Write(" [X]");
            }
            else
            {
                Console.Write(" [ ]");
            }

            if (goal is ChecklistGoal checklistGoal && checklistGoal._desireAmount > 0)
            {
                Console.Write($" Completed {checklistGoal._currentCount}/{checklistGoal._desireAmount} times");
            }

            Console.WriteLine();
        }
    }

    static void LoadGoals()
    {
        // Load goals and score from a file
        SimpleGoal goal1 = new SimpleGoal("Run a marathon", "Simple", 1000, 0);
        EternalGoal goal2 = new EternalGoal("Read scriptures", "Eternal", 100, 0);
        ChecklistGoal goal3 = new ChecklistGoal("Learn a new language", "Checklist", 200, 5);

        goals.Add(goal1);
        goals.Add(goal2);
        goals.Add(goal3);

        score = 0;
    }

    static void SaveGoals()
    {
        // Save goals and score
        Console.WriteLine("Goals and score saved successfully");
    }
}