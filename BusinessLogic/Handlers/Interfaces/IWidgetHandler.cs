using ManufacturerManagerTS.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManufacturerManagerTS.BusinessLogic.Handlers.Interfaces
{
    public interface IWidgetHandler
    {
        Task SaveWidget(WidgetEntity widget);

        Task UpdateWidget(WidgetEntity widget);

        Task<WidgetEntity> GetWidgetById(int id);

        Task<IEnumerable<WidgetEntity>> GetWidgets();

        Task<bool> IsDuplicate(WidgetEntity widget);
    }
}
