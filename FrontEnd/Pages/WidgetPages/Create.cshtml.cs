using ManufacturerManagerTS.BusinessLogic.Extensions;
using ManufacturerManagerTS.BusinessLogic.Managers.Interfaces;
using ManufacturerManagerTS.BusinessLogic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;
using System.Threading.Tasks;

namespace ManufacturerManagerTS.FrontEnd.Pages.WidgetPages
{
    public class CreateModel : PageModel
    {
        private readonly IWidgetPagesManager _widgetPagesManager;

        public CreateModel(IWidgetPagesManager widgetPagesManager) =>
            _widgetPagesManager = widgetPagesManager;

        public Widget Widget { get; set; }

        public WidgetPagesValues WidgetPagesValues { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            WidgetPagesValues = await _widgetPagesManager.GetWidgetPagesDropDownValues();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var newWidget = new Widget();

            var updated = await TryUpdateModelAsync(
                newWidget,
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

            var validationList = (await _widgetPagesManager.SaveWidget(newWidget)).ToList();

            if (validationList.Count == 0)
                return RedirectToPage(PageValues.WidgetIndexPage);

            ModelState.AddModelStateValidation(validationList);
            WidgetPagesValues = await _widgetPagesManager.GetWidgetPagesDropDownValues();
            return Page();
        }
    }
}