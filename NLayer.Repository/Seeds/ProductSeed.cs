using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Seeds
{
    internal class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product { Id = 1, CategoryID = 1, Price = 100, Stock = 20, CreatedTime = DateTime.Now, Name = "Roting" },
                new Product { Id = 2, CategoryID = 1, Price = 200, Stock = 15, CreatedTime = DateTime.Now, Name = "Faber-Castell" },
                new Product { Id = 3, CategoryID = 2, Price = 150, Stock = 30, CreatedTime = DateTime.Now, Name = "C#101" },
                new Product { Id = 4, CategoryID = 2, Price = 180, Stock = 40, CreatedTime = DateTime.Now, Name = "JAVA#101" }
            );
        }
    }
}
