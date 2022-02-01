using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace ManufacturerManagerTS.BusinessLogic.Models
{
    public class WidgetPagesValues
    {
        public List<Widget> Widgets { get; set; }

        public List<WidgetStatus> Statuses { get; set; }

        public List<Manufacturer> Manufacturers { get; set; }

        public List<Colour> Colours { get; set; }

        public List<ColourJustification> ColourJustifications { get; set; }

        public SelectList StatusesSelectList() =>
            new SelectList(Statuses.ToList(),
                nameof(WidgetStatus.StatusId),
                nameof(WidgetStatus.StatusName));

        public SelectList ManufacturerSelectList() =>
            new SelectList(Manufacturers.ToList(),
                nameof(Manufacturer.ManufacturerId),
                nameof(Manufacturer.Name));

        public SelectList ColoursSelectList() =>
            new SelectList(Colours.ToList(),
                nameof(Colour.ColourId),
                nameof(Colour.Name));

        public SelectList ColourJustificationsSelectList() =>
            new SelectList(ColourJustifications.ToList(),
                nameof(ColourJustification.ColourJustificationId),
                nameof(ColourJustification.Justification));

    }
}
