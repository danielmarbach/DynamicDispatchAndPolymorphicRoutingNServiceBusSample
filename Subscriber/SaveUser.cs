using Messages;

public class SaveUser : IHandleMessages<IUserCreated>
{
    public Task Handle(IUserCreated message, IMessageHandlerContext context) {
        Console.WriteLine("SaveUser handled a UserCreated event");
        return Task.CompletedTask;
    }
}