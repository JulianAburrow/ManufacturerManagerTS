using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManufacturerManagerTS.DataAccess.Entities
{
    [Table("WidgetStatus")]
    public class WidgetStatusEntity : BaseEntity
    {
        [Key]
        public int StatusId { get; set; }

        public string StatusName { get; set; }

        public ICollection<WidgetEntity> Widgets { get; set; }
    }
}
