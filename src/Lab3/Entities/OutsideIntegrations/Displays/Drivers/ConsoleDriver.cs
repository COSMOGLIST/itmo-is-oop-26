using System;
using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.OutsideIntegrations.Displays.Drivers;

public class ConsoleDriver : IDriver
{
    private Color _color;
    public void Clear()
    {
        Console.Clear();
    }

    public void SetColor(Color color)
    {
        _color = color;
    }

    public void Write(string text)
    {
        Console.WriteLine(Crayon.Output.Rgb(_color.R, _color.G, _color.B).Text(text));
    }
}