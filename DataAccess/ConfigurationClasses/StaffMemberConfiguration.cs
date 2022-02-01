﻿using ManufacturerManagerTS.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManufacturerManagerTS.DataAccess.ConfigurationClasses
{
    public class StaffMemberConfiguration : IEntityTypeConfiguration<StaffMemberEntity>
    {
        public void Configure(EntityTypeBuilder<StaffMemberEntity> builder)
        {
            builder.Property(e => e.FirstName)
                .IsUnicode(false);
            builder.Property(e => e.LastName)
                .IsUnicode(false);
            #region Manufacturer
            builder.HasMany(e => e.ManufacturerCreated)
                .WithOne(e => e.StaffMemberCreated)
                .HasForeignKey(e => e.CreatedById)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(e => e.ManufacturerUpdated)
                .WithOne(e => e.StaffMemberUpdated)
                .HasForeignKey(e => e.LastUpdatedById)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.NoAction);
            #endregion
            #region Widget
            builder.HasMany(e => e.WidgetCreated)
                .WithOne(e => e.StaffMemberCreated)
                .HasForeignKey(e => e.CreatedById)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(e => e.WidgetUpdated)
                .WithOne(e => e.StaffMemberUpdated)
                .HasForeignKey(e => e.LastUpdatedById)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.NoAction);
            #endregion
        }
    }
}
