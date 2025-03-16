using Itmo.ObjectOrientedProgramming.Lab2.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.CoreProcessors;

public class CoreProcessor : IComponent<CoreProcessor>, ICoreProcessorBuilderDirector
{
    public CoreProcessor(int coreNumber, int frequency)
    {
        CoreNumber = coreNumber;
        Frequency = frequency;
    }

    public int CoreNumber { get; }
    public int Frequency { get; }

    public CoreProcessorBuilder Direct(CoreProcessorBuilder builder)
    {
        builder.AddFrequency(Frequency);
        builder.AddCoreNumber(CoreNumber);

        return builder;
    }

    public CoreProcessor Clone()
    {
        return new CoreProcessor(CoreNumber, Frequency);
    }
}