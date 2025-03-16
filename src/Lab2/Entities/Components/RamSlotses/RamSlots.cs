namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.RamSlotses;

public class RamSlots : IComponent<RamSlots>
{
    public RamSlots(int numberOfSlots)
    {
        NumberOfSlots = numberOfSlots;
    }

    public int NumberOfSlots { get; }

    public RamSlots Clone()
    {
        return new RamSlots(NumberOfSlots);
    }
}