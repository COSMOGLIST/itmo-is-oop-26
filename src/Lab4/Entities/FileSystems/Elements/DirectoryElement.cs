using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems.Elements;

public class DirectoryElement : IElement
{
    private readonly IEnumerable<IElement> _fileElements;
    public DirectoryElement(string name, IEnumerable<IElement> fileElements, int depth)
    {
        Name = name;
        _fileElements = fileElements;
        Depth = depth;
    }

    public string Name { get; }
    public int Depth { get; }

    public void Accept(IVisitor visitor)
    {
        visitor.VisitFileElement(this, Depth);
        foreach (IElement fileElement in _fileElements)
        {
            fileElement.Accept(visitor);
        }
    }
}