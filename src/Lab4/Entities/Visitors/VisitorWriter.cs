using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems.Elements;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.OutputModes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Visitors;

public class VisitorWriter : IVisitor
{
    private readonly IOutputMode _outputMode;
    private readonly Symbols _symbols;
    public VisitorWriter(IOutputMode outputMode, Symbols symbols)
    {
        _outputMode = outputMode;
        _symbols = symbols;
    }

    public void VisitFileElement(IElement element, int depth)
    {
        _outputMode.Write(string.Join(string.Empty, Enumerable.Repeat(_symbols.IndentSymbol, depth)) + element.Name);
    }
}