#pragma checksum "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Phieunhapkho\XuatNhapTonReport.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "564788d65cf8f66291a31b590d5ceb96eed42724"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Phieunhapkho_XuatNhapTonReport), @"mvc.1.0.view", @"/Views/Phieunhapkho/XuatNhapTonReport.cshtml")]
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
#line 2 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Phieunhapkho\XuatNhapTonReport.cshtml"
using ElectronicsStore.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Phieunhapkho\XuatNhapTonReport.cshtml"
using ElectronicsStore.ViewModel;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"564788d65cf8f66291a31b590d5ceb96eed42724", @"/Views/Phieunhapkho/XuatNhapTonReport.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d5b5393bb9c64daa29820e07180089a8626bd590", @"/Views/_ViewImports.cshtml")]
    public class Views_Phieunhapkho_XuatNhapTonReport : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("reportForm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "XuatNhapTonReport", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Phieunhapkho", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/multiSelectDropdown/virtual-select.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 5 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Phieunhapkho\XuatNhapTonReport.cshtml"
  
    Layout = "_Admin";
    ElectronicsStoreContext _context = new ElectronicsStoreContext();
    List<Hanghoa> hanghoa = _context.Hanghoa.Where(V => V.Active == 1).ToList();

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"x_content\">\r\n    <div class=\"row\">\r\n        <div class=\"col-sm-12\">\r\n            <div style=\"position: relative;\" class=\"card-box  filterTable\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "564788d65cf8f66291a31b590d5ceb96eed427246317", async() => {
                WriteLiteral("\r\n                    <div class=\"searchToFrom row mb-2\">\r\n\r\n                        <div class=\"col-md-2 col-sm-12\">\r\n                            <div class=\"d-flex justify-content-around align-items-center\">\r\n                                <div");
                BeginWriteAttribute("class", " class=\"", 775, "\"", 783, 0);
                EndWriteAttribute();
                WriteLiteral(@">Từ: </div>
                                <input type=""date"" id=""from"" name=""from"" placeholder=""Từ"" class="" form-control"" />
                            </div>
                        </div>
                        <div class=""col-md-2 col-sm-12"">
                            <div class=""d-flex justify-content-around align-items-center"">
                                <div");
                BeginWriteAttribute("class", " class=\"", 1167, "\"", 1175, 0);
                EndWriteAttribute();
                WriteLiteral(@">Đến: </div>
                                <input type=""date"" id=""to"" name=""to"" placeholder=""Đến"" class="" form-control"" />
                            </div>
                        </div>

                        <div class=""col-md-7 col-sm-12"" style=""z-index:1"">

                            <select data-search=""true"" name=""Idhh""
                                    id=""multipleSelect"">
                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "564788d65cf8f66291a31b590d5ceb96eed427247992", async() => {
                    WriteLiteral("Tất cả");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 35 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Phieunhapkho\XuatNhapTonReport.cshtml"
                                 foreach (var item in hanghoa)
                                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "564788d65cf8f66291a31b590d5ceb96eed427249548", async() => {
#nullable restore
#line 37 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Phieunhapkho\XuatNhapTonReport.cshtml"
                                                          Write(item.Tenvl);

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 37 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Phieunhapkho\XuatNhapTonReport.cshtml"
                                       WriteLiteral(item.Idhh);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 38 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Phieunhapkho\XuatNhapTonReport.cshtml"

                                }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                            </select>
                        </div>
                        <div class=""col-md-1 col-sm-12"">
                            <input type=""button"" id=""searchDate"" value=""Tìm"" class=""btn btn-primary"" />
                        </div>
                    </div>
                    <div class=""row"">


                        <div class=""col-md-1 col-sm-12"">
                            <button type=""button"" id=""export"" class=""btn btn-success text-white""><i class=""fas fa-file-excel""></i></button>
                        </div>
                        <div class=""col-md-1 col-sm-12"">
                            <button type=""button"" id=""csv"" class=""btn btn-success text-white""><i class=""fas fa-file-csv""></i></button>
                        </div>
                        <div class=""col-md-10 col-sm-12"">
");
#nullable restore
#line 57 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Phieunhapkho\XuatNhapTonReport.cshtml"
                             if (ViewData["from"] != null && ViewData["to"] != null)
                            {
                                DateTime from = (DateTime)ViewData["from"];
                                DateTime to = (DateTime)ViewData["to"];


#line default
#line hidden
#nullable disable
                WriteLiteral("                                <span>\r\n                                    Từ:");
#nullable restore
#line 63 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Phieunhapkho\XuatNhapTonReport.cshtml"
                                  Write(from.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));

#line default
#line hidden
#nullable disable
                WriteLiteral(" đến ");
#nullable restore
#line 63 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Phieunhapkho\XuatNhapTonReport.cshtml"
                                                                                                                      Write(to.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                </span>\r\n");
#nullable restore
#line 65 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Phieunhapkho\XuatNhapTonReport.cshtml"
                            }

#line default
#line hidden
#nullable disable
                WriteLiteral("                        </div>\r\n                        <input name=\"action\" type=\"hidden\" id=\"action\" />\r\n                    </div>\r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                <div class=""table-responsive"">

                    <table class=""table table-striped table-bordered"" id=""productTable"" style=""max-height:60vh;overflow-y:scroll"">
                        <thead>
                            <tr class=""text-center"">

                                <th scope=""col"">Mã hàng</th>
                                <th scope=""col"">Tên hàng</th>

                                <th scope=""col"">ĐVT</th>
                                <th scope=""col"">SL ĐK</th>
                                <th scope=""col"">Trị giá ĐK</th>

                                <th scope=""col"">SLN GK</th>
                                <th scope=""col"">Trị giá DGN GK</th>
                                <th scope=""col"">SLX GK</th>
                                <th scope=""col"">Trị giá DGX GK</th>

                                <th scope=""col"">SL CK</th>
                                <th scope=""col"">Trị giá CK</th>


                            </tr>
             ");
            WriteLiteral("           </thead>\r\n\r\n                        <tbody>\r\n");
#nullable restore
#line 96 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Phieunhapkho\XuatNhapTonReport.cshtml"
                             if (ViewData["XuatNhapTonReport"] != null)
                            {
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 98 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Phieunhapkho\XuatNhapTonReport.cshtml"
                                 foreach (var item in ViewData["XuatNhapTonReport"] as List<XuatNhapTon>)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <tr class=\"tr\">\r\n                                        <td>");
#nullable restore
#line 101 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Phieunhapkho\XuatNhapTonReport.cshtml"
                                       Write(item.Mahh);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 102 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Phieunhapkho\XuatNhapTonReport.cshtml"
                                       Write(item.Tenhh);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td class=\"text-center\">");
#nullable restore
#line 103 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Phieunhapkho\XuatNhapTonReport.cshtml"
                                                           Write(item.Donvitinh);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n");
#nullable restore
#line 105 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Phieunhapkho\XuatNhapTonReport.cshtml"
                                          
                                            var Dongiadauky = String.Format("{0:0,0}", (@item.Dongiadauky > 0 ? @item.Dongiadauky : 0));
                                            var Dongiagiuakynhap = String.Format("{0:0,0}", (@item.Dongiagiuakynhap > 0 ? @item.Dongiagiuakynhap : 0));
                                            var Dongiagiuakyxuat = String.Format("{0:0,0}", (@item.Dongiagiuakyxuat > 0 ? @item.Dongiagiuakyxuat : 0));
                                            var Dongiacuoiky = String.Format("{0:0,0}", (@item.Dongiacuoiky > 0 ? @item.Dongiacuoiky : 0));

                                        

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <td class=\"text-center\">");
#nullable restore
#line 112 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Phieunhapkho\XuatNhapTonReport.cshtml"
                                                           Write(item.Soluongdauky);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td class=\"text-right\">");
#nullable restore
#line 113 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Phieunhapkho\XuatNhapTonReport.cshtml"
                                                          Write(Dongiadauky);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n                                        <td class=\"text-center\">");
#nullable restore
#line 115 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Phieunhapkho\XuatNhapTonReport.cshtml"
                                                           Write(item.Soluonggiuakynhap);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td class=\"text-right\">");
