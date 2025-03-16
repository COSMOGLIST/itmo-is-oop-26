using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.ErrorsWarningWriters;

public class ConsoleErrorsWarningWriter : IErrorsWarningWriter
{
    public void Write(string errorText)
    {
        Console.WriteLine(errorText);
    }
}