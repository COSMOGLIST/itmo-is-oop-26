﻿using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.CommandArguments;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Handlers.FileMoveArgumentHandlers;

public class DestinationPathFileMoveArgumentHandler : AbstractFileMoveArgumentHandler
{
    public override ArgumentHandlerResult Handle(IEnumerator<string> commandText, FileMoveArguments.Builder builder)
    {
        string sourcePath = commandText.Current;
        builder.WithDestinationPath(sourcePath);
        return base.Handle(commandText, builder);
    }
}