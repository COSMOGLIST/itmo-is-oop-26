using System.Diagnostics.CodeAnalysis;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Loggers;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.OutsideIntegrations.Messengers;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Topics;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Users;
using Itmo.ObjectOrientedProgramming.Lab3.Models;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

[SuppressMessage("Test", "CA1707", Justification = "Test method naming convention")]
public class TestLab3
{
    [Fact]
    public void SendMessage_ShouldBeReceived_WhenAccessLevelIsOk()
    {
        var message = new Message(new MessageText("header", "body"), AccessLevels.LowLevel);
        var user = new User();
        ITopic topic = new Topic(
            "topic",
            new AddresseeAccessLevelControlProxy(
                new UserAddressee(user),
                AccessLevels.LowLevel));
        topic.SendMessage(message);
    }

    [Fact]
    public void SendMessage_ShouldBeReadSuccessfully_WhenReadingForTheFirstTime()
    {
        var message = new Message(new MessageText("header", "body"), AccessLevels.LowLevel);
        var user = new User();
        ITopic topic = new Topic(
            "topic",
            new AddresseeAccessLevelControlProxy(
                new UserAddressee(user),
                AccessLevels.LowLevel));
        topic.SendMessage(message);
        Assert.Equal(new ReadResult.ReadSuccess(), user.ReadMessageById(0));
    }

    [Fact]
    public void SendMessage_ShouldNotBeReadSuccessfully_WhenMessageAlreadyRead()
    {
        var message = new Message(new MessageText("header", "body"), AccessLevels.LowLevel);
        var user = new User();
        ITopic topic = new Topic(
            "topic",
            new AddresseeAccessLevelControlProxy(
                new UserAddressee(user),
                AccessLevels.LowLevel));
        topic.SendMessage(message);
        Assert.Equal(new ReadResult.ReadSuccess(), user.ReadMessageById(0));
        Assert.Equal(new ReadResult.AlreadyRead(), user.ReadMessageById(0));
    }

    [Fact]
    public void SendMessage_ShouldBeIgnored_WhenPriorityIsLow()
    {
        var message = new Message(new MessageText("header", "body"), AccessLevels.LowLevel);
        User user = Substitute.For<User>();
        ITopic topic = new Topic(
            "topic",
            new AddresseeAccessLevelControlProxy(
                new UserAddressee(user),
                AccessLevels.HighLevel));
        topic.SendMessage(message);
        user.DidNotReceive().SendMessage(message);
    }

    [Fact]
    public void LoggingAddresseeReceiving_ShouldLog_WhenMessageIsSent()
    {
        var message = new Message(new MessageText("header", "body"), AccessLevels.MiddleLevel);
        ILogger logger = Substitute.For<ILogger>();
        ITopic topic = new Topic(
            "topic",
            new AddresseeAccessLevelControlProxy(
                new AddresseeLoggerDecorator(
                new UserAddressee(
                    new User()),
                logger),
                AccessLevels.MiddleLevel));
        topic.SendMessage(message);
        logger.Received().Log("Message \n{\nheader\nbody\n}\nwas sent to UserAddressee");
    }

    [Fact]
    public void MessengerWriter_ShouldWrite_WhenMessageIsSent()
    {
        var message = new Message(new MessageText("header", "body"), AccessLevels.LowLevel);
        IMessengerWriter messengerWriter = Substitute.For<IMessengerWriter>();
        IMessenger messenger = new Messenger(messengerWriter);
        ITopic topic = new Topic(
            "topic",
            new AddresseeAccessLevelControlProxy(
                new MessengerAddressee(
                    messenger),
                AccessLevels.LowLevel));
        topic.SendMessage(message);
        messengerWriter.Received().Write("[Messenger]\nheader\nbody");
    }
}