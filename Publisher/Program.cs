using Messages;

var endpointConfiguration = new EndpointConfiguration("PolymorphicRouting.Publisher");
endpointConfiguration.EnableInstallers();
endpointConfiguration.UseSerialization<SystemJsonSerializer>();

var transport = new AzureServiceBusTransport(Environment.GetEnvironmentVariable("AzureServiceBus_ConnectionString"))
{
    Topology = TopicTopology.Single("PolymorphicRouting")
};
endpointConfiguration.UseTransport(transport);

var endpointInstance = await Endpoint.Start(endpointConfiguration);

var userCreated = new UserCreated
{
    UserId = Guid.NewGuid(),
};

await endpointInstance.Publish(userCreated);

var userCreatedFromCampaign = new UserCreatedFromCampaign()
{
    UserId = Guid.NewGuid(),
    CampaignId = Guid.NewGuid(),
};

await endpointInstance.Publish(userCreatedFromCampaign);

Console.WriteLine("Press Enter to exit...");
Console.ReadLine();

await endpointInstance.Stop();

class UserCreated : IUserCreated
{
    public Guid UserId { get; set; }
}

class UserCreatedFromCampaign : IUserCreatedFromCampaign
{
    public Guid UserId { get; set; }
    public Guid CampaignId { get; set; }
}
