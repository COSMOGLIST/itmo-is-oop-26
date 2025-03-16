using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.CommandArguments;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

public class TreeGotoCommand : ICommand
{
    private readonly TreeGotoArguments _arguments;

    public TreeGotoCommand(TreeGotoArguments arguments)
    {
        _arguments = arguments;
    }

    public void Execute(Context context)
    {
        context.Catalog = _arguments.CatalogPath;
    }
}