using ManufacturerManagerTS.BusinessLogic.Handlers.Interfaces;
using ManufacturerManagerTS.DataAccess.Entities;
using ManufacturerManagerTS.DataAccess.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManufacturerManagerTS.BusinessLogic.Handlers
{
    public class ColourJustificationHandler : IColourJustificationHandler
    {
        private readonly IGenericRepository<ColourJustificationEntity> _colourJustificationRepository;

        public ColourJustificationHandler(IGenericRepository<ColourJustificationEntity> colourJustificationRepository)
            => _colourJustificationRepository = colourJustificationRepository;

        public async Task<IEnumerable<ColourJustificationEntity>> GetColourJustifications()
            => await _colourJustificationRepository.GetAll();
    }
}
