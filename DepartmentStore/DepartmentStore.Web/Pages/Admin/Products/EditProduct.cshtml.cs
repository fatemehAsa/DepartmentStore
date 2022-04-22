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
    public class EditProductModel : PageModel
    {
        private IProductService _productService;

        public EditProductModel(IProductService productService)
        {
            _productService = productService;
        }

        [BindProperty]
        public Product Product { get; set; }

        public void OnGet(int id)
        {
            Product = _productService.GetProductById(id);
            var groups = _productService.GetGroupsForManageProduct();
            ViewData["Groups"] = new SelectList(groups, "Value", "Text", Product.GroupId);

            List<SelectListItem> subGroups = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "انتخاب کنید", Value = ""}
            };
            subGroups.AddRange(_productService.GetSubGroupsForManageProduct(Product.GroupId));
            string selectedSubGroup = null;
            if (Product.SubGroupId != null)
            {
                selectedSubGroup = Product.SubGroupId.ToString();
            }

            ViewData["SubGroups"] = new SelectList(subGroups, "Value", "Text", selectedSubGroup);
        }

        public IActionResult OnPost(IFormFile imgCourseUp)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            _productService.UpdateProduct(Product,imgCourseUp);

            return RedirectToPage("Index");
        }
    }
}
