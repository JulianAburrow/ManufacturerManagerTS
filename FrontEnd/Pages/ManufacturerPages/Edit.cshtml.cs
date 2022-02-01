using ManufacturerManagerTS.BusinessLogic.Managers.Interfaces;
using ManufacturerManagerTS.BusinessLogic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using System.Threading.Tasks;
using System.Transactions;

namespace ManufacturerManagerTS.FrontEnd.Pages.ManufacturerPages
{
    public class EditModel : PageModel
    {
        private readonly IManufacturerPagesManager _manufacturerPagesManager;
        private readonly IWidgetPagesManager _widgetPagesManager;

        public EditModel(IManufacturerPagesManager manufacturerPagesManager,
                            IWidgetPagesManager widgetPagesManager)
        {
            _manufacturerPagesManager = manufacturerPagesManager;
            _widgetPagesManager = widgetPagesManager;
        }            

        public Manufacturer Manufacturer { get; set; }

        public ManufacturerPagesValues ManufacturerPagesValues { get; set; }

        public async Task<IActionResult> OnGetAsync(int? manufacturerId)
        {
            if (manufacturerId == null)
                return NotFound();

            var result = await _manufacturerPagesManager.GetManufacturerById(manufacturerId.Value);

            if (result.HttpStatusCode == HttpStatusCode.NotFound) return NotFound();

            Manufacturer = result.Entity;

            ManufacturerPagesValues = await _manufacturerPagesManager.GetManufacturerPageDropDownValues();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? manufacturerId)
        {
            if (manufacturerId == null)
                return NotFound();

            if (!ModelState.IsValid)
                return Page();

            var results = await _manufacturerPagesManager.GetManufacturerById(manufacturerId.Value);

            if (results.HttpStatusCode == HttpStatusCode.NotFound) return NotFound();

            Manufacturer = results.Entity;

            var updated = await TryUpdateModelAsync(
                Manufacturer,
                nameof(Manufacturer),
                m => m.ManufacturerId, m => m.Name, m => m.StatusId);

            if (!updated)
            {
                ManufacturerPagesValues = await _manufacturerPagesManager.GetManufacturerPageDropDownValues();
                return Page();
            }

            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                if (Manufacturer.StatusId == ManufacturerStatus.Inactive &&
                    Manufacturer.Widgets.Count > 0)
                {
                    foreach (var widget in Manufacturer.Widgets)
                        widget.StatusId = WidgetStatus.Inactive;
                    
                }

                if (await _manufacturerPagesManager.UpdateManufacturer(Manufacturer))
                {
                    scope.Complete();
                    return RedirectToPage(PageValues.ManufacturerIndexPage);
                }
            }

            ModelState.AddModelError(PageValues.ManufacturerName, PageValues.DuplicateManufacturer);
            ManufacturerPagesValues = await _manufacturerPagesManager.GetManufacturerPageDropDownValues();
            return Page();
        }
    }
}