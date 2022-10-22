using static Дз1_2._2_.Constants;

namespace Дз1_2._2_;

internal class Developer : Worker
{
    public Developer(string name) : base(name)
    {
        Position = Choices._Developer;
    }

    public override void FillWorkDay()
    {
        WriteCode();
        Call();
        Relax();
        WriteCode();
    }
}
