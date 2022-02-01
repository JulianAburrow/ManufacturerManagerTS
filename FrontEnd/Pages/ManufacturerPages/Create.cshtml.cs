using ManufacturerManagerTS.BusinessLogic.Managers.Interfaces;
using ManufacturerManagerTS.BusinessLogic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace ManufacturerManagerTS.FrontEnd.Pages.ManufacturerPages
{
    public class CreateModel : PageModel
    {
        private readonly IManufacturerPagesManager _manufacturerPagesManager;

        public CreateModel(IManufacturerPagesManager manufacturerPagesManager) =>
            _manufacturerPagesManager = manufacturerPagesManager;

        public Manufacturer Manufacturer { get; set; }

        public ManufacturerPagesValues ManufacturerPagesValues { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            ManufacturerPagesValues = await _manufacturerPagesManager.GetManufacturerPageDropDownValues();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var newManufacturer = new Manufacturer();

            var updated = await TryUpdateModelAsync(
                newManufacturer,
                nameof(Manufacturer),
                m => m.ManufacturerId, m => m.Name, m => m.StatusId);

            if (!updated)
            {
                ManufacturerPagesValues = await _manufacturerPagesManager.GetManufacturerPageDropDownValues();
                return Page();
            }


            if (await _manufacturerPagesManager.SaveManufacturer(newManufacturer))
                return RedirectToPage(PageValues.ManufacturerIndexPage);

            ManufacturerPagesValues = await _manufacturerPagesManager.GetManufacturerPageDropDownValues();
            ModelState.AddModelError(PageValues.ManufacturerName, PageValues.DuplicateManufacturer);
            return Page();
        }
    }
}