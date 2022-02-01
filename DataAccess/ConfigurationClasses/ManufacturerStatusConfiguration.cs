using ManufacturerManagerTS.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManufacturerManagerTS.DataAccess.ConfigurationClasses
{
    public class ManufacturerStatusConfiguration : IEntityTypeConfiguration<ManufacturerStatusEntity>
    {
        public void Configure(EntityTypeBuilder<ManufacturerStatusEntity> builder)
        {
            builder.Property(e => e.StatusName)
                .IsUnicode(false);
            builder.HasMany(e => e.Manufacturers)
                .WithOne(e => e.Status)
                .HasForeignKey(e => e.StatusId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
