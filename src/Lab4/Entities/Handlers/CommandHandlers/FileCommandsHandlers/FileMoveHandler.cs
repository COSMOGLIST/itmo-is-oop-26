﻿using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.CommandArguments;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Handlers.FileMoveArgumentHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Handlers.CommandHandlers.FileCommandsHandlers;

public class FileMoveHandler : AbstractCommandHandler
{
    private readonly IFileMoveArgumentHandler _argumentsHandler;

    public FileMoveHandler(IFileMoveArgumentHandler connectArgumentHandler)
    {
        _argumentsHandler = connectArgumentHandler;
    }

    public override HandlerResult Handle(IEnumerator<string> commandText)
    {
        if (commandText.Current == "move" && commandText.MoveNext())
        {
            var argumentsBuilder = new FileMoveArguments.Builder();
            ArgumentHandlerResult argumentHandlerResult = _argumentsHandler.Handle(commandText, argumentsBuilder);
            if (argumentHandlerResult is ArgumentHandlerResult.ErrorResult errorResult)
            {
                return new HandlerResult.ErrorResult(errorResult.ErrorText);
            }
            else if (argumentHandlerResult is ArgumentHandlerResult.SuccessResult)
            {
                return new HandlerResult.CreatedCommandResult(new FileMoveCommand(argumentsBuilder.Build()));
            }
            else
            {
                return new HandlerResult.ErrorResult("Can't determine the type of HandlerResult");
            }
        }
        else
        {
            return base.Handle(commandText);
        }
    }
}