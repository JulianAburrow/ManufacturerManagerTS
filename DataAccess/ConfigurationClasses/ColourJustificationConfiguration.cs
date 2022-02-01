
using ManufacturerManagerTS.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManufacturerManagerTS.DataAccess.ConfigurationClasses
{
    public class ColourJustificationConfiguration : IEntityTypeConfiguration<ColourJustificationEntity>
    {
        public void Configure(EntityTypeBuilder<ColourJustificationEntity> builder)
        {
            builder.Property(e => e.Justification)
                .IsUnicode(false);
            builder.HasMany(e => e.Widgets)
                .WithOne(e => e.ColourJustification)
                .HasForeignKey(e => e.ColourJustificationId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
