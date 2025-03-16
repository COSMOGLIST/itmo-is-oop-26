using Itmo.ObjectOrientedProgramming.Lab4.Entities.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems.Elements;

public interface IElement
{
    string Name { get; }
    int Depth { get; }
    void Accept(IVisitor visitor);
}