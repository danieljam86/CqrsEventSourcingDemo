// EventStore/InMemoryEventStore.cs
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace CqrsEventSourcingDemo.EventStore
{
    public class InMemoryEventStore : IEventStore
    {
        private readonly ConcurrentDictionary<string, List<string>> _store = new();

        public Task AppendEventAsync(string streamName, object evt)
        {
            var jsonData = JsonSerializer.Serialize(evt);
            if (!_store.ContainsKey(streamName))
            {
                _store[streamName] = new List<string>();
            }
            _store[streamName].Add(jsonData);
            return Task.CompletedTask;
        }

        public Task<List<object>> ReadEventsAsync(string streamName)
        {
            var events = new List<object>();
            if (_store.TryGetValue(streamName, out var jsonDataList))
            {
                foreach (var jsonData in jsonDataList)
                {
                    var evt = JsonSerializer.Deserialize<object>(jsonData);
                    events.Add(evt);
                }
            }
            return Task.FromResult(events);
        }
    }
}