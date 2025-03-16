using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Corpuses;

public class Corpus : IComponent<Corpus>, ICorpusBuilderDirector
{
    public Corpus(double maximumGraphicsCardLength, double maximumGraphicsCardWidth, IEnumerable<FormFactors> possibleFormFactorsForMatherBoard, double maximumComputerCoolingDiameter)
    {
        MaximumGraphicsCardLength = maximumGraphicsCardLength;
        MaximumGraphicsCardWidth = maximumGraphicsCardWidth;
        PossibleFormFactorsForMatherBoard = possibleFormFactorsForMatherBoard;
        MaximumComputerCoolingDiameter = maximumComputerCoolingDiameter;
    }

    public double MaximumGraphicsCardLength { get; }
    public double MaximumGraphicsCardWidth { get; }
    public IEnumerable<FormFactors> PossibleFormFactorsForMatherBoard { get; }
    public double MaximumComputerCoolingDiameter { get; }

    public CorpusBuilder Direct(CorpusBuilder builder)
    {
        builder.SetMaximumComputerCoolingDiameter(MaximumComputerCoolingDiameter);
        builder.SetMaximumGraphicsCardLength(MaximumGraphicsCardLength);
        builder.SetMaximumGraphicsCardWidth(MaximumGraphicsCardWidth);
        foreach (FormFactors formFactor in PossibleFormFactorsForMatherBoard)
        {
            builder.AddNewFormFactor(formFactor);
        }

        return builder;
    }

    public Corpus Clone()
    {
        return new Corpus(
            MaximumGraphicsCardLength,
            MaximumGraphicsCardWidth,
            PossibleFormFactorsForMatherBoard,
            MaximumComputerCoolingDiameter);
    }
}