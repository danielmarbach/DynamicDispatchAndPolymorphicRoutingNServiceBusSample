public class Audit : IHandleMessages<IMessage>
{
    public Task Handle(IMessage message, IMessageHandlerContext context) {
        Console.WriteLine($"Audit handled a {message.GetType()} event");
        return Task.CompletedTask;
    }
}