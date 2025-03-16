using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.CommandArguments;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Handlers.FileDeleteArgumentHandlers;

public interface IFileDeleteArgumentHandler
{
    IFileDeleteArgumentHandler SetNext(IFileDeleteArgumentHandler handler);

    ArgumentHandlerResult Handle(IEnumerator<string> commandText, FileDeleteArguments.Builder builder);
}