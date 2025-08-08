using DevIO.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevIO.Data.Mappings;

public class SupplierMapping : IEntityTypeConfiguration<Supplier>
{
    public void Configure(EntityTypeBuilder<Supplier> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasColumnType("nvarchar(100)");

        builder.Property(x => x.Document)
            .IsRequired()
            .HasColumnType("varchar(14)");

        builder.HasOne(s => s.Address)
            .WithOne(e => e.Supplier);

        builder.HasMany(s => s.Products)
            .WithOne(p => p.Supplier)
            .HasForeignKey(p => p.SupplierId);

        builder.ToTable("Suppliers");
    }
}
