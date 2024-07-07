using CqrsEventSourcingDemo.CQRS.Queries;
using CqrsEventSourcingDemo.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CqrsEventSourcingDemo.CQRS.Handlers
{
    public class GetItemHandler : IRequestHandler<GetItemQuery, Item>
    {
        public Task<Item> Handle(GetItemQuery request, CancellationToken cancellationToken)
        {
            // Lógica para obter item
            return Task.FromResult(new Item());
        }
    }
}
