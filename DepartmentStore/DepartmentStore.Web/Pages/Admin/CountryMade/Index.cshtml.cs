using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DepartmentStore.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DepartmentStore.Web.Pages.Admin.CountryMade
{
    public class IndexModel : PageModel
    {
        private IProductService _productService;

        public IndexModel(IProductService productService)
        {
            _productService = productService;
        }

        public List<DataLayer.Entities.Product.CountryMade> CountryMades { get; set; }

        public void OnGet()
        {
            CountryMades = _productService.GetAllCountries();
        }
    }
}
