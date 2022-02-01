using ManufacturerManagerTS.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManufacturerManagerTS.DataAccess.ConfigurationClasses
{
    public class WidgetConfiguration : IEntityTypeConfiguration<WidgetEntity>
    {
        public void Configure(EntityTypeBuilder<WidgetEntity> builder)
        {
            builder.Property(e => e.Name)
                .IsUnicode(false);
            builder.HasOne(e => e.Manufacturer)
                .WithMany(e => e.Widgets)
                .HasForeignKey(e => e.ManufacturerId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(e => e.Colour)
                .WithMany(e => e.Widgets)
                .HasForeignKey(e => e.ColourId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
