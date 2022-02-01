using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManufacturerManagerTS.DataAccess.Entities
{
    [Table("Colour")]
    public class ColourEntity : BaseEntity
    {
        [Key]
        public int ColourId { get; set; }

        public string Name { get; set; }

        public ICollection<WidgetEntity> Widgets { get; set; }
    }
}
