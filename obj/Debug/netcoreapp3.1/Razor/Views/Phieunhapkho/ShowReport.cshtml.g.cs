#pragma checksum "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Phieunhapkho\ShowReport.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fab8c8e976ea860f7a9ebd9cce8358b66f03a66e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Phieunhapkho_ShowReport), @"mvc.1.0.view", @"/Views/Phieunhapkho/ShowReport.cshtml")]
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
#line 3 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Phieunhapkho\ShowReport.cshtml"
using ElectronicsStore.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fab8c8e976ea860f7a9ebd9cce8358b66f03a66e", @"/Views/Phieunhapkho/ShowReport.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d5b5393bb9c64daa29820e07180089a8626bd590", @"/Views/_ViewImports.cshtml")]
    public class Views_Phieunhapkho_ShowReport : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ElectronicsStore.Models.Noidungpnk>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("reportForm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ShowReport", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 5 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Phieunhapkho\ShowReport.cshtml"
  
    Layout = "_Admin";
    ElectronicsStoreContext _context = new ElectronicsStoreContext();
    List<Hanghoa> hanghoa = _context.Hanghoa.Where(V => V.Active == 1).ToList();

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"x_content\">\r\n    <div class=\"row\">\r\n        <div class=\"col-sm-12\">\r\n            <div style=\"position: relative;\" class=\"card-box table-responsive filterTable\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fab8c8e976ea860f7a9ebd9cce8358b66f03a66e6120", async() => {
                WriteLiteral("\r\n                    <div  class=\"searchToFrom row mb-2\">\r\n\r\n                        <div class=\"col-md-2 col-sm-12\">\r\n                            <div class=\"d-flex justify-content-around align-items-center\">\r\n                                <div");
                BeginWriteAttribute("class", " class=\"", 805, "\"", 813, 0);
                EndWriteAttribute();
                WriteLiteral(@">Từ: </div>
                                <input type=""date"" id=""from"" name=""from"" placeholder=""Từ"" class="" form-control"" />
                            </div>
                        </div>
                        <div class=""col-md-2 col-sm-12"">
                            <div class=""d-flex justify-content-around align-items-center"">
                                <div");
                BeginWriteAttribute("class", " class=\"", 1197, "\"", 1205, 0);
                EndWriteAttribute();
                WriteLiteral(@">Đến: </div>
                                <input type=""date"" id=""to"" name=""to"" placeholder=""Đến"" class="" form-control"" />
                            </div>
                        </div>

                        <div class=""col-md-7 col-sm-12"" style=""z-index:1"">

                            <select data-search=""true"" name=""Idhh""
                                    id=""multipleSelect"">
                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fab8c8e976ea860f7a9ebd9cce8358b66f03a66e7796", async() => {
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
#line 35 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Phieunhapkho\ShowReport.cshtml"
                                 foreach (var item in hanghoa)
                                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fab8c8e976ea860f7a9ebd9cce8358b66f03a66e9345", async() => {
#nullable restore
#line 37 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Phieunhapkho\ShowReport.cshtml"
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
#line 37 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Phieunhapkho\ShowReport.cshtml"
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
#line 38 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Phieunhapkho\ShowReport.cshtml"

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
                        </div>
                        <input name=""action"" type=""hidden"" id=""action"" />
                    </div>
                ");
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
                <table class=""table table-striped table-bordered"" id=""productTable"" style=""max-height:60vh;overflow-y:scroll"">
                    <thead>
                        <tr class=""text-center"">

                            <th scope=""col"">Nhà cung cấp</th>
                            <th scope=""col"">Ngày nhập</th>
                            <th scope=""col"">Số Phiếu</th>
                            <th scope=""col"">Số lô</th>
                            <th scope=""col"">Mã hàng hóa</th>
                            <th scope=""col"">Tên hàng hóa</th>
                            <th scope=""col"">ĐVT</th>
                            <th scope=""col"">Số lượng</th>
                            <th scope=""col"">Đơn giá nhập(đ)</th>
                            <th scope=""col"">Thành tiền(đ)</th>

                        </tr>
                    </thead>

                    <tbody>

");
#nullable restore
#line 81 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Phieunhapkho\ShowReport.cshtml"
                         foreach (var item in Model)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr class=\"tr\">\r\n                                <td>");
#nullable restore
#line 84 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Phieunhapkho\ShowReport.cshtml"
                               Write(item.IdpnkNavigation.IdnccNavigation.Tenncc);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n");
#nullable restore
#line 86 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Phieunhapkho\ShowReport.cshtml"
                                  
                                    DateTime Ngaylap = (DateTime)item.IdpnkNavigation.Ngaylap;

                                

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <td class=\"text-center\">");
#nullable restore
#line 90 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Phieunhapkho\ShowReport.cshtml"
                                                   Write(Ngaylap.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 91 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Phieunhapkho\ShowReport.cshtml"
                               Write(item.IdpnkNavigation.Sophieu);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 92 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Phieunhapkho\ShowReport.cshtml"
                               Write(item.Solo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 93 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Phieunhapkho\ShowReport.cshtml"
                               Write(item.IdhhNavigation.Mavl);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 94 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Phieunhapkho\ShowReport.cshtml"
                               Write(item.IdhhNavigation.Tenvl);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 95 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Phieunhapkho\ShowReport.cshtml"
                               Write(item.Donvitinh);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td class=\"soluong text-right\">");
#nullable restore
#line 96 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Phieunhapkho\ShowReport.cshtml"
                                                          Write(item.Soluong);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n\r\n");
#nullable restore
#line 99 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Phieunhapkho\ShowReport.cshtml"
                                  
                                    var Dongia = String.Format("{0:0,0}", (@item.Dongia));
                                    var ThanhTien = String.Format("{0:0,0}", (@item.Soluong * @item.Dongia));
                                

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <td class=\"gianhap text-right\">");
#nullable restore
#line 103 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Phieunhapkho\ShowReport.cshtml"
                                                          Write(Dongia);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td class=\"thanhtien text-right\">");
#nullable restore
#line 104 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Phieunhapkho\ShowReport.cshtml"
                                                            Write(ThanhTien);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            </tr>\r\n");
#nullable restore
#line 106 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Phieunhapkho\ShowReport.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        <tr>
                            <td style=""border:none""></td>
                            <td style=""border:none""></td>
                            <td style=""border:none""></td>
                            <td style=""border: none; font-weight: bolder"">TỔNG CỘNG</td>
                            <td style=""border:none""></td>
                            <td style=""border:none""></td>
                            <td style=""border:none""></td>
                            <td style=""font-weight:bolder;"" class=""text-right"" id=""Tongsoluong""></td>
                            <td style=""font-weight:bolder"" class=""text-right"" id=""Tonggianhap""></td>
                            <td style=""font-weight:bolder"" class=""text-right"" id=""Tongthanhtien""></td>
                        </tr>
                    </tbody>
                </table>

            </div>
        </div>
    </div>
</div>





<script>
    window.addEventListener(""load"", totalReportNhapKho);

    function tot");
            WriteLiteral(@"alReportNhapKho() {
        let Tongsoluong = document.getElementById(""Tongsoluong"");
        let Tonggianhap = document.getElementById(""Tonggianhap"");
        let Tongthanhtien = document.getElementById(""Tongthanhtien"");
        let soluong = document.querySelectorAll("".soluong"");
        let gianhap = document.querySelectorAll("".gianhap"");
        let thanhtien = document.querySelectorAll("".thanhtien"");
        let tr = document.querySelectorAll("".tr"");
        let SL = 0, Gia = 0, Tong = 0;

        for (let i = 0; i < tr.length; i++) {
            SL += Number(soluong[i].innerText);
            Gia += Number(((gianhap[i].innerText).replaceAll("","", """")));
            Tong += Number(((thanhtien[i].innerText).replaceAll("","", """")));

        };
        console.log(SL);
        console.log(Gia);
        console.log(Tong);
        Formater = new Intl.NumberFormat('vi-VN');

        Tongsoluong.innerText = SL;
        Tonggianhap.innerText = (Formater.format(Gia)).replaceAll(""."", "","");
   ");
            WriteLiteral(@"     Tongthanhtien.innerText = (Formater.format(Tong)).replaceAll(""."", "","");

    }


</script>

<script>
    const reportForm = document.getElementById(""reportForm"");
    const exportBtn = document.getElementById(""export"");
    const csvBtn = document.getElementById(""csv"");
    const searchDateBtn = document.getElementById(""searchDate"");
    let action = document.getElementById(""action"");

    exportBtn.addEventListener(""click"", function () {
        action.value = ""export"";
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fab8c8e976ea860f7a9ebd9cce8358b66f03a66e22696", async() => {
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ElectronicsStore.Models.Noidungpnk>> Html { get; private set; }
    }
}
#pragma warning restore 1591