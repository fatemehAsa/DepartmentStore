#pragma checksum "D:\programing\DepartmentStore.CoreProject\DepartmentStore\DepartmentStore.Web\Views\Account\ActiveAccount.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a05bdcd7ad3a4292190378f502caf825835b3eeb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_ActiveAccount), @"mvc.1.0.view", @"/Views/Account/ActiveAccount.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a05bdcd7ad3a4292190378f502caf825835b3eeb", @"/Views/Account/ActiveAccount.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9af4978b9c2bfca24ef48e96efe5f8573634464", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_ActiveAccount : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "D:\programing\DepartmentStore.CoreProject\DepartmentStore\DepartmentStore.Web\Views\Account\ActiveAccount.cshtml"
  
    ViewData["Title"] = "فعالسازی";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""container"">
    <nav aria-label=""breadcrumb"">
        <ul class=""breadcrumb"">
            <li class=""breadcrumb-item""><a href=""/"">ایران ابزار</a></li>
            <li id=""RegisterText"" class=""breadcrumb-item active"" aria-current=""page"">فعالسازی حساب کاربری</li>
        </ul>
    </nav>
</div>
");
#nullable restore
#line 14 "D:\programing\DepartmentStore.CoreProject\DepartmentStore\DepartmentStore.Web\Views\Account\ActiveAccount.cshtml"
 if (ViewBag.IsActive)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"container\">\r\n        <div class=\"alert alert-success text-right\">\r\n            <p>حساب کاربری شما با موفقیت فعال شد</p>\r\n            <p>\r\n                <a href=\"/Login\">ورود به سایت</a>\r\n            </p>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 24 "D:\programing\DepartmentStore.CoreProject\DepartmentStore\DepartmentStore.Web\Views\Account\ActiveAccount.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"alert alert-danger text-right\">\r\n        <p>حساب کاربری با مشخصات ارسال شده یافت نشد</p>\r\n    </div>\r\n");
#nullable restore
#line 30 "D:\programing\DepartmentStore.CoreProject\DepartmentStore\DepartmentStore.Web\Views\Account\ActiveAccount.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
