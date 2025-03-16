using System.Drawing;
using System.IO;
using System.Text;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.OutsideIntegrations.Displays.Drivers;

public class FileDriver : IDriver
{
    private readonly string _filePath;
    private Color _color;

    public FileDriver(string path)
    {
        _filePath = path;
    }

    public void Clear()
    {
        using var writer = new FileStream(_filePath, FileMode.Create);
    }

    public void SetColor(Color color)
    {
        _color = color;
    }

    public void Write(string text)
    {
        using var writer = new FileStream(_filePath, FileMode.Append);
        byte[] buffer = Encoding.Default.GetBytes(Crayon.Output.Rgb(_color.R, _color.G, _color.B).Text(text));
        writer.Write(buffer, 0, buffer.Length);
    }
}