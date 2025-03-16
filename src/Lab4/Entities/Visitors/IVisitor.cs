using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems.Elements;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Visitors;

public interface IVisitor
{
    void VisitFileElement(IElement element, int depth);
}