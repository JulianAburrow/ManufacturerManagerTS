using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ManufacturerManagerTS.BusinessLogic.Models
{
    public class StaffMember
    {
        public int StaffMemberId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Display(Name = "Name")]
        public string FullName => $"{FirstName} {LastName}";

        public ICollection<Manufacturer> ManufacturerCreated { get; set; }

        public ICollection<Manufacturer> ManufacturerUpdated { get; set; }

        public ICollection<Widget> WidgetCreated { get; set; }

        public ICollection<Widget> WidgetUpdated { get; set; }
    }
}
