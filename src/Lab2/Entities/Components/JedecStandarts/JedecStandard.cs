using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.JedecStandarts;

public class JedecStandard : IComponent<JedecStandard>
{
    public JedecStandard(IEnumerable<string> possibleMemoryFrequencies)
    {
        PossibleMemoryFrequencies = possibleMemoryFrequencies;
    }

    public IEnumerable<string> PossibleMemoryFrequencies { get; }

    public JedecStandard Clone()
    {
        return new JedecStandard(PossibleMemoryFrequencies);
    }
}