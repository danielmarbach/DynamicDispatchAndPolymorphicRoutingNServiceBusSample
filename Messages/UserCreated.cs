using System;
using NServiceBus;

namespace Messages
{
    public interface IUserCreated : IEvent
    {
        Guid UserId { get; set; }
    }
}