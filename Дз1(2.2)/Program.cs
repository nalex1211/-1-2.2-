using Дз1_2._2_;
using static Дз1_2._2_.Constants;


internal class Program
{
    private static void Main(string[] args)
    {
        Console.Write("Enter team name: ");
        var team = new Team(Console.ReadLine());

        do
        {
            Console.Write("Enter position: ");

            switch (Console.ReadLine())
            {
                case Choices._Developer:
                Console.Write("Enter name: ");
                var dev = new Developer(Console.ReadLine());
                Console.Write("Enter WorkDay: ");
                dev.WorkDay = Convert.ToInt32(Console.ReadLine());
                team.AddEmployee(dev);
                break;

                case Choices._Manager:
                Console.Write("Enter name: ");
                var manager = new Manager(Console.ReadLine());
                Console.Write("Enter WorkDay: ");
                manager.WorkDay = Convert.ToInt32(Console.ReadLine());
                team.AddEmployee(manager);
                break;
            }
            Console.Write("Do you want to add a new member?(yes/no): ");

        } while (Console.ReadLine() != Choices.No);

        Console.Write("Do you want to see detailed information?(yes/no): ");
        if (Console.ReadLine() == Choices.Yes)
        {
            team.PrintDetailedInfo();
        }
        else
        {
            team.PrintInfo();
        }
    }
}