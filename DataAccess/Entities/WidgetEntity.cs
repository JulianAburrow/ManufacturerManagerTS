using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManufacturerManagerTS.DataAccess.Entities
{
    [Table("Widget")]
    public class WidgetEntity : BaseEntity, IAuditableObject
    {
        [Key]
        public int WidgetId { get; set; }

        public string Name { get; set; }

        public int ManufacturerId { get; set; }

        public int? ColourId { get; set; }

        public int? ColourJustificationId { get; set; }

        public int StatusId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime Created { get; set; }

        public int CreatedById { get; set; }

        public DateTime LastUpdated { get; set; }

        public int LastUpdatedById { get; set; }

        public ManufacturerEntity Manufacturer { get; set; }

        public ColourEntity Colour { get; set; }

        public ColourJustificationEntity ColourJustification { get; set; }

        public WidgetStatusEntity Status { get; set; }

        public StaffMemberEntity StaffMemberCreated { get; set; }

        public StaffMemberEntity StaffMemberUpdated { get; set; }
    }
}
