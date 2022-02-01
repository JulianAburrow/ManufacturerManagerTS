using ManufacturerManagerTS.BusinessLogic.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManufacturerManagerTS.BusinessLogic.Managers.Interfaces
{
    public interface IManufacturerPagesManager
    {
        Task<IEnumerable<Manufacturer>> GetManufacturers();

        Task<Results<Manufacturer>> GetManufacturerById(int id);

        Task<bool> SaveManufacturer(Manufacturer manufacturer);

        Task<bool> UpdateManufacturer(Manufacturer manufacturer);

        Task<ManufacturerPagesValues> GetManufacturerPageDropDownValues();
    }
}
