using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Handlers.CommandHandlers;

public interface ICommandHandler
{
    ICommandHandler SetNext(ICommandHandler handler);

    HandlerResult Handle(IEnumerator<string> commandText);
}