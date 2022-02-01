using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManufacturerManagerTS.DataAccess.Entities
{
    [Table("StaffMember")]
    public class StaffMemberEntity : BaseEntity
    {
        [Key]
        public int StaffMemberId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<ManufacturerEntity> ManufacturerCreated { get; set; }

        public ICollection<ManufacturerEntity> ManufacturerUpdated { get; set; }

        public ICollection<WidgetEntity> WidgetCreated { get; set; }

        public ICollection<WidgetEntity> WidgetUpdated { get; set; }
    }
}
