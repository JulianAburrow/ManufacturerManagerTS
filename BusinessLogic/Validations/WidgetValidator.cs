using ManufacturerManagerTS.BusinessLogic.Models;
using ManufacturerManagerTS.BusinessLogic.Validations.Interfaces;
using System.Collections.Generic;

namespace ManufacturerManagerTS.BusinessLogic.Validations
{
    public class WidgetValidator : IWidgetValidator
    {
        public IEnumerable<string> ValidateWidget(Widget widget)
        {
            var results = new List<string>();

            if (widget.ColourId == ColourValues.Pink &&
                widget.ColourJustificationId == PageValues.MinusOne)
            {
                results.Add(PageValues.ColourJustificationValidation);
            }

            return results;
        }
    }
}
