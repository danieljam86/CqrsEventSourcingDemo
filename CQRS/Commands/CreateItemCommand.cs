using MediatR;


namespace CqrsEventSourcingDemo.CQRS.Commands
{
    public record CreateItemCommand(string Name, int Quantity) : IRequest<Unit>;
}
