using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.CommandArguments;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Handlers.FileShowArgumentHandlers;

public interface IFileShowArgumentHandler
{
    IFileShowArgumentHandler SetNext(IFileShowArgumentHandler handler);

    ArgumentHandlerResult Handle(IEnumerator<string> commandText, FileShowArguments.Builder builder);
}