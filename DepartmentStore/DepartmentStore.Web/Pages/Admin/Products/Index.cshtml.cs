using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DepartmentStore.Core.DTOs.Product;
using DepartmentStore.Core.Services.Interfaces;
using DepartmentStore.DataLayer.Entities.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DepartmentStore.Web.Pages.Admin.Products
{
    public class IndexModel : PageModel
    {
        private IProductService _productService;

        public IndexModel(IProductService productService)
        {
            _productService = productService;
        }


        public List<ShowProductForAdminViewModel> ListProduct { get; set; }
        public void OnGet(int pageId = 1, string filterProductName = "")
        {
            ListProduct = _productService.GetProductsForAdmin(pageId, filterProductName).Item1;
            ViewData["PageId"] = pageId;
        }
    }
}
