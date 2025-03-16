using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.CommandArguments;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Visitors;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

public class TreeListCommand : ICommand
{
    private readonly TreeListArguments _arguments;

    public TreeListCommand(TreeListArguments arguments)
    {
        _arguments = arguments;
    }

    public void Execute(Context context)
    {
        if (context.FileSystemRegime is not null)
        {
            DirectoryElementResult directoryElementResult =
                        context.FileSystemRegime.GetDirectoryElement(_arguments.Depth, context.Catalog);
            if (directoryElementResult is DirectoryElementResult.SuccessResult result)
            {
                result.Element.Accept(new VisitorWriter(_arguments.OutputMode, context.Symbols));
            }
        }
        else
        {
            context.ErrorWriter.Write("No connection");
        }
    }
}