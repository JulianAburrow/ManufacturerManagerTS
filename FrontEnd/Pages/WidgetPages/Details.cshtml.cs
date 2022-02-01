using ManufacturerManagerTS.BusinessLogic.Managers.Interfaces;
using ManufacturerManagerTS.BusinessLogic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using System.Threading.Tasks;

namespace ManufacturerManagerTS.FrontEnd.Pages.WidgetPages
{
    public class DetailsModel : PageModel
    {
        private readonly IWidgetPagesManager _widgetPagesManager;

        public DetailsModel(IWidgetPagesManager widgetPagesManager) =>
            _widgetPagesManager = widgetPagesManager;

        public Widget Widget { get; set; }

        public async Task<IActionResult> OnGetAsync(int? widgetId)
        {
            if (widgetId == null) return NotFound();

            var results = await _widgetPagesManager.GetWidgetById(widgetId.Value);

            if (results.HttpStatusCode == HttpStatusCode.NotFound) return NotFound();

            Widget = results.Entity;

            return Page();
        }
    }
}