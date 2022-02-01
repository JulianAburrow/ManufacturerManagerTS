using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManufacturerManagerTS.DataAccess.Entities
{
    [Table("Manufacturer")]
    public class ManufacturerEntity : BaseEntity, IAuditableObject
    {
        [Key]
        public int ManufacturerId { get; set; }
        
        public string Name { get; set; }

        public int StatusId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime Created { get; set; }

        public int CreatedById { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime LastUpdated { get; set; }

        public int LastUpdatedById { get; set; }

        public ManufacturerStatusEntity Status { get; set; }

        public StaffMemberEntity StaffMemberCreated { get; set; }

        public StaffMemberEntity StaffMemberUpdated { get; set; }

        public ICollection<WidgetEntity> Widgets { get; set; }
    }
}
