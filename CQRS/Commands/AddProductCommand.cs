// CQRS/Commands/AddProductCommand.cs
using MediatR;

namespace CqrsEventSourcingDemo.CQRS.Commands
{
    public record AddProductCommand(string Name, decimal Price, int Quantity) : IRequest<Unit>;
}