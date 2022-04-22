using System;
using System.Collections.Generic;
using System.Text;
using DepartmentStore.DataLayer.Entities.Product;

namespace DepartmentStore.Core.DTOs.Product
{
    public class ShowProductForAdminViewModel
    {
        public int ProductId { get; set; }
        public string Title { get; set; }
        public string ImageName { get; set; }
        public int SubProductCount { get; set; }
        public DateTime CreateDate { get; set; }

    }

    public class ShowSubProductForAdminViewModel
    {
        public List<SubProduct> SubProducts { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }


    }
}
