using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.CommandArguments;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Handlers.FileCopyArgumentHandlers;

public class DestinationPathFileCopyArgumentHandler : AbstractFileCopyArgumentHandler
{
    public override ArgumentHandlerResult Handle(IEnumerator<string> commandText, FileCopyArguments.Builder builder)
    {
        string sourcePath = commandText.Current;
        builder.WithDestinationPath(sourcePath);
        return base.Handle(commandText, builder);
    }
}