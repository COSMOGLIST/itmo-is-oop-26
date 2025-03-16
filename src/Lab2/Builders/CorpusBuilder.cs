using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Corpuses;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders;

public class CorpusBuilder
{
    private double? _maximumGraphicsCardLength;
    private double? _maximumGraphicsCardWidth;
    private List<FormFactors> _possibleFormFactorsForMatherBoard = new();
    private double? _maximumComputerCoolingSize;

    public CorpusBuilder SetMaximumGraphicsCardLength(double maximumGraphicsCardLength)
    {
        _maximumGraphicsCardLength = maximumGraphicsCardLength;
        return this;
    }

    public CorpusBuilder SetMaximumGraphicsCardWidth(double maximumGraphicsCardWidth)
    {
        _maximumGraphicsCardWidth = maximumGraphicsCardWidth;
        return this;
    }

    public CorpusBuilder SetMaximumComputerCoolingDiameter(double maximumComputerCoolingSize)
    {
        _maximumComputerCoolingSize = maximumComputerCoolingSize;
        return this;
    }

    public CorpusBuilder AddNewFormFactor(FormFactors formFactor)
    {
        _possibleFormFactorsForMatherBoard.Add(formFactor);
        return this;
    }

    public Corpus Build()
    {
        return new Corpus(
            _maximumGraphicsCardLength ?? throw new ArgumentNullException(nameof(_maximumGraphicsCardLength)),
            _maximumGraphicsCardWidth ?? throw new ArgumentNullException(nameof(_maximumGraphicsCardWidth)),
            _possibleFormFactorsForMatherBoard,
            _maximumComputerCoolingSize ?? throw new ArgumentNullException(nameof(_maximumComputerCoolingSize)));
    }
}