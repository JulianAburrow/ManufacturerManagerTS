using AutoMapper;
using ManufacturerManagerTS.BusinessLogic.Handlers.Interfaces;
using ManufacturerManagerTS.BusinessLogic.Managers.Interfaces;
using ManufacturerManagerTS.BusinessLogic.Models;
using ManufacturerManagerTS.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ManufacturerManagerTS.BusinessLogic.Managers
{
    public class ManufacturerPagesManager : IManufacturerPagesManager
    {
        private readonly IManufacturerHandler _manufacturerHandler;
        private readonly IManufacturerStatusHandler _manufacturerStatusHandler;
        private readonly IMapper _mapper;

        public ManufacturerPagesManager(IManufacturerHandler manufacturerHandler,
            IManufacturerStatusHandler manufacturerStatusHandler,
            IMapper mapper)
        {
            _manufacturerHandler = manufacturerHandler;
            _manufacturerStatusHandler = manufacturerStatusHandler;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Manufacturer>> GetManufacturers() =>
            _mapper.Map<IEnumerable<Manufacturer>>(await _manufacturerHandler.GetManufacturers());

        public async Task<Results<Manufacturer>> GetManufacturerById(int id)
        {
            var manufacturer = _mapper.Map<Manufacturer>(await _manufacturerHandler.GetManufacturerById(id));

            return manufacturer == null
                ? new Results<Manufacturer> { HttpStatusCode = HttpStatusCode.NotFound }
                : new Results<Manufacturer> { Entity = manufacturer, HttpStatusCode = HttpStatusCode.OK };
        }

        public async Task<bool> SaveManufacturer(Manufacturer manufacturer)
        {
            var manufacturerEntity = _mapper.Map<ManufacturerEntity>(manufacturer);

            if (await _manufacturerHandler.IsDuplicate(manufacturerEntity))
                return false;

            await _manufacturerHandler.SaveManufacturer(manufacturerEntity);
            return true;
        }

        public async Task<bool> UpdateManufacturer(Manufacturer manufacturer)
        {
            if (await _manufacturerHandler.IsDuplicate(_mapper.Map<ManufacturerEntity>(manufacturer)))
                return false;

            var manufacturerEntity = await _manufacturerHandler.GetManufacturerById(manufacturer.ManufacturerId);

            manufacturerEntity = _mapper.Map(manufacturer, manufacturerEntity);

            await _manufacturerHandler.UpdateManufacturer(manufacturerEntity);
            return true;
        }

        public async Task<ManufacturerPagesValues> GetManufacturerPageDropDownValues()
        {
            return new ManufacturerPagesValues
            {
                Statuses = _mapper.Map<List<ManufacturerStatus>>(await _manufacturerStatusHandler.GetManufacturerStatuses()).ToList()
            };
        }
    }
}
