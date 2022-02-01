using ManufacturerManagerTS.BusinessLogic.Handlers.Interfaces;
using ManufacturerManagerTS.BusinessLogic.Models;
using ManufacturerManagerTS.DataAccess.Entities;
using ManufacturerManagerTS.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ManufacturerManagerTS.BusinessLogic.Handlers
{
    public class WidgetHandler : IWidgetHandler
    {
        private readonly IGenericRepository<WidgetEntity> _widgetRepository;

        public WidgetHandler(IGenericRepository<WidgetEntity> widgetRepository) =>
            _widgetRepository = widgetRepository;

        public async Task SaveWidget(WidgetEntity widget)
        {
            await _widgetRepository.Add(widget);
            await _widgetRepository.Save();
        }

        public async Task UpdateWidget(WidgetEntity widget) =>
            await _widgetRepository.Update(widget);

        public async Task<WidgetEntity> GetWidgetById(int id)
            => await _widgetRepository.GetAllQueryable()
            .Include(w => w.Manufacturer)
            .Include(w => w.Status)
            .Include(w => w.Colour)
            .Include(w => w.ColourJustification)
            .Include(w => w.StaffMemberCreated)
            .Include(w => w.StaffMemberUpdated)
            .FirstOrDefaultAsync(w => w.WidgetId == id);

        public async Task<IEnumerable<WidgetEntity>> GetWidgets() =>
            await _widgetRepository.GetAllQueryable()
            .Include(widget => widget.Status)
            .Include(widget => widget.Manufacturer)
            .ToListAsync();

        public async Task<bool> IsDuplicate(WidgetEntity widget)
        {
            var duplicates = (await _widgetRepository.GetWhere(w =>
                    w.Name.ToLower().Replace(" ", "") == widget.Name.ToLower().Replace(" ", "") &&
                    w.ManufacturerId == widget.ManufacturerId)).ToList();

            if (!duplicates.Any()) return false;

            return widget.WidgetId <= 0 || duplicates.Any(w => w.WidgetId != widget.WidgetId);
        }
    }
}
