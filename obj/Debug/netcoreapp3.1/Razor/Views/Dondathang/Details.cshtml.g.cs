#pragma checksum "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Dondathang\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cc949b598880b2cc7f8dfec7e6c0feb47b4e0be5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Dondathang_Details), @"mvc.1.0.view", @"/Views/Dondathang/Details.cshtml")]
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
#line 2 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\_ViewImports.cshtml"
using ElectronicsStore.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Dondathang\Details.cshtml"
using ElectronicsStore.ViewModel;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cc949b598880b2cc7f8dfec7e6c0feb47b4e0be5", @"/Views/Dondathang/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d5b5393bb9c64daa29820e07180089a8626bd590", @"/Views/_ViewImports.cshtml")]
    public class Views_Dondathang_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ElectronicsStore.ViewModel.NoidungddhViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Dondathang", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Dondathang\Details.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "_Admin";
    Dondathang dondathang = ViewData["Dondathang"] as Dondathang;
    int statusviewmodel = (int)ViewData["Status"];

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"d-flex justify-content-between mb-2\">\r\n    <div class=\"d-flex justify-content-between  flex-row-reverse\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cc949b598880b2cc7f8dfec7e6c0feb47b4e0be55117", async() => {
                WriteLiteral("\r\n            <button type=\"submit\" class=\"btn btn-light \">\r\n                Quay lại\r\n            </button>\r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n    </div>\r\n    <div class=\"d-flex justify-content-between  flex-row-reverse\">\r\n");
#nullable restore
#line 19 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Dondathang\Details.cshtml"
         if (dondathang.Trangthai == 1)
        {
            //đủ số lượng để xuất
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 22 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Dondathang\Details.cshtml"
             if (statusviewmodel == 1)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cc949b598880b2cc7f8dfec7e6c0feb47b4e0be57473", async() => {
                WriteLiteral("\r\n                    <input type=\"hidden\"");
                BeginWriteAttribute("value", " value=\"", 943, "\"", 967, 1);
#nullable restore
#line 25 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Dondathang\Details.cshtml"
WriteAttributeValue("", 951, dondathang.Iddh, 951, 16, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" name=\"Iddh\" />\r\n                    <input type=\"hidden\"");
                BeginWriteAttribute("value", " value=\"", 1025, "\"", 1049, 1);
#nullable restore
#line 26 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Dondathang\Details.cshtml"
WriteAttributeValue("", 1033, dondathang.Idkh, 1033, 16, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" name=\"Idkh\" />\r\n                    <input type=\"hidden\" value=\"2\" name=\"Trangthai\" />\r\n\r\n                    <button type=\"submit\" class=\"btn btn-success text-white\" style=\"text-decoration:none\">Xuất kho</button>\r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 31 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Dondathang\Details.cshtml"

            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <span class=\"text-danger\" style=\"font-weight: bolder; font-size: 24px\">Lượng hàng trong kho không đủ</span>\r\n");
#nullable restore
#line 36 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Dondathang\Details.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 36 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Dondathang\Details.cshtml"
             

        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

    </div>
</div>
<table class=""table table-striped table-bordered  "" id=""productTable"">
    <thead>
        <tr>
            <th class=""text-center"">STT</th>
            <th class=""text-center"" style=""width:150px;"">Ảnh</th>
            <th class=""text-center"" style=""width:400px"">Sản phẩm</th>
            <th class=""text-center"">SL</th>
            <th class=""text-center"">Giá</th>
            <th class=""text-center"">Hạn bảo hành</th>
            <th class=""text-center"">Thành tiền</th>
            <th class=""text-center"">Tồn Kho</th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 57 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Dondathang\Details.cshtml"
          
            int count = 1;
            float total = 0;
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 61 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Dondathang\Details.cshtml"
         if (Model != null)
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 63 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Dondathang\Details.cshtml"
             foreach (var item in Model)
            {


#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td class=\"d-flex justify-content-center\">");
#nullable restore
#line 67 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Dondathang\Details.cshtml"
                                                         Write(count);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td><img");
            BeginWriteAttribute("src", " src=\"", 2397, "\"", 2424, 2);
            WriteAttributeValue("", 2403, "/Images/", 2403, 8, true);
#nullable restore
#line 68 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Dondathang\Details.cshtml"
WriteAttributeValue("", 2411, item.Hinhanh, 2411, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"width:100%;height:150px\" /></td>\r\n                    <td>");
#nullable restore
#line 69 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Dondathang\Details.cshtml"
                   Write(item.Tenhh);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td class=\"text-center\">");
#nullable restore
#line 70 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Dondathang\Details.cshtml"
                                       Write(item.Soluong);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 71 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Dondathang\Details.cshtml"
                      
                        string Dongia = (item.Dongia).ToString("#,###.##");
                        string Thanhtien = (item.Soluong * item.Dongia).ToString("#,###.##");
                        total = total + (item.Soluong * item.Dongia);
                    

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td class=\"text-right\">");
#nullable restore
#line 76 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Dondathang\Details.cshtml"
                                      Write(Dongia);

#line default
#line hidden
#nullable disable
            WriteLiteral(" đ</td>\r\n\r\n");
#nullable restore
#line 78 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Dondathang\Details.cshtml"
                     if (item.Hethanbh != null)
                    {
                        DateTime Hethanbh = (DateTime)item.Hethanbh;

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <td class=\"text-center\">");
#nullable restore
#line 81 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Dondathang\Details.cshtml"
                                           Write(Hethanbh.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 82 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Dondathang\Details.cshtml"

                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <td></td>\r\n");
#nullable restore
#line 87 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Dondathang\Details.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td class=\"text-right\">");
#nullable restore
#line 88 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Dondathang\Details.cshtml"
                                      Write(Thanhtien);

#line default
#line hidden
#nullable disable
            WriteLiteral(" đ</td>\r\n");
#nullable restore
#line 89 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Dondathang\Details.cshtml"
                     if (statusviewmodel == 1)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <td class=\"text-center\"><span class=\"text-right bg-success text-white p-2\" style=\"border-radius: 10px; font-weight: bolder\">Đủ: ");
#nullable restore
#line 91 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Dondathang\Details.cshtml"
                                                                                                                                                   Write(item.SoLuongTon);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></td>\r\n");
#nullable restore
#line 92 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Dondathang\Details.cshtml"

                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <td class=\"text-center\"><span class=\"text-right bg-danger text-white p-2\" style=\"border-radius: 10px; font-weight: bolder;\">Thiếu: ");
