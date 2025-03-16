using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.OutsideIntegrations.Displays.Drivers;

public interface IDriver
{
    void Clear();
    void SetColor(Color color);
    void Write(string text);
}