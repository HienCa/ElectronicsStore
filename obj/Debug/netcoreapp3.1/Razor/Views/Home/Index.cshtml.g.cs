#pragma checksum "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "272dc461f77fd7d63256503b3486b8117f35bb1e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\_ViewImports.cshtml"
using ElectronicsStore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Home\Index.cshtml"
using ElectronicsStore.ViewModel;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Home\Index.cshtml"
using ElectronicsStore.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"272dc461f77fd7d63256503b3486b8117f35bb1e", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d5b5393bb9c64daa29820e07180089a8626bd590", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("card-img-top"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width: 100%; height: 300px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("ảnh linh kiện"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Home\Index.cshtml"
  
    Layout = "_Home";


#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"container\" style=\"margin-top:70px;\">\r\n    <div class=\"category p-3\" style=\"background-color: #fff;border-radius: 5px;\">\r\n        <div class=\"row\">\r\n");
#nullable restore
#line 10 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Home\Index.cshtml"
             foreach (var item in TempData["Nhomhh"] as List<Nhomhh>)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"col-lg-2 col-md-4 col-sm-6\">\r\n                    <div class=\"d-flex flex-column align-items-center\">\r\n                        <div");
            BeginWriteAttribute("class", " class=\"", 506, "\"", 514, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                            <img src=\"./h.jpg\" alt=\"Loại linh kiện\"\r\n                                 style=\"width:100px;height: 100px;border-radius: 50%;\">\r\n                        </div>\r\n                        <div>");
#nullable restore
#line 18 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Home\Index.cshtml"
                        Write(item.Tennhh);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                    </div>\r\n\r\n                </div>\r\n");
#nullable restore
#line 22 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Home\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"


        </div>

    </div>
    <div class=""mt-3"">
        <div class=""p-3"" style=""background-color: #fff;border-radius: 5px;"">
            <h3 class=""text-danger""><i class=""fas fa-fire ""></i> KHUYẾN MÃI HOT</h3>
            <div class=""row"">

");
#nullable restore
#line 34 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Home\Index.cshtml"
                 foreach (var item in TempData["Hanghoa"] as List<HanghoaViewModel>)
                {

                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 37 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Home\Index.cshtml"
                     if (item.Giakm != null)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"col-lg-3 col-md-4 col-sm-6 mb-2\">\r\n                            <div class=\"card product\" style=\"border:none\">\r\n                                <a");
            BeginWriteAttribute("href", " href=\"", 1440, "\"", 1471, 2);
            WriteAttributeValue("", 1447, "/Home/Details/", 1447, 14, true);
#nullable restore
#line 41 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Home\Index.cshtml"
WriteAttributeValue("", 1461, item.Idhh, 1461, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"text-decoration:none;color:black\">\r\n                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "272dc461f77fd7d63256503b3486b8117f35bb1e7401", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1562, "~/Images/", 1562, 9, true);
#nullable restore
#line 42 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Home\Index.cshtml"
AddHtmlAttributeValue("", 1571, item.ExistingImage, 1571, 19, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                </a>\r\n                                <div class=\"card-body\">\r\n                                    <a");
            BeginWriteAttribute("href", " href=\"", 1846, "\"", 1877, 2);
            WriteAttributeValue("", 1853, "/Home/Details/", 1853, 14, true);
#nullable restore
#line 46 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Home\Index.cshtml"
WriteAttributeValue("", 1867, item.Idhh, 1867, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" style=""text-decoration:none;color:black"">
                                        <p class=""card-title"" style=""width: 200px; white-space: nowrap; overflow: hidden; text-overflow: ellipsis; display: -webkit-box; -webkit-line-clamp: 2; -webkit-box-orient: vertical;"">");
#nullable restore
#line 47 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Home\Index.cshtml"
                                                                                                                                                                                                                          Write(item.Tenvl);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 48 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Home\Index.cshtml"
                                         if (item.Giakm != null)
                                        {
                                            float? giakm = item.Giakm;
                                            string giakms = giakm.HasValue ? giakm.Value.ToString("#,###.##") : "";


                                            string giabans = (item.Giaban).ToString("#,###.##");


#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <p class=\"card-text text-danger \">");
#nullable restore
#line 56 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Home\Index.cshtml"
                                                                         Write(giakms);

#line default
#line hidden
#nullable disable
            WriteLiteral(" đ</p>\r\n                                            <p class=\"card-text text-dark  \"\r\n                                               style=\"text-decoration: line-through;opacity: 0.7;\">");
#nullable restore
#line 58 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Home\Index.cshtml"
                                                                                              Write(giabans);

#line default
#line hidden
#nullable disable
            WriteLiteral(" đ</p>\r\n");
#nullable restore
#line 59 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Home\Index.cshtml"
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                    </a>

                                    <button href=""#"" class=""btn btn-danger mt-2 w-100 text-white"">MUA NGAY</button>
                                </div>
                            </div>
                        </div>
");
#nullable restore
#line 67 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Home\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 67 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Home\Index.cshtml"
                     
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n    <div class=\"mt-3\">\r\n        <div class=\"p-3\" style=\"background-color: #fff;border-radius: 5px;\">\r\n            <div class=\"row\">\r\n\r\n");
#nullable restore
#line 77 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Home\Index.cshtml"
                 foreach (var item in TempData["Hanghoa"] as List<HanghoaViewModel>)
                {

                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 80 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Home\Index.cshtml"
                     if (item.Giakm == null)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"col-lg-3 col-md-4 col-sm-6 mb-2\">\r\n                            <div class=\"card product\" style=\"border:none\">\r\n                                <a");
            BeginWriteAttribute("href", " href=\"", 3748, "\"", 3779, 2);
            WriteAttributeValue("", 3755, "/Home/Details/", 3755, 14, true);
#nullable restore
#line 84 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Home\Index.cshtml"
WriteAttributeValue("", 3769, item.Idhh, 3769, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"text-decoration: none; color: black; height: 300px;\">\r\n                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "272dc461f77fd7d63256503b3486b8117f35bb1e14095", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 3889, "~/Images/", 3889, 9, true);
#nullable restore
#line 85 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Home\Index.cshtml"
AddHtmlAttributeValue("", 3898, item.ExistingImage, 3898, 19, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                </a>\r\n                                <div class=\"card-body\">\r\n                                    <a");
            BeginWriteAttribute("href", " href=\"", 4173, "\"", 4204, 2);
            WriteAttributeValue("", 4180, "/Home/Details/", 4180, 14, true);
#nullable restore
#line 89 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Home\Index.cshtml"
WriteAttributeValue("", 4194, item.Idhh, 4194, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" style=""text-decoration:none;color:black"">
                                        <p class=""card-title"" style=""width: 200px; white-space: nowrap; overflow: hidden; text-overflow: ellipsis; display: -webkit-box; -webkit-line-clamp: 2; -webkit-box-orient: vertical;"">");
#nullable restore
#line 90 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Home\Index.cshtml"
                                                                                                                                                                                                                          Write(item.Tenvl);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 91 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Home\Index.cshtml"
                                          
                                            string giabans = (item.Giaban).ToString("#,###.##");
                                        

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <p class=\"card-text text-danger \">");
#nullable restore
#line 94 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Home\Index.cshtml"
                                                                     Write(giabans);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" đ</p>

                                    </a>

                                    <button href=""#"" class=""btn btn-danger mt-2 w-100 text-white"">MUA NGAY</button>
                                </div>
                            </div>
                        </div>
");
#nullable restore
#line 102 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Home\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 102 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Home\Index.cshtml"
                     


                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>");
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
