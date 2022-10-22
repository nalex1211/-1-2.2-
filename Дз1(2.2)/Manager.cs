using static Дз1_2._2_.Constants;

namespace Дз1_2._2_;

internal class Manager : Worker
{
    private Random random = new Random();
    public Manager(string Name) : base(Name)
    {
        Position = Choices._Manager;
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
