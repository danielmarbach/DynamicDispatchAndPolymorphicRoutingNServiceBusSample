using Messages;

public class RecordCampaignActivity : IHandleMessages<ICampaignActivityOccurred>
{
    public Task Handle(ICampaignActivityOccurred message, IMessageHandlerContext context) {
        Console.WriteLine("RecordCampaignActivity handled a CampaignActivityOccurred event");
        return Task.CompletedTask;
    }
}