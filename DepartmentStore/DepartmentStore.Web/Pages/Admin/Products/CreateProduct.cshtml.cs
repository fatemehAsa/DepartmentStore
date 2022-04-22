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
    public class CreateProductModel : PageModel
    {
        private IProductService _productService;

        public CreateProductModel(IProductService productService)
        {
            _productService = productService;
        }

        [BindProperty]
        public Product Product { get; set; }
        public void OnGet()
        {
            var groups= _productService.GetGroupsForManageProduct();
            ViewData["Groups"] = new SelectList(groups, "Value", "Text");

            var subGroups = _productService.GetSubGroupsForManageProduct(int.Parse(groups.First().Value));
            ViewData["SubGroups"] = new SelectList(subGroups, "Value", "Text");
        }

        public IActionResult OnPost(IFormFile imgProductUp)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _productService.AddProduct(Product, imgProductUp);

            return RedirectToPage("Index");
        }
    }
} 
