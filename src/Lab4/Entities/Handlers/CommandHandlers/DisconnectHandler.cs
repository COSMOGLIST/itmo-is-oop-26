using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Handlers.CommandHandlers;

public class DisconnectHandler : AbstractCommandHandler
{
    public override HandlerResult Handle(IEnumerator<string> commandText)
    {
        if (commandText.Current == "disconnect")
        {
            return new HandlerResult.CreatedCommandResult(new DisconnectCommand());
        }
        else
        {
            return base.Handle(commandText);
        }
    }
}