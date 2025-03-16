using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.CommandArguments;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

public class FileCopyCommand : ICommand
{
    private readonly FileCopyArguments _arguments;

    public FileCopyCommand(FileCopyArguments arguments)
    {
        _arguments = arguments;
    }

    public void Execute(Context context)
    {
        if (context.FileSystemRegime is not null)
        {
            context.FileSystemRegime.CopyFile(_arguments, context.Catalog, context.ErrorWriter);
        }
        else
        {
            context.ErrorWriter.Write("No connection");
        }
    }
}