#pragma checksum "D:\programing\DepartmentStore.CoreProject\DepartmentStore\DepartmentStore.Web\Pages\Admin\Products\IndexSubProduct.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7016ccb14c2d98ba9585c25d13aab500c4a35384"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Pages_Admin_Products_IndexSubProduct), @"mvc.1.0.razor-page", @"/Pages/Admin/Products/IndexSubProduct.cshtml")]
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
#nullable restore
#line 2 "D:\programing\DepartmentStore.CoreProject\DepartmentStore\DepartmentStore.Web\Pages\Admin\Products\IndexSubProduct.cshtml"
using DepartmentStore.Core.Services.Interfaces;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemMetadataAttribute("RouteTemplate", "{id}")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7016ccb14c2d98ba9585c25d13aab500c4a35384", @"/Pages/Admin/Products/IndexSubProduct.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9af4978b9c2bfca24ef48e96efe5f8573634464", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Admin_Products_IndexSubProduct : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "CreateSubProduct", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline btn-success"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "D:\programing\DepartmentStore.CoreProject\DepartmentStore\DepartmentStore.Web\Pages\Admin\Products\IndexSubProduct.cshtml"
  
    ViewData["Title"] = "لیست کالاهای محصول";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""row"">
    <div class=""col-lg-12"">
        <h1 class=""page-header"">لیست کالاهای محصول</h1>
    </div>
    <!-- /.col-lg-12 -->
