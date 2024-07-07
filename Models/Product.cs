// Models/Product.cs
using System;

namespace CqrsEventSourcingDemo.Models
{
    public class Product
    {
        public Guid ProductId { get; }
        public string Name { get; }
        public decimal Price { get; }
        public int Quantity { get; }

        public Product(Guid productId, string name, decimal price, int quantity)
        {
            ProductId = productId;
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public override string ToString()
        {
            return $"Produto: {Name}, Preço: {Price:C}, Quantidade: {Quantity}";
        }
    }
}