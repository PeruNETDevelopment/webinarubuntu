using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebinarUbuntu.Entities;

namespace WebinarUbuntu.Configuration;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.Property(p => p.FirstName)
            .HasMaxLength(100);

        builder.Property(p => p.LastName)
            .HasMaxLength(100);

        builder.HasData(new List<Customer> {
            new Customer{ Id = 1, FirstName = "Barack", LastName = "Obama", Age = 68},
            new Customer{ Id = 2, FirstName = "Joe", LastName = "Biden", Age = 75},
            new Customer{ Id = 3, FirstName = "Vladimir", LastName = "Putin", Age = 70},
        });
    }
}