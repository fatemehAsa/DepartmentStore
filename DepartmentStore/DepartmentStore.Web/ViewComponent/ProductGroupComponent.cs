using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DepartmentStore.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DepartmentStore.Web.ViewComponent
{
    public class ProductGroupComponent:Microsoft.AspNetCore.Mvc.ViewComponent
    {
        private IProductService _productService;

        public ProductGroupComponent(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult((IViewComponentResult)View("ProductGroup", _productService.GetAllProducts()));
        }
    }
}
