using CqrsEventSourcingDemo.Models;
using MediatR;

namespace CqrsEventSourcingDemo.CQRS.Queries
{
    public record GetItemQuery(Guid ItemId) : IRequest<Item>;
}
