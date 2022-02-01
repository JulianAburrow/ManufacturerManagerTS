using ManufacturerManagerTS.BusinessLogic.Handlers.Interfaces;
using ManufacturerManagerTS.DataAccess.Entities;
using ManufacturerManagerTS.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManufacturerManagerTS.BusinessLogic.Handlers
{
    public class ManufacturerHandler : IManufacturerHandler
    {
        private readonly IGenericRepository<ManufacturerEntity> _manufacturerRepository;

        public ManufacturerHandler(IGenericRepository<ManufacturerEntity> manufacturerRepository) =>
            _manufacturerRepository = manufacturerRepository;

        public async Task SaveManufacturer(ManufacturerEntity manufacturer)
        {
            await _manufacturerRepository.Add(manufacturer);
            await _manufacturerRepository.Save();
        }

        public async Task UpdateManufacturer(ManufacturerEntity manufacturer) =>
            await _manufacturerRepository.Update(manufacturer);

        public async Task<ManufacturerEntity> GetManufacturerById(int id)
            => await _manufacturerRepository.GetAllQueryable()
            .Include(manufacturer => manufacturer.Status)
            .Include(manufacturer => manufacturer.Widgets)
            .Include(manufacturer => manufacturer.StaffMemberCreated)
            .Include(manufacturer => manufacturer.StaffMemberUpdated)
            .FirstOrDefaultAsync(manufacturer => manufacturer.ManufacturerId == id);

        public async Task<IEnumerable<ManufacturerEntity>> GetManufacturers() =>
            await _manufacturerRepository.GetAllQueryable()
                .Include(manufacturer => manufacturer.Status)
                .Include(manufacturer => manufacturer.Widgets)
                .OrderBy(manufacturer => manufacturer.Name)
                .ToListAsync();

        public async Task<bool> IsDuplicate(ManufacturerEntity manufacturer)
        {
            var duplicates = (await _manufacturerRepository
                .GetWhere(m => m.Name.ToLower().Replace(" ", "") == manufacturer.Name.ToLower().Replace(" ", ""))).ToList();

            if (!duplicates.Any())
                return false;

            return manufacturer.ManufacturerId <= 0 || duplicates.Any(m => m.ManufacturerId != manufacturer.ManufacturerId);
        }
    }
}
