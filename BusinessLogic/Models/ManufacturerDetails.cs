using System.Collections.Generic;

namespace ManufacturerManagerTS.BusinessLogic.Models
{
    public class ManufacturerDetails
    {
        public Manufacturer Manufacturer { get; set; }

        public List<Widget> Widgets { get; set; }
    }
}
