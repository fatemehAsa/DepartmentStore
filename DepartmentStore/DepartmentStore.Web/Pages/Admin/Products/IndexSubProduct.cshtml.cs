using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DepartmentStore.Core.DTOs.Product;
using DepartmentStore.Core.Services;
using DepartmentStore.Core.Services.Interfaces;
using DepartmentStore.DataLayer.Entities.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DepartmentStore.Web.Pages.Admin.Products
{
    public class IndexSubProductModel : PageModel
    {
        private IProductService _productService;

        public IndexSubProductModel(IProductService productService)
        {
            _productService = productService;
        }

        [BindProperty]
        public ShowSubProductForAdminViewModel ListSubProduct { get; set; }
        public void OnGet(int id, int pageId = 1, string filterSubProductTitle = "", string filterDimension = "", string filterCountryMade = "")
        {
            ViewData["ProductId"] = id;
            ListSubProduct = _productService.GetSubProductsForAdmin(id, pageId, filterSubProductTitle, filterDimension,
                filterCountryMade);
        }
    }
}
