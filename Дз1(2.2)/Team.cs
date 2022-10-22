namespace Дз1_2._2_;

internal class Team
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
