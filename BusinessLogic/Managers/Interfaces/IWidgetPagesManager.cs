using ManufacturerManagerTS.BusinessLogic.Models;
using ManufacturerManagerTS.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManufacturerManagerTS.BusinessLogic.Managers.Interfaces
{
    public interface IWidgetPagesManager
    {
        Task<IEnumerable<Widget>> GetWidgets();

        Task<Results<Widget>> GetWidgetById(int id);

        Task<IEnumerable<string>> SaveWidget(Widget widget);

        Task<IEnumerable<string>> UpdateWidget(Widget widget);

        Task<WidgetPagesValues> GetWidgetPagesDropDownValues(bool isCreate = true);

        WidgetEntity NullifyValues(WidgetEntity widgetEntity);
    }
}
