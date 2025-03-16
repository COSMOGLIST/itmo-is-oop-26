namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Ddrs;

public class Ddr : IComponent<Ddr>
{
    public Ddr(string version)
    {
        Type = version;
    }

    public string Type { get; }

    public Ddr Clone()
    {
        return new Ddr(Type);
    }
}