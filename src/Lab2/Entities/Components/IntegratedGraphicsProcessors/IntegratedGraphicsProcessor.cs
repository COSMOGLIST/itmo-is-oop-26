namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.IntegratedGraphicsProcessors;

public class IntegratedGraphicsProcessor : IComponent<IntegratedGraphicsProcessor>
{
    public IntegratedGraphicsProcessor(string modelName)
    {
        ModelName = modelName;
    }

    public string ModelName { get; }

    public IntegratedGraphicsProcessor Clone()
    {
        return new IntegratedGraphicsProcessor(ModelName);
    }
}