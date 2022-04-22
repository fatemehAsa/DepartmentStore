using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DepartmentStore.Core.Services.Interfaces;
using DepartmentStore.DataLayer.Entities.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DepartmentStore.Web.Pages.Admin.Products
{
    public class CreateSubProductModel : PageModel
    {
        private IProductService _productService;

        public CreateSubProductModel(IProductService productService)
        {
            _productService = productService;
        }

        [BindProperty]
        public SubProduct SubProduct { get; set; }
        public void OnGet(int id)
        {
            SubProduct = new SubProduct();
            SubProduct.ProductId = id;
            var countryMade = _productService.GetCountryMades();
            ViewData["CountryMade"] = new SelectList(countryMade, "Value", "Text");
        }

        public IActionResult OnPost(int id, IFormFile imgSubProductUp)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            _productService.AddSubProduct(SubProduct, imgSubProductUp);
            return Redirect("/Admin/Products/IndexSubProduct/" + SubProduct.ProductId);
        }
    }
}
