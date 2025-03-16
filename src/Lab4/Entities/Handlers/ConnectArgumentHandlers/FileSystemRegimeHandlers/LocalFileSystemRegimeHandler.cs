using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.CommandArguments;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Handlers.ConnectArgumentHandlers.FileSystemRegimeHandlers;

public class LocalFileSystemRegimeHandler : AbstractFileSystemRegimeHandler
{
    public override ArgumentHandlerResult Handle(IEnumerator<string> commandText, ConnectArguments.Builder builder)
    {
        if (commandText.Current == "local")
        {
            builder.WithFileSystemRegime("local");
            return new ArgumentHandlerResult.SuccessResult();
        }
        else
        {
            return base.Handle(commandText, builder);
        }
    }
}