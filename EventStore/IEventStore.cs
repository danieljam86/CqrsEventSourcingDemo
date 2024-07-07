using System.Collections.Generic;
using System.Threading.Tasks;

namespace CqrsEventSourcingDemo.EventStore
{
    public interface IEventStore
    {
        Task AppendEventAsync(string streamName, object evt);
        Task<List<object>> ReadEventsAsync(string streamName);
    }
}