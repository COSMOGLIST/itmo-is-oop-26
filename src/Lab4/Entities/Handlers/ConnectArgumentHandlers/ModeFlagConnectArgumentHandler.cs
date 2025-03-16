using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.CommandArguments;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Handlers.ConnectArgumentHandlers.FileSystemRegimeHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Handlers.ConnectArgumentHandlers;

public class ModeFlagConnectArgumentHandler : AbstractFlagsConnectArgumentHandler
{
    private readonly IFileSystemRegimeHandler _fileSystemRegimeHandler;

    public ModeFlagConnectArgumentHandler(IFileSystemRegimeHandler fileSystemRegimeHandler)
    {
        _fileSystemRegimeHandler = fileSystemRegimeHandler;
    }

    public override ArgumentHandlerResult Handle(IEnumerator<string> commandText, ConnectArguments.Builder builder)
    {
        if (commandText.Current == "-m" && commandText.MoveNext())
        {
            return _fileSystemRegimeHandler.Handle(commandText, builder);
        }
        else
        {
            return base.Handle(commandText, builder);
        }
    }
}