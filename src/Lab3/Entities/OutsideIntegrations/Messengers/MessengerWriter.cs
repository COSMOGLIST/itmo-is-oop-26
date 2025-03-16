using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.OutsideIntegrations.Messengers;

public class MessengerWriter : IMessengerWriter
{
    public void Write(string text)
    {
        Console.WriteLine(text);
    }
}