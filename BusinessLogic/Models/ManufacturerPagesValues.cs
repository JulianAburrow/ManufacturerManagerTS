using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace ManufacturerManagerTS.BusinessLogic.Models
{
    public class ManufacturerPagesValues
    {
        public List<Manufacturer> Manufacturers { get; set; }

        public List<ManufacturerStatus> Statuses { get; set; }

        public SelectList StatusesSelectList() =>
            new SelectList(Statuses.ToList(),
                nameof(ManufacturerStatus.StatusId),
                nameof(ManufacturerStatus.StatusName));
    }
}
