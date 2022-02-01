using ManufacturerManagerTS.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManufacturerManagerTS.DataAccess.ConfigurationClasses
{
    public class ManufacturerConfiguration : IEntityTypeConfiguration<ManufacturerEntity>
    {
        public void Configure(EntityTypeBuilder<ManufacturerEntity> builder)
        {
            builder.Property(e => e.Name)
                .IsUnicode(false);
            builder.HasMany(e => e.Widgets)
                .WithOne(e => e.Manufacturer)
                .HasForeignKey(e => e.ManufacturerId)
                .IsRequired(true);
            builder.HasOne(e => e.Status)
                .WithMany(e => e.Manufacturers)
                .HasForeignKey(e => e.StatusId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
