using ManufacturerManagerTS.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManufacturerManagerTS.DataAccess.ConfigurationClasses
{
    public class ColourConfiguration : IEntityTypeConfiguration<ColourEntity>
    {
        public void Configure(EntityTypeBuilder<ColourEntity> builder)
        {
            builder.Property(e => e.Name)
                .IsUnicode(false);
            builder.HasMany(e => e.Widgets)
                .WithOne(e => e.Colour)
                .IsRequired(false)
                .HasForeignKey(e => e.ColourId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
