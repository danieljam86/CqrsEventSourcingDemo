using CqrsEventSourcingDemo.CQRS.Commands;
using CqrsEventSourcingDemo.EventStore;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CqrsEventSourcingDemo.CQRS.Handlers
{
    public class CreateItemHandler : IRequestHandler<CreateItemCommand, Unit>
    {
        private readonly IEventStore _eventStore;

        public CreateItemHandler(IEventStore eventStore)
        {
            _eventStore = eventStore;
        }

        public async Task<Unit> Handle(CreateItemCommand request, CancellationToken cancellationToken)
        {
            var evt = new ItemCreatedEvent(Guid.NewGuid(), request.Name, request.Quantity);
            await _eventStore.AppendEventAsync("item-stream", evt);

            // Log para console
            Console.WriteLine($"Evento criado: {evt.ItemId}, Nome: {evt.Name}, Quantidade: {evt.Quantity}");

            return Unit.Value;
        }
    }

    // Eventos
    public record ItemCreatedEvent(Guid ItemId, string Name, int Quantity);
}