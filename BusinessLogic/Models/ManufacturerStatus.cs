using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ManufacturerManagerTS.BusinessLogic.Models
{
    public partial class ManufacturerStatus
    {
        public int StatusId { get; set; }

        [Display(Name = "Status")]
        public string StatusName { get; set; }

        public ICollection<Manufacturer> Manufacturers { get; set; }
    }

    public partial class ManufacturerStatus
    {
        public const int Active = 1;
        public const int Inactive = 2;
    }
}
