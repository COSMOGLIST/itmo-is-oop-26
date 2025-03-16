using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.OutsideIntegrations.Displays;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees;

public class DisplayAddressee : IAddressee
{
    private readonly IDisplay _display;

    public DisplayAddressee(IDisplay display)
    {
        _display = display;
    }

    public void SendMessage(Message message)
    {
        _display.SendText(message.MessageText.Header + '\n' + message.MessageText.Body);
    }
}