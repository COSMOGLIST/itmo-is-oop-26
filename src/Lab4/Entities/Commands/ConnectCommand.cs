using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.CommandArguments;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

public class ConnectCommand : ICommand
{
    private readonly ConnectArguments _arguments;

    public ConnectCommand(ConnectArguments arguments)
    {
        _arguments = arguments;
    }

    public void Execute(Context context)
    {
        if (_arguments.FileSystemRegime == "local")
        {
           context.FileSystemRegime = new LocalFileSystem(_arguments.FileSystemPath);
        }
    }
}