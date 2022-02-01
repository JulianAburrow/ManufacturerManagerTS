using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ManufacturerManagerTS.BusinessLogic.Models
{
    public class Manufacturer
    {
        public int ManufacturerId { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(100, ErrorMessage = "{0} cannot be more than {1} characters")]
        public string Name { get; set; }

        [Display(Name = "Status")]
        public int StatusId { get; set; }

        [DataType(DataType.Date)]
        public DateTime Created { get; set; }

        public int CreatedById { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Last Updated")]
        public DateTime LastUpdated { get; set; }

        public int LastUpdatedById { get; set; }

        public ManufacturerStatus Status { get; set; }

        public StaffMember StaffMemberCreated { get; set; }

        public StaffMember StaffMemberUpdated { get; set; }

        public ICollection<Widget> Widgets { get; set; }
    }
}
