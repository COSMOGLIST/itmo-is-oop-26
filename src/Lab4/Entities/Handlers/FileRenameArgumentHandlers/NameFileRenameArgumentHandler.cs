using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.CommandArguments;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Handlers.FileRenameArgumentHandlers;

public class NameFileRenameArgumentHandler : AbstractFileRenameArgumentHandler
{
    public override ArgumentHandlerResult Handle(IEnumerator<string> commandText, FileRenameArguments.Builder builder)
    {
        string sourcePath = commandText.Current;
        builder.WithName(sourcePath);
        return base.Handle(commandText, builder);
    }
}