// CQRS/Handlers/AddProductHandler.cs
using CqrsEventSourcingDemo.CQRS.Commands;
using CqrsEventSourcingDemo.EventStore;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CqrsEventSourcingDemo.CQRS.Handlers
{
    public class AddProductHandler : IRequestHandler<AddProductCommand, Unit>
    {
        private readonly IEventStore _eventStore;

        public AddProductHandler(IEventStore eventStore)
        {
            _eventStore = eventStore;
        }

        public async Task<Unit> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var evt = new ProductAddedEvent(Guid.NewGuid(), request.Name, request.Price, request.Quantity);
            await _eventStore.AppendEventAsync("product-stream", evt);

            // Log para console
            Console.WriteLine($"Produto adicionado: {evt.ProductId}, Nome: {evt.Name}, Preço: {evt.Price}, Quantidade: {evt.Quantity}");

            return Unit.Value;
        }
    }

    // Evento
    public record ProductAddedEvent(Guid ProductId, string Name, decimal Price, int Quantity);
}