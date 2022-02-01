using ManufacturerManagerTS.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManufacturerManagerTS.DataAccess.ConfigurationClasses
{
    public class WidgetStatusConfiguration : IEntityTypeConfiguration<WidgetStatusEntity>
    {
        public void Configure(EntityTypeBuilder<WidgetStatusEntity> builder)
        {
            builder.Property(e => e.StatusName)
                .IsUnicode(false);
            builder.HasMany(e => e.Widgets)
                .WithOne(e => e.Status)
                .IsRequired(true)
                .HasForeignKey(e => e.StatusId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
