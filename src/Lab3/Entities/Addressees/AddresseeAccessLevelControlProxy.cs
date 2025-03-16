using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees;

public class AddresseeAccessLevelControlProxy : IAddressee
{
    private readonly IAddressee _addressee;
    private readonly AccessLevels _accessLevel;
    public AddresseeAccessLevelControlProxy(IAddressee addressee, AccessLevels accessLevel)
    {
        _addressee = addressee;
        _accessLevel = accessLevel;
    }

    public void SendMessage(Message message)
    {
        if (_accessLevel <= message.AccessLevel)
        {
            _addressee.SendMessage(message);
        }
    }
}