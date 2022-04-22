using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DepartmentStore.Core.Convertors;
using DepartmentStore.Core.DTOs.Product;
using DepartmentStore.Core.Generator;
using DepartmentStore.Core.Security;
using DepartmentStore.Core.Services.Interfaces;
using DepartmentStore.DataLayer.Context;
using DepartmentStore.DataLayer.Entities.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DepartmentStore.Core.Services
{
    public class ProductService : IProductService
    {
        private DepartmentStoreContext _context;

        public ProductService(DepartmentStoreContext context)
        {
            _context = context;
        }

        public List<ProductGroup> GetAllProducts()
        {
            return _context.ProductGroups.ToList();
        }

        public List<CountryMade> GetAllCountries()
        {
            return _context.CountryMades.ToList();
        }

        public int AddCountry(CountryMade made)
        {
            _context.CountryMades.Add(made);
            _context.SaveChanges();
            return made.MadeId;
        }


        public List<SelectListItem> GetGroupsForManageProduct()
        {
            return _context.ProductGroups.Where(g => g.ParentId == null)
                .Select(g => new SelectListItem()
                {
                    Value = g.GroupId.ToString(),
                    Text = g.GroupTitle
                }).ToList();
        }

        public List<SelectListItem> GetSubGroupsForManageProduct(int groupId)
        {
            return _context.ProductGroups.Where(g => g.ParentId == groupId)
                .Select(g => new SelectListItem()
                {
                    Value = g.GroupId.ToString(),
                    Text = g.GroupTitle
                }).ToList();
        }

        public int AddProduct(Product product, IFormFile imgProduct)
        {
            product.ProductImageName = "no-photo.jpg";
            if (imgProduct != null && imgProduct.IsImage())
            {
                product.ProductImageName = NameGenerator.GenerateUniqCode() + Path.GetExtension(imgProduct.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Product/image",
                    product.ProductImageName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imgProduct.CopyTo(stream);
                }

                ImageConvertor imgResizer = new ImageConvertor();
                string thumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Product/thumb",
                    product.ProductImageName);

                imgResizer.Image_resize(imagePath, thumbPath, 150);

            }

            _context.Add(product);
            _context.SaveChanges();
            return product.ProductId;
        }

        public Product GetProductById(int productId)
        {
            return _context.Products.Find(productId);
        }

        public Tuple<List<ShowProductForAdminViewModel>, int> GetProductsForAdmin(int pageId = 1, string filterProductName = "")
        {
            IQueryable<Product> result = _context.Products;

            if (!string.IsNullOrEmpty(filterProductName))
            {
                result = result.Where(p => p.ProductTitle.Contains(filterProductName));
            }

            int take = 5;
            int skip = (pageId - 1) * take;
            int pageCount = result.Select(p => new ShowProductForAdminViewModel()
            {
                ImageName = p.ProductImageName,
                ProductId = p.ProductId,
                SubProductCount = p.SubProducts.Count,
                Title = p.ProductTitle,
                CreateDate = p.CreateDate
            }).Count() / take;

            if ((pageCount % 2) != 0 || (pageCount % 2) == 0)
            {
                pageCount += 1;
            }

            var query = result.Select(p => new ShowProductForAdminViewModel()
            {
                ImageName = p.ProductImageName,
                ProductId = p.ProductId,
                SubProductCount = p.SubProducts.Count,
                Title = p.ProductTitle,
                CreateDate = p.CreateDate
            }).Skip(skip).Take(take).ToList();


            return Tuple.Create(query, pageCount);

        }

        public void UpdateProduct(Product product, IFormFile imgProduct)
        {
            if (imgProduct != null && imgProduct.IsImage())
            {
                if (product.ProductImageName != "no-photo.jpg")
                {
                    string deletePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Product/image",
                        product.ProductImageName);

                    if (File.Exists(deletePath))
                    {
                        File.Delete(deletePath);
                    }

                    string deleteThumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Product/thumb",
                        product.ProductImageName);


                    if (File.Exists(deleteThumbPath))
                    {
                        File.Delete(deleteThumbPath);
                    }
                }


                product.ProductImageName = NameGenerator.GenerateUniqCode() + Path.GetExtension(imgProduct.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Product/image",
                    product.ProductImageName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imgProduct.CopyTo(stream);
                }

                ImageConvertor imgResizer = new ImageConvertor();
                string thumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Product/thumb",
                    product.ProductImageName);

                imgResizer.Image_resize(imagePath, thumbPath, 150);

            }

            _context.Products.Update(product);
            _context.SaveChanges();
        }

        public ShowSubProductForAdminViewModel GetSubProductsForAdmin(int productId, int pageId = 1, string filterSubProductTitle = "",
            string filterDimension = "", string filterCountryMade = "")
        {
            IQueryable<SubProduct> result = _context.SubProducts.Where(sp => sp.ProductId == productId);
            if (!string.IsNullOrEmpty(filterSubProductTitle))
            {
                result = result.Where(sp => sp.SubProductTitle.Contains(filterSubProductTitle));
            }
            if (!string.IsNullOrEmpty(filterDimension))
            {
                result = result.Where(sp => sp.Dimention.Contains(filterDimension));
            }
            if (!string.IsNullOrEmpty(filterCountryMade))
            {
                result = result.Where(sp => sp.CountryMade.MadeTitle.Contains(filterCountryMade));
            }

            int take = 2;
            int skip = (pageId - 1) * take;
            ShowSubProductForAdminViewModel list = new ShowSubProductForAdminViewModel();
            list.CurrentPage = pageId;
            list.PageCount = result.Count() / take;
            if ((list.PageCount % 2) != 0 || (list.PageCount % 2) == 0)
            {
                list.PageCount += 1;
            }
            list.SubProducts = result.Skip(skip).Take(take).ToList();

            return list;
        }


        public List<SelectListItem> GetCountryMades()
        {
            return _context.CountryMades.Select(c => new SelectListItem()
            {
                Value = c.MadeId.ToString(),
                Text = c.MadeTitle
            }).ToList();
        }

        public int AddSubProduct(SubProduct subProduct, IFormFile imgUpFile)
        {
            subProduct.SubProductImageName = "no-photo.jpg";
            if (imgUpFile != null)
            {
                subProduct.SubProductImageName = imgUpFile.FileName;
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/SubProduct/image",
                    subProduct.SubProductImageName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imgUpFile.CopyTo(stream);
                }

                ImageConvertor imgResizer = new ImageConvertor();
                string thumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/SubProduct/thumb",
                    subProduct.SubProductImageName);

                imgResizer.Image_resize(imagePath, thumbPath, 400);

            }

            _context.SubProducts.Add(subProduct);
            _context.SaveChanges();
            return subProduct.SubProductId;
        }

    }
}
