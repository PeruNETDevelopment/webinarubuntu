using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebinarUbuntu.Entities;

namespace WebinarUbuntu.Configuration;


public class SaleConfiguration : IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> builder)
    {
        builder.Property(p => p.SaleDate)
            .HasColumnType<DateTime>("DATE");

        builder.Property(p => p.SaleNumber)
            .HasMaxLength(20)
            .IsUnicode(false);  

        builder.Property(p => p.TotalSale)
            .HasPrecision(11,2);
    }
}
