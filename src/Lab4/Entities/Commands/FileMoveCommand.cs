using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.CommandArguments;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

public class FileMoveCommand : ICommand
{
    private readonly FileMoveArguments _arguments;

    public FileMoveCommand(FileMoveArguments arguments)
    {
        _arguments = arguments;
    }

    public void Execute(Context context)
    {
        if (context.FileSystemRegime is not null)
        {
            context.FileSystemRegime.MoveFile(_arguments, context.Catalog, context.ErrorWriter);
        }
        else
        {
            context.ErrorWriter.Write("No connection");
        }
    }
}