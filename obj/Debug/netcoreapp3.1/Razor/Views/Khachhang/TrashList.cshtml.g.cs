#pragma checksum "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Khachhang\TrashList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c083fb8ec8e352b5ea2885b5a4c3ec77a5547978"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Khachhang_TrashList), @"mvc.1.0.view", @"/Views/Khachhang/TrashList.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c083fb8ec8e352b5ea2885b5a4c3ec77a5547978", @"/Views/Khachhang/TrashList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d5b5393bb9c64daa29820e07180089a8626bd590", @"/Views/_ViewImports.cshtml")]
    public class Views_Khachhang_TrashList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ElectronicsStore.Models.Khachhang>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Khachhang", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ReStore", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Khachhang\TrashList.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "_Admin";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"d-flex justify-content-between mb-2\">\r\n    <div class=\"d-flex justify-content-between  flex-row-reverse\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c083fb8ec8e352b5ea2885b5a4c3ec77a55479784552", async() => {
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
            WriteLiteral(@"

    </div>

</div>
<table class=""table table-striped table-bordered"" id=""productTable"">
    <thead>
        <tr>
            <th class=""text-center"">STT</th>
            <th>Ảnh</th>
            <th>Mã</th>
            <th>Họ tên</th>
            <th>CCCD</th>
            <th>Ngày sinh</th>
            <th>Giới tính</th>
            <th>Địa chỉ</th>
            <th class=""d-none""></th>

            <th></th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 36 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Khachhang\TrashList.cshtml"
          
            int count = 1;
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 39 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Khachhang\TrashList.cshtml"
         foreach (var item in Model)
        {


#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td class=\"d-flex justify-content-center\">");
#nullable restore
#line 43 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Khachhang\TrashList.cshtml"
                                                 Write(count);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td><img style=\"height:200px;width:200px\"");
            BeginWriteAttribute("src", " src=\"", 1139, "\"", 1170, 2);
            WriteAttributeValue("", 1145, ".././Images/", 1145, 12, true);
#nullable restore
#line 44 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Khachhang\TrashList.cshtml"
WriteAttributeValue("", 1157, item.Hinhanh, 1157, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" /></td>\r\n            <td>");
#nullable restore
#line 45 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Khachhang\TrashList.cshtml"
           Write(item.Makh);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 46 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Khachhang\TrashList.cshtml"
           Write(item.Tenkh);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 47 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Khachhang\TrashList.cshtml"
           Write(item.Cccd);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 48 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Khachhang\TrashList.cshtml"
           Write(item.Ngaysinh);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 49 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Khachhang\TrashList.cshtml"
           Write(item.Gioitinh);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 50 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Khachhang\TrashList.cshtml"
           Write(item.Diachi);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td class=d-none>");
#nullable restore
#line 51 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Khachhang\TrashList.cshtml"
                        Write(item.Idkh);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n\r\n            <td>\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c083fb8ec8e352b5ea2885b5a4c3ec77a55479789800", async() => {
                WriteLiteral("\r\n                    <input name=\"id\"");
                BeginWriteAttribute("value", " value=\"", 1566, "\"", 1584, 1);
#nullable restore
#line 56 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Khachhang\TrashList.cshtml"
WriteAttributeValue("", 1574, item.Idkh, 1574, 10, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"d-none\" type=\"text\">\r\n\r\n                    <button type=\"submit\" class=\"btn btn-danger\">\r\n                        <i class=\"fas fa-unlock text-white\"></i>\r\n                    </button>\r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n            </td>\r\n");
#nullable restore
#line 64 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Khachhang\TrashList.cshtml"
               count++; 

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tr>\r\n");
#nullable restore
#line 66 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Khachhang\TrashList.cshtml"


        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n    </tbody>\r\n</table>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ElectronicsStore.Models.Khachhang>> Html { get; private set; }
    }
}
#pragma warning restore 1591
