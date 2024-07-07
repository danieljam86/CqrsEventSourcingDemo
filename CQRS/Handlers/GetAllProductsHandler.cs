// CQRS/Handlers/GetAllProductsHandler.cs
using CqrsEventSourcingDemo.CQRS.Queries;
using CqrsEventSourcingDemo.EventStore;
using CqrsEventSourcingDemo.Models;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CqrsEventSourcingDemo.CQRS.Handlers
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, List<Product>>
    {
        private readonly IEventStore _eventStore;

        public GetAllProductsHandler(IEventStore eventStore)
        {
            _eventStore = eventStore;
        }

        public async Task<List<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var events = await _eventStore.ReadEventsAsync("product-stream");
            var products = events
                .OfType<ProductAddedEvent>()
                .Select(e => new Product(e.ProductId, e.Name, e.Price, e.Quantity))
                .ToList();

            return products;
        }
    }
}