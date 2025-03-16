using Itmo.ObjectOrientedProgramming.Lab2.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.GraphicCards;

public class GraphicsCard : IComponent<GraphicsCard>, IGraphicsCardBuilderDirector
{
    public GraphicsCard(double length, double width, int amountOfMemory, string pciExpressVersion, int chipFrequency, int powerConsumption, int amountOfOccupiedPciPorts)
    {
        Length = length;
        Width = width;
        AmountOfMemory = amountOfMemory;
        PciExpressVersion = pciExpressVersion;
        ChipFrequency = chipFrequency;
        PowerConsumption = powerConsumption;
        AmountOfOccupiedPciPorts = amountOfOccupiedPciPorts;
    }

    public double Length { get; }
    public double Width { get; }
    public int AmountOfMemory { get; }
    public string PciExpressVersion { get; }
    public int AmountOfOccupiedPciPorts { get; }
    public int ChipFrequency { get; }
    public int PowerConsumption { get; }

    public GraphicsCardBuilder Direct(GraphicsCardBuilder builder)
    {
        builder.AddPowerConsumption(PowerConsumption);
        builder.AddLength(Length);
        builder.AddWidth(Width);
        builder.AddChipFrequency(ChipFrequency);
        builder.AddPciExpressVersion(PciExpressVersion);
        builder.AddAmountOfOccupiedPciPorts(AmountOfOccupiedPciPorts);
        builder.AddAmountOfMemory(AmountOfMemory);

        return builder;
    }

    public GraphicsCard Clone()
    {
        return new GraphicsCard(
            Length,
            Width,
            AmountOfMemory,
            PciExpressVersion,
            ChipFrequency,
            PowerConsumption,
            AmountOfOccupiedPciPorts);
    }
}