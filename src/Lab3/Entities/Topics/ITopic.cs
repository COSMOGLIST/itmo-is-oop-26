using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Topics;

public interface ITopic
{
    string Name { get; }
    void SendMessage(Message message);
}