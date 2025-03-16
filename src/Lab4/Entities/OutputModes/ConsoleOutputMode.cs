using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.OutputModes;

public class ConsoleOutputMode : IOutputMode
{
    public void Write(string text)
    {
        Console.WriteLine(text);
    }
}