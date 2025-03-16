using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.CommandArguments;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Handlers.FileCopyArgumentHandlers;

public abstract class AbstractFileCopyArgumentHandler : IFileCopyArgumentHandler
{
    private IFileCopyArgumentHandler? _nextHandler;

    public IFileCopyArgumentHandler SetNext(IFileCopyArgumentHandler handler)
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

    public virtual ArgumentHandlerResult Handle(IEnumerator<string> commandText, FileCopyArguments.Builder builder)
    {
        if (_nextHandler is not null && commandText.MoveNext())
        {
            return _nextHandler.Handle(commandText, builder);
        }
        else
        {
            if (commandText.MoveNext() is false)
            {
                return new ArgumentHandlerResult.SuccessResult();
            }
            else
            {
                return new ArgumentHandlerResult.ErrorResult("Incorrect input of arguments");
            }
        }
    }
}