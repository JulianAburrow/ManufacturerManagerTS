using ManufacturerManagerTS.BusinessLogic.Handlers.Interfaces;
using ManufacturerManagerTS.DataAccess.Entities;
using ManufacturerManagerTS.DataAccess.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManufacturerManagerTS.BusinessLogic.Handlers
{
    public class WidgetStatusHandler : IWidgetStatusHandler
    {
        private readonly IGenericRepository<WidgetStatusEntity> _widgetStatusRepository;

        public WidgetStatusHandler(IGenericRepository<WidgetStatusEntity> widgetStatusRepository) =>
            _widgetStatusRepository = widgetStatusRepository;

        public async Task<IEnumerable<WidgetStatusEntity>> GetWidgetStatuses() =>
            await _widgetStatusRepository.GetAll();
    }
}
