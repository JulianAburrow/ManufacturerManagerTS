using ManufacturerManagerTS.BusinessLogic.Handlers.Interfaces;
using ManufacturerManagerTS.DataAccess.Entities;
using ManufacturerManagerTS.DataAccess.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManufacturerManagerTS.BusinessLogic.Handlers
{
    public class ColourHandler : IColourHandler
    {
        private readonly IGenericRepository<ColourEntity> _colourRepository;

        public ColourHandler(IGenericRepository<ColourEntity> colourRepository)
            => _colourRepository = colourRepository;

        public async Task<IEnumerable<ColourEntity>> GetColours() =>
            await _colourRepository.GetAll();
    }
}
