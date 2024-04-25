using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(P => P.Name).IsRequired().HasMaxLength(100);
            builder.Property(P => P.Description).IsRequired().HasMaxLength(180);
            builder.Property(P => P.PictureUrl).IsRequired();
            builder.Property(P => P.Price).HasColumnType("decimal(18,2)");
            builder.HasOne(b => b.ProductBrand).WithMany()
            .HasForeignKey(p => p.ProductBrandId);
            builder.HasOne(b => b.ProductType).WithMany()
            .HasForeignKey(p => p.ProductTypeId);
        }
    }
}