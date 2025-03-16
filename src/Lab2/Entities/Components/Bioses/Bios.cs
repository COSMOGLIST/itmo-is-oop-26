using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Bioses;

public class Bios : IComponent<Bios>, IBiosBuilderDirector
{
    public Bios(string type, string version, IEnumerable<string> possibleProcessors)
    {
        Type = type;
        Version = version;
        PossibleProcessors = possibleProcessors;
    }

    public string Type { get; }
    public string Version { get; }
    public IEnumerable<string> PossibleProcessors { get; }

    public BiosBuilder Direct(BiosBuilder builder)
    {
        builder.AddType(Type);
        builder.AddVersion(Version);
        foreach (string processor in PossibleProcessors)
        {
            builder.AddPossibleProcessor(processor);
        }

        return builder;
    }

    public Bios Clone()
    {
        return new Bios(Type, Version, PossibleProcessors);
    }
}