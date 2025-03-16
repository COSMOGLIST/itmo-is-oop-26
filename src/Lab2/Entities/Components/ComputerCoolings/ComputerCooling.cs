using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.ComputerCoolings;

public class ComputerCooling : IComponent<ComputerCooling>, IComputerCoolingBuilderDirector
{
    public ComputerCooling(double diameter, IEnumerable<string> possibleSocketType, int maximumTdp)
    {
        Diameter = diameter;
        PossibleSocketType = possibleSocketType;
        MaximumTdp = maximumTdp;
    }

    public double Diameter { get; }
    public IEnumerable<string> PossibleSocketType { get; }
    public int MaximumTdp { get; }

    public ComputerCoolingBuilder Direct(ComputerCoolingBuilder builder)
    {
        builder.SetDiameter(Diameter);
        builder.SetMaximumTdp(MaximumTdp);
        foreach (string socket in PossibleSocketType)
        {
            builder.AddPossibleSocketType(socket);
        }

        return builder;
    }

    public ComputerCooling Clone()
    {
        return new ComputerCooling(Diameter, PossibleSocketType, MaximumTdp);
    }
}