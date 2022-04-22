using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DepartmentStore.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DepartmentStore.Web.Pages.Admin.CountryMade
{
    public class CreateCountryModel : PageModel
    {
        private IProductService _productService;

        public CreateCountryModel(IProductService productService)
        {
            _productService = productService;
        }


        [BindProperty]
        public DataLayer.Entities.Product.CountryMade CountryMade { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            int madeId = _productService.AddCountry(CountryMade);

            return RedirectToPage("Index");

        }

        
    }
}
