using DevIO.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevIO.Data.Mappings;

public class AddressMapping : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(a => a.Street)
            .IsRequired()
            .HasColumnType("nvarchar(200)");

        builder.Property(a => a.Number)
            .IsRequired()
            .HasColumnType("varchar(50)");

        builder.Property(a => a.AdditionalInfo)
            .HasColumnType("nvarchar(250)");

        builder.Property(a => a.PostalCode)
            .IsRequired()
            .HasColumnType("varchar(8)");

        builder.Property(a => a.District)
            .IsRequired()
            .HasColumnType("nvarchar(100)");

        builder.Property(a => a.City)
            .IsRequired()
            .HasColumnType("nvarchar(100)");

        builder.Property(a => a.State)
            .IsRequired()
            .HasColumnType("nvarchar(50)");

        builder.ToTable("Addresses");
    }
}
