﻿using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.CommandArguments;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Handlers.ConnectArgumentHandlers;

public class AbstractFlagsConnectArgumentHandler : IConnectArgumentHandler
{
    private IConnectArgumentHandler? _nextHandler;

    public IConnectArgumentHandler SetNext(IConnectArgumentHandler handler)
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

    public virtual ArgumentHandlerResult Handle(IEnumerator<string> commandText, ConnectArguments.Builder builder)
    {
        if (_nextHandler is not null)
        {
            return _nextHandler.Handle(commandText, builder);
        }
        else
        {
            return new ArgumentHandlerResult.ErrorResult("Incorrect input of arguments");
        }
    }
}