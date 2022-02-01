using ManufacturerManagerTS.BusinessLogic.Managers.Interfaces;
using ManufacturerManagerTS.BusinessLogic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using System.Threading.Tasks;

namespace ManufacturerManagerTS.FrontEnd.Pages.ManufacturerPages
{
    public class DetailsModel : PageModel
    {
        private readonly IManufacturerPagesManager _manufacturerPagesManager;

        public DetailsModel(IManufacturerPagesManager manufacturerPagesManager) =>
            _manufacturerPagesManager = manufacturerPagesManager;

        public Manufacturer Manufacturer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? manufacturerId)
        {
            if (manufacturerId == null) return NotFound();

            var results = await _manufacturerPagesManager.GetManufacturerById(manufacturerId.Value);

            if (results.HttpStatusCode == HttpStatusCode.NotFound) return NotFound();

            Manufacturer = results.Entity;

            return Page();
        }
    }
}