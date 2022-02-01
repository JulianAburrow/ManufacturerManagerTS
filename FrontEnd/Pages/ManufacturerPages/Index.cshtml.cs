using ManufacturerManagerTS.BusinessLogic.Managers.Interfaces;
using ManufacturerManagerTS.BusinessLogic.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManufacturerManagerTS.FrontEnd.Pages.ManufacturerPages
{
    public class IndexModel : PageModel
    {
        private readonly IManufacturerPagesManager _manufacturerPagesManager;

        public IList<Manufacturer> ManufacturerList { get; set; }

        public IndexModel(IManufacturerPagesManager manufacturerPagesManager) =>
            _manufacturerPagesManager = manufacturerPagesManager;

        public async Task OnGetAsync()
            => ManufacturerList = (await _manufacturerPagesManager.GetManufacturers()).ToList();
    }
}