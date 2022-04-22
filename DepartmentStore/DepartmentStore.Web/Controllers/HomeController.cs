using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DepartmentStore.Core.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DepartmentStore.Web.Controllers
{
    public class HomeController : Controller
    {
        private IProductService _productService;

        public HomeController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View();
        }



        [HttpPost]
        [Route("file-upload")]
        public IActionResult UploadImage(IFormFile upload, string CKEditorFuncNum, string CKEditor, string langCode)
        {
            if (upload.Length <= 0) return null;

            var fileName = Guid.NewGuid() + Path.GetExtension(upload.FileName).ToLower();



            var path = Path.Combine(
                Directory.GetCurrentDirectory(), "wwwroot/MyImages",
                fileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                upload.CopyTo(stream);

            }



            var url = $"{"/MyImages/"}{fileName}";


            return Json(new { uploaded = true, url });
        }

        public IActionResult GetSubGroups(int id)
        {
            List<SelectListItem> list = new List<SelectListItem>()
            {
                new SelectListItem() {Text = "انتخاب کنید", Value = ""}
            };
            list.AddRange(_productService.GetSubGroupsForManageProduct(id));
            return Json(new SelectList(list, "Value", "Text"));

        }
    }
}
