﻿public abstract class Worker
{
    private string Name;
    public string name { get => Name; }

    private string Position;
    public string position { get => Position; set => Position = value; }

    private int WorkDay;
    public int workDay { get => WorkDay; set => WorkDay = value; }

    public Worker(string Name) => this.Name = Name;

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
    public Developer(string Name) : base(Name) => position = "Developer";

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
    private Random random;
    public Manager(string Name) : base(Name) => position = "Manager";

    public override void FillWorkDay()
    {
        random = new Random();
        for (int i = 0; i < random.Next(1, 10); i++) {
            Call();
        }
        Relax();
        for (int i = 0; i < random.Next(1, 5); i++) {
            Call();
        }
    }
}

public class Team
{
    private string Name;
    private List<Worker> workers = new List<Worker>();
    public Team(string Name) => this.Name = Name;

    public void AddEmployee(Worker worker) => workers.Add(worker);

    public void PrintInfo()
    {
        Console.WriteLine($"Team name: {Name}");
        workers.ForEach(w => Console.WriteLine(w.name));
    }

    public void PrintDetailedInfo()
    {
        Console.WriteLine($"Team name: {Name}");
        workers.ForEach(w => Console.WriteLine($"Name:{w.name} - Position:{w.position} - WorkDay:{w.workDay}"));
    }
}

internal class Program
{
    private static void Main(string[] args)
    {
        string choice;
        Console.Write("Enter team name: ");
        var team = new Team(Console.ReadLine());
        do {
            Console.Write("Enter position: ");
            switch (Console.ReadLine()) {
                case "Developer":
                    Console.Write("Enter name: ");
                    var dev = new Developer(Console.ReadLine());
                    Console.Write("Enter WorkDay: ");
                    dev.workDay = Convert.ToInt32(Console.ReadLine());
                    team.AddEmployee(dev);
                    break;
                case "Manager":
                    Console.Write("Enter name: ");
                    var manager = new Manager(Console.ReadLine());
                    Console.Write("Enter WorkDay: ");
                    manager.workDay = Convert.ToInt32(Console.ReadLine());
                    team.AddEmployee(manager);
                    break;
            }
            Console.Write("Do you want to add a new member?(yes/no): ");
            choice = Console.ReadLine();
        } while (choice != "no");

        Console.Write("Do you want to see detailed information?(yes/no): ");
        choice = Console.ReadLine();
        if (choice == "yes") {
            team.PrintDetailedInfo();
        }
        else {
            team.PrintInfo();
        }
    }
}