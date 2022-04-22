using System;
using System.Collections.Generic;
using System.Text;
using DepartmentStore.Core.DTOs.Product;
using DepartmentStore.DataLayer.Entities.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DepartmentStore.Core.Services.Interfaces
{
    public interface IProductService
    {
        #region Product

        List<ProductGroup> GetAllProducts();
        List<CountryMade> GetAllCountries();
        int AddCountry(CountryMade made);
        List<SelectListItem> GetGroupsForManageProduct();
        List<SelectListItem> GetSubGroupsForManageProduct(int groupId);
        int AddProduct(Product product, IFormFile imgProduct);
        Product GetProductById(int productId);
        Tuple<List<ShowProductForAdminViewModel>, int> GetProductsForAdmin(int pageId = 1, string filterProductName = "");
        void UpdateProduct(Product product, IFormFile imgProduct);

        #endregion

        #region SubProduct

        ShowSubProductForAdminViewModel GetSubProductsForAdmin(int productId, int pageId = 1, string filterSubProductTitle = "", string filterDimension = "", string filterCountryMade = "");
        List<SelectListItem> GetCountryMades();
        int AddSubProduct(SubProduct subProduct, IFormFile imgUpFile);

        #endregion
    }
}
