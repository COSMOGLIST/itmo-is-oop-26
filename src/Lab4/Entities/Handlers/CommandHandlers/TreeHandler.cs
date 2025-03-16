using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Handlers.CommandHandlers;

public class TreeHandler : AbstractCommandHandler
{
    private readonly ICommandHandler _argumentsHandler;

    public TreeHandler(ICommandHandler commandsHandler)
    {
        _argumentsHandler = commandsHandler;
    }

    public override HandlerResult Handle(IEnumerator<string> commandText)
    {
        if (commandText.Current == "tree" && commandText.MoveNext())
        {
            return _argumentsHandler.Handle(commandText);
        }
        else
        {
            return base.Handle(commandText);
        }
    }
}