#nullable restore
#line 116 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Phieunhapkho\XuatNhapTonReport.cshtml"
                                                          Write(Dongiagiuakynhap);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n                                        <td class=\"text-center\">");
#nullable restore
#line 118 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Phieunhapkho\XuatNhapTonReport.cshtml"
                                                           Write(item.Soluonggiuakyxuat);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td class=\"text-right\">");
#nullable restore
#line 119 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Phieunhapkho\XuatNhapTonReport.cshtml"
                                                          Write(Dongiagiuakyxuat);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n                                        <td class=\"text-center\">");
#nullable restore
#line 121 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Phieunhapkho\XuatNhapTonReport.cshtml"
                                                           Write(item.Soluongcuoiky);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td class=\"text-right\">");
#nullable restore
#line 122 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Phieunhapkho\XuatNhapTonReport.cshtml"
                                                          Write(Dongiacuoiky);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n                                    </tr>\r\n");
#nullable restore
#line 125 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Phieunhapkho\XuatNhapTonReport.cshtml"
                                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 125 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Phieunhapkho\XuatNhapTonReport.cshtml"
                                 
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

                        </tbody>
                    </table>
                </div>


            </div>
        </div>
    </div>
</div>




<script>
    const reportForm = document.getElementById(""reportForm"");
    const exportBtn = document.getElementById(""export"");
    const csvBtn = document.getElementById(""csv"");
    const searchDateBtn = document.getElementById(""searchDate"");
    let action = document.getElementById(""action"");

    exportBtn.addEventListener(""click"", function () {
        action.value = ""excel"";
        reportForm.submit();
    });
    csvBtn.addEventListener(""click"", function () {
        action.value = ""csv"";
        reportForm.submit();
    });
    searchDateBtn.addEventListener(""click"", function () {
        action.value = ""searchDate"";
        reportForm.submit();
    })
</script>
");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "564788d65cf8f66291a31b590d5ceb96eed4272423862", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n<script type=\"text/javascript\">\r\n    VirtualSelect.init({\r\n        ele: \'select\'\r\n    });\r\n</script>");
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
