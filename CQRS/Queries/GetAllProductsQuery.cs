// CQRS/Queries/GetAllProductsQuery.cs
using CqrsEventSourcingDemo.Models;
using MediatR;
using System.Collections.Generic;

namespace CqrsEventSourcingDemo.CQRS.Queries
{
    public record GetAllProductsQuery() : IRequest<List<Product>>;
}