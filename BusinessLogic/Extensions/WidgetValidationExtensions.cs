using ManufacturerManagerTS.BusinessLogic.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;

namespace ManufacturerManagerTS.BusinessLogic.Extensions
{
    public static class WidgetValidationExtensions
    {
        public static ModelStateDictionary AddModelStateValidation(this ModelStateDictionary modelStateDictionary,
            List<string> validationList)
        {
            if (validationList.Contains(PageValues.ColourJustificationValidation))
            {
                modelStateDictionary.AddModelError(PageValues.WidgetColourJustificationId, PageValues.WidgetColourJustificationMissing);
            }
            if (validationList.Contains(PageValues.WidgetDuplicateValidation))
            {
                modelStateDictionary.AddModelError(PageValues.WidgetName, PageValues.DuplicateWidget);
            }

            return modelStateDictionary;
        }
    }
}
