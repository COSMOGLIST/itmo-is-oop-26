using System.Drawing;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.OutsideIntegrations.Displays.Drivers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.OutsideIntegrations.Displays;

public class Display : IDisplay
{
    private readonly IDriver _driver;
    private readonly Color _color;

    public Display(IDriver driver, Color color)
    {
        _driver = driver;
        _color = color;
    }

    public void SendText(string text)
    {
        _driver.Clear();
        _driver.SetColor(_color);
        _driver.Write(text);
    }
}