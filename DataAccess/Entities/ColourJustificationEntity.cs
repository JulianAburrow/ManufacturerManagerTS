using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManufacturerManagerTS.DataAccess.Entities
{
    [Table("ColourJustification")]
    public class ColourJustificationEntity : BaseEntity
    {
        [Key]
        public int ColourJustificationId { get; set; }

        public string Justification { get; set; }

        public ICollection<WidgetEntity> Widgets { get; set; }
    }
}
