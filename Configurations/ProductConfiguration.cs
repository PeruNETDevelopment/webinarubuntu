using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebinarUbuntu.Entities;

namespace WebinarUbuntu.Configuration;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        // nvarchar (UNICODE)
        // VARCHAR (NO UNICODE)
        builder.Property(p => p.Code)
            .HasMaxLength(20)
            .IsUnicode(false);

        builder.Property(p => p.Description)
            .HasMaxLength(200);

        builder.Property(p => p.UnitPrice)
            .HasPrecision(11,2);

        builder.HasData(new List<Product>() {
            new Product { Id = 1, Code = "0001", Description = "Xbox Series X", UnitPrice = 499},
            new Product { Id = 2, Code = "0002", Description = "PlayStation 5", UnitPrice = 630},
            new Product { Id = 3, Code = "0003", Description = "Nintendo Switch", UnitPrice = 599},
            new Product { Id = 4, Code = "0004", Description = "Wii U", UnitPrice = 150},
        });
    }
}