#nullable restore
#line 96 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Dondathang\Details.cshtml"
                                                                                                                                                      Write(item.SoLuongThieu);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></td>\r\n");
#nullable restore
#line 97 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Dondathang\Details.cshtml"


                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 101 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Dondathang\Details.cshtml"
                       count++; 

#line default
#line hidden
#nullable disable
            WriteLiteral("                </tr>\r\n");
#nullable restore
#line 103 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Dondathang\Details.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 103 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Dondathang\Details.cshtml"
             

        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td></td>\r\n            <td style=\"font-weight:bolder\">Tổng đơn</td>\r\n            <td></td>\r\n            <td></td>\r\n            <td></td>\r\n            <td></td>\r\n");
#nullable restore
#line 113 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Dondathang\Details.cshtml"
              
                string Tongtien = total.ToString("#,###.##");
            

#line default
#line hidden
#nullable disable
            WriteLiteral("            <td class=\"text-right\" style=\"font-weight:bolder\">");
#nullable restore
#line 116 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Dondathang\Details.cshtml"
                                                         Write(Tongtien);

#line default
#line hidden
#nullable disable
            WriteLiteral(" đ</td>\r\n\r\n        </tr>\r\n\r\n\r\n    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ElectronicsStore.ViewModel.NoidungddhViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
