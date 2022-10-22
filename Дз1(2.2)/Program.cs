public abstract class Worker
{
    public string Name { get; }

    public string Position { get; set; }

    public int WorkDay { get; set; }

    public Worker(string name)
    {
        Name = name ?? throw new ArgumentNullException(nameof(Name));
    }

    public void Call()
    {
    }

    public void WriteCode()
    {
    }

    public void Relax()
    {
    }

    public abstract void FillWorkDay();
}

public class Developer : Worker
{
    public Developer(string name) : base(name)
    {
        const string pos = "Developer";
        Position = pos;
    }

    public override void FillWorkDay()
    {
        WriteCode();
        Call();
        Relax();
        WriteCode();
    }
}

public class Manager : Worker
{
    private Random random = new Random();
    public Manager(string Name) : base(Name)
    {
        const string pos = "Manager";
        Position = pos;
    }

    public override void FillWorkDay()
    {
        for (int i = 0; i < random.Next(1, 10); i++)
        {
            Call();
        }

        Relax();

        for (int i = 0; i < random.Next(1, 5); i++) 
        {
            Call();
        }
    }
}

public class Team
{
    private string Name;
    private readonly List<Worker> workers = new List<Worker>();
    public Team(string name)
    {
        Name = name ?? throw new ArgumentNullException(nameof(Name));
    }

    public void AddEmployee(Worker worker) 
    {
        workers.Add(worker);
    } 

    public void PrintInfo()
    {
        Console.WriteLine($"Team name: {Name}");
        foreach (var worker in workers)
        {
            Console.WriteLine($"Name: {worker.Name}");
        }
    }

    public void PrintDetailedInfo()
    {
        Console.WriteLine($"Team name: {Name}");
        foreach (var worker in workers) 
        {
            Console.WriteLine($"Name:{worker.Name} - Position:{worker.Position} - Work Day:{worker.WorkDay}");
        }
    }
}

internal class Program
{
    private static void Main(string[] args)
    {
        string choice, name, position, teamName;
        Console.Write("Enter team name: ");
        teamName = Console.ReadLine() ?? throw new ArgumentNullException(nameof(teamName));
        var team = new Team(teamName);
        do {
            Console.Write("Enter position: ");
            position = Console.ReadLine() ?? throw new ArgumentNullException(nameof(position));

            switch (position) {
                case "Developer":
                    Console.Write("Enter name: ");
                    name = Console.ReadLine() ?? throw new ArgumentNullException(nameof(name)); ;
                    var dev = new Developer(name);
                    Console.Write("Enter WorkDay: ");
                    dev.WorkDay = Convert.ToInt32(Console.ReadLine());
                    team.AddEmployee(dev);
                    break;

                case "Manager":
                    Console.Write("Enter name: ");
                    name = Console.ReadLine() ?? throw new ArgumentNullException(nameof(name)); ;
                    var manager = new Manager(name);
                    Console.Write("Enter WorkDay: ");
                    manager.WorkDay = Convert.ToInt32(Console.ReadLine());
                    team.AddEmployee(manager);
                    break;
            }
            Console.Write("Do you want to add a new member?(yes/no): ");
            choice = Console.ReadLine() ?? throw new ArgumentNullException(nameof(choice)); ;
        } while (choice != "no");

        Console.Write("Do you want to see detailed information?(yes/no): ");
        choice = Console.ReadLine() ?? throw new ArgumentNullException(nameof(choice)); ;
        if (choice == "yes") {
            team.PrintDetailedInfo();
        }
        else {
            team.PrintInfo();
        }
    }
}