using ManufacturerManagerTS.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManufacturerManagerTS.BusinessLogic.Handlers.Interfaces
{
    public interface IWidgetStatusHandler
    {
        Task<IEnumerable<WidgetStatusEntity>> GetWidgetStatuses();
    }
}
