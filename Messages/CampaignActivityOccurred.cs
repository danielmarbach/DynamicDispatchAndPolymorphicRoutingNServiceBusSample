using System;
using NServiceBus;

namespace Messages
{
    public interface ICampaignActivityOccurred : IEvent
    {
        Guid CampaignId { get; set; }
    }
}