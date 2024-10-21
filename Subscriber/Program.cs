var endpointConfiguration = new EndpointConfiguration("PolymorphicRouting.Subscriber");

endpointConfiguration.UseSerialization<SystemJsonSerializer>();

var transport = new AzureServiceBusTransport(Environment.GetEnvironmentVariable("AzureServiceBus_ConnectionString"))
{
    Topology = TopicTopology.Single("PolymorphicRouting")
};
endpointConfiguration.UseTransport(transport);

var endpointInstance = await Endpoint.Start(endpointConfiguration);

Console.WriteLine("Press Enter to exit...");
Console.ReadLine();

await endpointInstance.Stop();