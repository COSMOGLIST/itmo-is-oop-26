using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Users;

public class User
{
    private List<UsersMessage> _allMessages = new();

    public void SendMessage(Message message)
    {
        _allMessages.Add(new UsersMessage(message));
    }

    public ReadResult ReadMessageById(int id)
    {
        return _allMessages[id].Read();
    }
}