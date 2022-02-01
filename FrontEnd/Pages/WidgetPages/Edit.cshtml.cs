using ManufacturerManagerTS.BusinessLogic.Extensions;
using ManufacturerManagerTS.BusinessLogic.Managers.Interfaces;
using ManufacturerManagerTS.BusinessLogic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ManufacturerManagerTS.FrontEnd.Pages.WidgetPages
{
    public class EditModel : PageModel
    {
        private readonly IWidgetPagesManager _widgetPagesManager;

        public EditModel(IWidgetPagesManager widgetPagesManager) =>
            _widgetPagesManager = widgetPagesManager;

        public Widget Widget { get; set; }

        public WidgetPagesValues WidgetPagesValues { get; set; }

        public async Task<IActionResult> OnGetAsync(int? widgetId)
        {
            if (widgetId == null) return NotFound();

            var result = await _widgetPagesManager.GetWidgetById(widgetId.Value);

            if (result.HttpStatusCode == HttpStatusCode.NotFound) return NotFound();

            Widget = result.Entity;

            WidgetPagesValues = await _widgetPagesManager.GetWidgetPagesDropDownValues();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? widgetId)
        {
            if (!ModelState.IsValid || widgetId == null)
                return Page();

            var result = await _widgetPagesManager.GetWidgetById(widgetId.Value);

            if (result.HttpStatusCode == HttpStatusCode.NotFound) return NotFound();

            Widget = result.Entity;

            var updated = await TryUpdateModelAsync(
                Widget,
                nameof(Widget),
                w => w.WidgetId,
                w => w.Name,
                w => w.ManufacturerId,
                w => w.ColourId,
                w => w.ColourJustificationId,
                w => w.StatusId);

            if (!updated)
            {
                WidgetPagesValues = await _widgetPagesManager.GetWidgetPagesDropDownValues();
                return Page();
            }

            var validationList = (await _widgetPagesManager.UpdateWidget(Widget)).ToList();

            if (validationList.Count == 0)
                return RedirectToPage(PageValues.WidgetIndexPage);

            ModelState.AddModelStateValidation(validationList);
            WidgetPagesValues = await _widgetPagesManager.GetWidgetPagesDropDownValues();
            return Page();
        }
    }
}