using ManufacturerManagerTS.BusinessLogic.Managers.Interfaces;
using ManufacturerManagerTS.BusinessLogic.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManufacturerManagerTS.FrontEnd.Pages.WidgetPages
{
    public class IndexModel : PageModel
    {
        private readonly IWidgetPagesManager _widgetPagesManager;

        public IList<Widget> WidgetList { get; set; }

        public IndexModel(IWidgetPagesManager widgetPagesManager) =>
            _widgetPagesManager = widgetPagesManager;

        public async Task OnGetAsync() =>
            WidgetList = (await _widgetPagesManager.GetWidgets()).ToList();
    }
}