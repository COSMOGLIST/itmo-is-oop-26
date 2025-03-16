using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.OutsideIntegrations.Messengers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees;

public class MessengerAddressee : IAddressee
{
    private readonly IMessenger _messenger;

    public MessengerAddressee(IMessenger messenger)
    {
        _messenger = messenger;
    }

    public void SendMessage(Message message)
    {
        _messenger.SendText(message.MessageText.Header + '\n' + message.MessageText.Body);
    }
}