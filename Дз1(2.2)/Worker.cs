namespace Дз1_2._2_;

internal abstract class Worker
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
