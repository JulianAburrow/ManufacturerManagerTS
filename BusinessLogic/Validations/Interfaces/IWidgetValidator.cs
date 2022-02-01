using ManufacturerManagerTS.BusinessLogic.Models;
using System.Collections.Generic;

namespace ManufacturerManagerTS.BusinessLogic.Validations.Interfaces
{
    public interface IWidgetValidator
    {
        public IEnumerable<string> ValidateWidget(Widget widget);
    }
}
