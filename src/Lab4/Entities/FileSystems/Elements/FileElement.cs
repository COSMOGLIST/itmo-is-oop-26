using Itmo.ObjectOrientedProgramming.Lab4.Entities.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems.Elements;

public class FileElement : IElement
{
    public FileElement(string name, int depth)
    {
        Name = name;
        Depth = depth;
    }

    public string Name { get; }
    public int Depth { get; }
    public void Accept(IVisitor visitor)
    {
        visitor.VisitFileElement(this, Depth);
    }
}