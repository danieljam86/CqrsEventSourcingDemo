// Program.cs
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using CqrsEventSourcingDemo.CQRS.Commands;
using CqrsEventSourcingDemo.CQRS.Handlers;
using CqrsEventSourcingDemo.EventStore;
using System;
using System.Threading.Tasks;
using CqrsEventSourcingDemo.CQRS.Queries;
using CqrsEventSourcingDemo.Models;

var services = new ServiceCollection();
services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
services.AddSingleton<IEventStore, InMemoryEventStore>();
services.AddTransient<IRequestHandler<CreateItemCommand, Unit>, CreateItemHandler>();
services.AddTransient<IRequestHandler<AddProductCommand, Unit>, AddProductHandler>();
services.AddTransient<IRequestHandler<GetAllProductsQuery, List<Product>>, GetAllProductsHandler>();


var provider = services.BuildServiceProvider();

var mediator = provider.GetRequiredService<IMediator>();

// Uso do MediatR para enviar comandos e consultas

await mediator.Send(new CreateItemCommand("Item1", 10));

// Uso do MediatR para enviar comandos e consultas
await mediator.Send(new AddProductCommand("Laptop", 1500.00m, 5));
await mediator.Send(new AddProductCommand("Smartphone", 800.00m, 10));

// Ler eventos do Event Store e exibi-los no console
var eventStore = provider.GetRequiredService<IEventStore>();
var events = await eventStore.ReadEventsAsync("item-stream");
var eventsProduct = await eventStore.ReadEventsAsync("product-stream");

Console.WriteLine("\nEventos no Event Store:");
foreach (var evt in events)
{
    Console.WriteLine(evt);
}

Console.WriteLine("\nProdutos no Catálogo:");
foreach (var evt in eventsProduct)
{
    Console.WriteLine(evt);
}
