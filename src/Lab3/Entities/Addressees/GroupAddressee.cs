using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees;

public class GroupAddressee : IAddressee
{
    private readonly List<IAddressee> _addressees;

    public GroupAddressee(IEnumerable<IAddressee> addressees)
    {
        _addressees = addressees.ToList();
    }

    public void SendMessage(Message message)
    {
        foreach (IAddressee addressee in _addressees)
        {
            addressee.SendMessage(message);
        }
    }
}