using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.CoreProcessors;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders;

public class CoreProcessorBuilder
{
    private int? _coreNumber;
    private int? _frequency;
    public CoreProcessorBuilder AddCoreNumber(int coreNumber)
    {
        _coreNumber = coreNumber;
        return this;
    }

    public CoreProcessorBuilder AddFrequency(int frequency)
    {
        _frequency = frequency;
        return this;
    }

    public CoreProcessor Build()
    {
        return new CoreProcessor(
            _coreNumber ?? throw new ArgumentNullException(nameof(_coreNumber)),
            _frequency ?? throw new ArgumentNullException(nameof(_frequency)));
    }
}