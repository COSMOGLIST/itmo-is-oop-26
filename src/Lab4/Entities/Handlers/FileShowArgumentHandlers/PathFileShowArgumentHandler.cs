using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.CommandArguments;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Handlers.FileShowArgumentHandlers;

public class PathFileShowArgumentHandler : AbstractFileShowArgumentHandler
{
    public override ArgumentHandlerResult Handle(IEnumerator<string> commandText, FileShowArguments.Builder builder)
    {
        string sourcePath = commandText.Current;
        builder.WithFilePath(sourcePath);
        return base.Handle(commandText, builder);
    }
}