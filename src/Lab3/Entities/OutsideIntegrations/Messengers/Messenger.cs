namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.OutsideIntegrations.Messengers;

public class Messenger : IMessenger
{
    private readonly IMessengerWriter _writer;

    public Messenger(IMessengerWriter messengerWriter)
    {
        _writer = messengerWriter;
    }

    public void SendText(string text)
    {
        _writer.Write("[Messenger]\n" + text);
    }
}