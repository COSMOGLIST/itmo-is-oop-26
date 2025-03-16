using Itmo.ObjectOrientedProgramming.Lab3.Entities.Loggers;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees;

public class AddresseeLoggerDecorator : IAddressee
{
    private readonly IAddressee _addressee;
    private ILogger _logger;

    public AddresseeLoggerDecorator(IAddressee addressee, ILogger logger)
    {
        _addressee = addressee;
        _logger = logger;
    }

    public void SendMessage(Message message)
    {
        _logger.Log(MessageToLog(message));
        _addressee.SendMessage(message);
    }

    private string MessageToLog(Message message)
    {
        return "Message \n{\n" + message.MessageText.Header + '\n' + message.MessageText.Body + "\n}\nwas sent to " + _addressee.GetType().Name;
    }
}