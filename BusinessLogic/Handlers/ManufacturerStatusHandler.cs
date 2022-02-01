using ManufacturerManagerTS.BusinessLogic.Handlers.Interfaces;
using ManufacturerManagerTS.DataAccess.Entities;
using ManufacturerManagerTS.DataAccess.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManufacturerManagerTS.BusinessLogic.Handlers
{
    public class ManufacturerStatusHandler : IManufacturerStatusHandler
    {
        private readonly IGenericRepository<ManufacturerStatusEntity> _manufacturerStatusRepository;

        public ManufacturerStatusHandler(IGenericRepository<ManufacturerStatusEntity> manufacturerStatusRepository) =>
            _manufacturerStatusRepository = manufacturerStatusRepository;

        public async Task<IEnumerable<ManufacturerStatusEntity>> GetManufacturerStatuses() =>
            await _manufacturerStatusRepository.GetAll();
    }
}
