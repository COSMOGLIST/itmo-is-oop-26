using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.CommandArguments;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

public class FileShowCommand : ICommand
{
    private readonly FileShowArguments _arguments;

    public FileShowCommand(FileShowArguments arguments)
    {
        _arguments = arguments;
    }

    public void Execute(Context context)
    {
        if (context.FileSystemRegime is not null)
        {
            context.FileSystemRegime.ShowFile(_arguments, context.Catalog, context.ErrorWriter);
        }
        else
        {
            context.ErrorWriter.Write("No connection");
        }
    }
}