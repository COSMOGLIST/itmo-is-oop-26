using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.CommandArguments;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Handlers.ConnectArgumentHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Handlers.CommandHandlers;

public class ConnectHandler : AbstractCommandHandler
{
    private readonly IConnectArgumentHandler _argumentsHandler;

    public ConnectHandler(IConnectArgumentHandler connectArgumentHandler)
    {
        _argumentsHandler = connectArgumentHandler;
    }

    public override HandlerResult Handle(IEnumerator<string> commandText)
    {
        if (commandText.Current == "connect" && commandText.MoveNext())
        {
            var argumentsBuilder = new ConnectArguments.Builder();
            ArgumentHandlerResult argumentHandlerResult = _argumentsHandler.Handle(commandText, argumentsBuilder);
            if (argumentHandlerResult is ArgumentHandlerResult.ErrorResult errorResult)
            {
                return new HandlerResult.ErrorResult(errorResult.ErrorText);
            }
            else if (argumentHandlerResult is ArgumentHandlerResult.SuccessResult)
            {
                return new HandlerResult.CreatedCommandResult(new ConnectCommand(argumentsBuilder.Build()));
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