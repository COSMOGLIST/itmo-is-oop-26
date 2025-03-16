namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Sockets;

public class Socket : IComponent<Socket>
{
    public Socket(string type)
    {
        Type = type;
    }

    public string Type { get; }

    public Socket Clone()
    {
        return new Socket(Type);
    }
}