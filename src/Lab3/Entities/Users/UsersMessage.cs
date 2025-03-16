using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Users;

public class UsersMessage
{
    private bool _isRead;
    public UsersMessage(Message message)
     {
         Message = message;
         _isRead = false;
     }

    public Message Message { get; }

    public ReadResult Read()
    {
        if (_isRead is false)
        {
           _isRead = true;
           return new ReadResult.ReadSuccess();
        }
        else
        {
            return new ReadResult.AlreadyRead();
        }
    }
}