using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Handlers.CommandHandlers;

public abstract class AbstractCommandHandler : ICommandHandler
{
    private ICommandHandler? _nextHandler;

    public ICommandHandler SetNext(ICommandHandler handler)
    {
        if (_nextHandler is null)
        {
            _nextHandler = handler;
            return _nextHandler;
        }
        else
        {
            return _nextHandler.SetNext(handler);
        }
    }

    public virtual HandlerResult Handle(IEnumerator<string> commandText)
    {
        if (_nextHandler is not null)
        {
            return _nextHandler.Handle(commandText);
        }
        else
        {
            return new HandlerResult.ErrorResult("No such command");
        }
    }
}