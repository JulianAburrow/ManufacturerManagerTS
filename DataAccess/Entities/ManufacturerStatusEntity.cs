using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManufacturerManagerTS.DataAccess.Entities
{
    [Table("ManufacturerStatus")]
    public class ManufacturerStatusEntity : BaseEntity
    {
        [Key]
        public int StatusId { get; set; }

        public string StatusName { get; set; }

        public ICollection<ManufacturerEntity> Manufacturers { get; set; }
    }
}
