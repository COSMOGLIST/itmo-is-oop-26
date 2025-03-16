using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.CommandArguments;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

public class FileDeleteCommand : ICommand
{
    private readonly FileDeleteArguments _arguments;

    public FileDeleteCommand(FileDeleteArguments arguments)
    {
        _arguments = arguments;
    }

    public void Execute(Context context)
    {
        if (context.FileSystemRegime is not null)
        {
            context.FileSystemRegime.DeleteFile(_arguments, context.Catalog, context.ErrorWriter);
        }
        else
        {
            context.ErrorWriter.Write("No connection");
        }
    }
}