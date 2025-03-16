namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.SolidStateDrives;

public interface ISolidStateDrive : IComponent<ISolidStateDrive>, ISsdBuilderDirector
{
    int MemoryVolume { get; }
    int MaximumWorkSpeed { get; }
    int PowerConsumption { get; }
}