using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ManufacturerManagerTS.BusinessLogic.Models
{
    public partial class Widget
    {
        public int WidgetId { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(100, ErrorMessage = "{0} cannot be more than {1} characters")]
        public string Name { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "{0} is required")]
        [Display(Name = "Manufacturer")]
        public int ManufacturerId { get; set; }

        [Display(Name = "Colour")]
        public int? ColourId { get; set; }

        [Display(Name = "Justification")]
        public int? ColourJustificationId { get; set; }

        [Display(Name = "Status")]
        public int StatusId { get; set; }

        [DataType(DataType.Date)]
        public DateTime Created { get; set; }

        [Display(Name = "Created By")]
        public int CreatedById { get; set; }

        [Display(Name = "Last Updated")]
        [DataType(DataType.Date)]
        public DateTime LastUpdated { get; set; }

        [Display(Name = "Last Updated By")]
        public int LastUpdatedById { get; set; }

        [Display(Name = "Manufacturer")]
        public Manufacturer Manufacturer { get; set; }

        public Colour Colour { get; set; }

        [Display(Name = "Justification")]
        public ColourJustification ColourJustification { get; set; }

        [Display(Name = "Status")]
        public WidgetStatus Status { get; set; }

        [Display(Name = "Created By")]
        public StaffMember StaffMemberCreated { get; set; }

        [Display(Name = "Last Upcdated By")]
        public StaffMember StaffMemberUpdated { get; set; }
    }
}
