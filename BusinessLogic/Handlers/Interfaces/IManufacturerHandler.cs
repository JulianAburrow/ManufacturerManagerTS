using ManufacturerManagerTS.DataAccess.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace ManufacturerManagerTS.BusinessLogic.Handlers.Interfaces
{
    public interface IManufacturerHandler
    {
        Task SaveManufacturer(ManufacturerEntity manufacturer);

        Task UpdateManufacturer(ManufacturerEntity manufacturer);

        Task<ManufacturerEntity> GetManufacturerById(int id);

        Task<IEnumerable<ManufacturerEntity>> GetManufacturers();

        Task<bool> IsDuplicate(ManufacturerEntity manufacturer);
    }
}