</div>
<div class=""row"">
    <div class=""col-lg-12"">
        <div class=""panel panel-default"">
            <div class=""panel-heading"">
                لیست کالاهای محصول
            </div>
            <div class=""col-md-12"" style=""margin-top: 10px"">
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7016ccb14c2d98ba9585c25d13aab500c4a353844821", async() => {
                WriteLiteral("افزودن کالای جدید");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 21 "D:\programing\DepartmentStore.CoreProject\DepartmentStore\DepartmentStore.Web\Pages\Admin\Products\IndexSubProduct.cshtml"
                                                 WriteLiteral(ViewData["ProductId"].ToString());

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
            </div>
            <!-- /.panel-heading -->
            <div class=""panel-body"">
                <div class=""table-responsive"">
                    <div id=""dataTables-example_wrapper"" class=""dataTables_wrapper form-inline"" role=""grid"">
                        <div class=""row"">
                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7016ccb14c2d98ba9585c25d13aab500c4a353847475", async() => {
                WriteLiteral(@"
                                <div class=""col-md-3 col-sm-5"">
                                    <input type=""text"" name=""filterSubProductTitle"" class=""form-control"" placeholder=""نام کالا"" />
                                </div>
                                <div class=""col-md-2 col-sm-5"">
                                    <input type=""text"" name=""filterDimension"" class=""form-control"" placeholder=""ابعاد"" />
                                </div>
                                <div class=""col-md-3 col-sm-5"">
                                    <input type=""text"" name=""filterCountryMade"" class=""form-control"" placeholder=""کشور تولید کننده"" />
                                </div>
                                <div class=""col-md-2 col-sm-2"">
                                    <button type=""submit"" class=""btn btn-info btn-sm"">اعمال فیلتر</button>
                                    <a");
                BeginWriteAttribute("href", " href=\"", 2035, "\"", 2107, 2);
                WriteAttributeValue("", 2042, "/Admin/Products/IndexSubProduct/", 2042, 32, true);
#nullable restore
#line 40 "D:\programing\DepartmentStore.CoreProject\DepartmentStore\DepartmentStore.Web\Pages\Admin\Products\IndexSubProduct.cshtml"
WriteAttributeValue("", 2074, ViewData["ProductId"].ToString(), 2074, 33, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"btn btn-sm btn-default\">نمایش لیست</a>\r\n                                </div>\r\n                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                            <table class=""table table-striped table-bordered table-hover dataTable no-footer"" id=""dataTables-example"" aria-describedby=""dataTables-example_info"">
                                <thead>
                                    <tr>
                                        <th>عنوان کالا</th>
                                        <th>ابعاد</th>
                                        <th>قیمت (تومان)</th>
                                        <th>دستورات</th>
                                    </tr>
                                </thead>
                                <tbody>
");
#nullable restore
#line 53 "D:\programing\DepartmentStore.CoreProject\DepartmentStore\DepartmentStore.Web\Pages\Admin\Products\IndexSubProduct.cshtml"
                                     foreach (var item in Model.ListSubProduct.SubProducts)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <tr>\r\n                                            <td>");
#nullable restore
#line 56 "D:\programing\DepartmentStore.CoreProject\DepartmentStore\DepartmentStore.Web\Pages\Admin\Products\IndexSubProduct.cshtml"
                                           Write(item.SubProductTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td style=\"text-decoration-line: underline\">");
#nullable restore
#line 57 "D:\programing\DepartmentStore.CoreProject\DepartmentStore\DepartmentStore.Web\Pages\Admin\Products\IndexSubProduct.cshtml"
                                                                                   Write(item.Dimention);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td>");
#nullable restore
#line 58 "D:\programing\DepartmentStore.CoreProject\DepartmentStore\DepartmentStore.Web\Pages\Admin\Products\IndexSubProduct.cshtml"
                                           Write(item.ProductPrice.ToString("#,0"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td>\r\n                                                <a");
            BeginWriteAttribute("href", " href=\"", 3412, "\"", 3468, 2);
            WriteAttributeValue("", 3419, "/Admin/Products/EditSubProduct/", 3419, 31, true);
#nullable restore
#line 60 "D:\programing\DepartmentStore.CoreProject\DepartmentStore\DepartmentStore.Web\Pages\Admin\Products\IndexSubProduct.cshtml"
WriteAttributeValue("", 3450, item.SubProductId, 3450, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-sm btn-warning\">ویرایش</a>\r\n                                            </td>\r\n                                        </tr>\r\n");
#nullable restore
#line 63 "D:\programing\DepartmentStore.CoreProject\DepartmentStore\DepartmentStore.Web\Pages\Admin\Products\IndexSubProduct.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                </tbody>
                            </table>
                            <div class=""row"">
                                <div class=""col-sm-6"">
                                </div>
                                <div class=""col-sm-6"">
                                    <div class=""dataTables_paginate paging_simple_numbers"" id=""dataTables-example_paginate"">
                                        <ul class=""pagination"">
");
#nullable restore
#line 72 "D:\programing\DepartmentStore.CoreProject\DepartmentStore\DepartmentStore.Web\Pages\Admin\Products\IndexSubProduct.cshtml"
                                             for (int i = 1; i <= Model.ListSubProduct.PageCount; i++)
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <li");
            BeginWriteAttribute("class", " class=\"", 4322, "\"", 4398, 2);
            WriteAttributeValue("", 4330, "paginate_button", 4330, 15, true);
#nullable restore
#line 74 "D:\programing\DepartmentStore.CoreProject\DepartmentStore\DepartmentStore.Web\Pages\Admin\Products\IndexSubProduct.cshtml"
WriteAttributeValue(" ", 4345, (i==Model.ListSubProduct.CurrentPage)?"active":"", 4346, 52, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" aria-controls=\"dataTables-example\" tabindex=\"0\"><a");
            BeginWriteAttribute("href", " href=\"", 4450, "\"", 4532, 4);
            WriteAttributeValue("", 4457, "/Admin/Products/IndexSubProduct/", 4457, 32, true);
#nullable restore
#line 74 "D:\programing\DepartmentStore.CoreProject\DepartmentStore\DepartmentStore.Web\Pages\Admin\Products\IndexSubProduct.cshtml"
WriteAttributeValue("", 4489, ViewData["ProductId"].ToString(), 4489, 33, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 4522, "?pageId=", 4522, 8, true);
#nullable restore
#line 74 "D:\programing\DepartmentStore.CoreProject\DepartmentStore\DepartmentStore.Web\Pages\Admin\Products\IndexSubProduct.cshtml"
WriteAttributeValue("", 4530, i, 4530, 2, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 74 "D:\programing\DepartmentStore.CoreProject\DepartmentStore\DepartmentStore.Web\Pages\Admin\Products\IndexSubProduct.cshtml"
                                                                                                                                                                                                                                                                  Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n");
#nullable restore
#line 75 "D:\programing\DepartmentStore.CoreProject\DepartmentStore\DepartmentStore.Web\Pages\Admin\Products\IndexSubProduct.cshtml"
                                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                        </ul>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- /.panel-body -->
                </div>
            </div>
        </div>
    </div>
</div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IProductService _productService { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DepartmentStore.Web.Pages.Admin.Products.IndexSubProductModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<DepartmentStore.Web.Pages.Admin.Products.IndexSubProductModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<DepartmentStore.Web.Pages.Admin.Products.IndexSubProductModel>)PageContext?.ViewData;
        public DepartmentStore.Web.Pages.Admin.Products.IndexSubProductModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591