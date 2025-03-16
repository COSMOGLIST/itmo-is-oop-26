using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.CommandArguments;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

public class FileRenameCommand : ICommand
{
    private readonly FileRenameArguments _arguments;

    public FileRenameCommand(FileRenameArguments arguments)
    {
        _arguments = arguments;
    }

    public void Execute(Context context)
    {
        if (context.FileSystemRegime is not null)
        {
            context.FileSystemRegime.RenameFile(_arguments, context.Catalog, context.ErrorWriter);
        }
        else
        {
            context.ErrorWriter.Write("No connection");
        }
    }
}