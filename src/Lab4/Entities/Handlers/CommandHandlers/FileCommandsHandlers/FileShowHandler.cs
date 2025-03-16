using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.CommandArguments;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Handlers.FileShowArgumentHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Handlers.CommandHandlers.FileCommandsHandlers;

public class FileShowHandler : AbstractCommandHandler
{
    private readonly IFileShowArgumentHandler _argumentsHandler;

    public FileShowHandler(IFileShowArgumentHandler connectArgumentHandler)
    {
        _argumentsHandler = connectArgumentHandler;
    }

    public override HandlerResult Handle(IEnumerator<string> commandText)
    {
        if (commandText.Current == "show" && commandText.MoveNext())
        {
            var argumentsBuilder = new FileShowArguments.Builder();
            ArgumentHandlerResult argumentHandlerResult = _argumentsHandler.Handle(commandText, argumentsBuilder);
            if (argumentHandlerResult is ArgumentHandlerResult.ErrorResult errorResult)
            {
                return new HandlerResult.ErrorResult(errorResult.ErrorText);
            }
            else if (argumentHandlerResult is ArgumentHandlerResult.SuccessResult)
            {
                return new HandlerResult.CreatedCommandResult(new FileShowCommand(argumentsBuilder.Build()));
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