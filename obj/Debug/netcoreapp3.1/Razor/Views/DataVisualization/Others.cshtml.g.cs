#pragma checksum "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\DataVisualization\Others.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ec5ae81b342a1ed7767f7d1e856b374fbd5358aa"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_DataVisualization_Others), @"mvc.1.0.view", @"/Views/DataVisualization/Others.cshtml")]
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
#line 2 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\DataVisualization\Others.cshtml"
using ElectronicsStore.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ec5ae81b342a1ed7767f7d1e856b374fbd5358aa", @"/Views/DataVisualization/Others.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d5b5393bb9c64daa29820e07180089a8626bd590", @"/Views/_ViewImports.cshtml")]
    public class Views_DataVisualization_Others : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ElectronicsStore.Models.Dondathang>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Others", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "DataVisualization", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/multiSelectDropdown/virtual-select.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 4 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\DataVisualization\Others.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "_Admin";
    ElectronicsStoreContext _context = new ElectronicsStoreContext();

    List<Hanghoa> hanghoa = _context.Hanghoa.Where(V => V.Active == 1).ToList();


#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"row\">\r\n\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ec5ae81b342a1ed7767f7d1e856b374fbd5358aa5607", async() => {
                WriteLiteral("\r\n\r\n        <div class=\"ml-2 row mb-2\">\r\n\r\n            <div class=\"col-md-3 col-sm-12\">\r\n                <div class=\"d-flex justify-content-around align-items-center\">\r\n                    <div");
                BeginWriteAttribute("class", " class=\"", 606, "\"", 614, 0);
                EndWriteAttribute();
                WriteLiteral(@">Từ: </div>
                    <input type=""date"" id=""from"" name=""from"" placeholder=""Từ"" class="" form-control"" />
                </div>
            </div>
            <div class=""col-md-3 col-sm-12"">
                <div class=""d-flex justify-content-around align-items-center"">
                    <div");
                BeginWriteAttribute("class", " class=\"", 926, "\"", 934, 0);
                EndWriteAttribute();
                WriteLiteral(@">Đến: </div>
                    <input type=""date"" id=""to"" name=""to"" placeholder=""Đến"" class="" form-control"" />
                </div>
            </div>

            <div class=""col-md-5 col-sm-12"" style=""z-index:1"">

                <select data-search=""true"" name=""Idhh""
                        id=""multipleSelect"">
                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ec5ae81b342a1ed7767f7d1e856b374fbd5358aa7072", async() => {
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
#line 36 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\DataVisualization\Others.cshtml"
                     foreach (var item in hanghoa)
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ec5ae81b342a1ed7767f7d1e856b374fbd5358aa8586", async() => {
#nullable restore
#line 38 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\DataVisualization\Others.cshtml"
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
#line 38 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\DataVisualization\Others.cshtml"
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
#line 39 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\DataVisualization\Others.cshtml"

                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </select>\r\n            </div>\r\n            <div class=\"col-md-1 col-sm-12\">\r\n                <input type=\"submit\" id=\"searchDate\" value=\"Trực quan\" class=\"btn btn-primary\" />\r\n            </div>\r\n        </div>\r\n\r\n\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n<div style=\"height:90vh\">\r\n    <ul class=\"tabs row text-center\">\r\n");
            WriteLiteral("\r\n        <li class=\"tab-link  col-md-2 current\" data-tab=\"tab-1\">Top 5 sản phẩm được mua nhiều</li>\r\n        <li class=\"tab-link  col-md-2\" data-tab=\"tab-2\">Top 5 Khách hàng chi nhiều nhất</li>\r\n\r\n    </ul>\r\n\r\n\r\n");
#nullable restore
#line 62 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\DataVisualization\Others.cshtml"
     if (ViewData["Date"] != null)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <h3 class=\"text-center mt-2\">");
#nullable restore
#line 64 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\DataVisualization\Others.cshtml"
                                Write(ViewData["Date"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h3>
        <div id=""tab-1"" class=""tab-content current"">

            <div style=""max-width:100%; max-height:80vh"">
                <h3 class=""text-center"">Biểu đồ cột</h3>
                <canvas id=""top5ProductbySales""></canvas>

            </div>
           

        </div>
");
            WriteLiteral("        <div id=\"tab-2\" class=\"tab-content\">\r\n\r\n            <div style=\"max-width:100%; max-height:80vh\"");
            BeginWriteAttribute("class", " class=\"", 2637, "\"", 2645, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                <h3 class=\"text-center\">Biểu đồ cột</h3>\r\n                <canvas id=\"top5Customer\"></canvas>\r\n\r\n            </div>\r\n         \r\n        </div>\r\n");
#nullable restore
#line 85 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\DataVisualization\Others.cshtml"

       
    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
</div>
<script src=""https://ajax.googleapis.com/ajax/libs/jquery/3.6.3/jquery.min.js""></script>
<script src=""https://cdnjs.cloudflare.com/ajax/libs/Chart.js/4.2.1/chart.min.js""></script>
<script src=""https://cdn.jsdelivr.net/npm/chart.js""></script>
<script>
    //TỔNG NHẬP TẤT CẢ
    let top5ProductbySales =");
#nullable restore
#line 95 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\DataVisualization\Others.cshtml"
                       Write(Html.Raw(ViewBag.top5ProductbySales));

#line default
#line hidden
#nullable disable
            WriteLiteral(@";
    const top5ProductbySalesIDHH = top5ProductbySales.map(obj => obj[Object.keys(obj)[0]]);
    const top5ProductbySalesTENHH = top5ProductbySales.map(obj => obj[Object.keys(obj)[1]]);
    const top5ProductbySalesMAHH = top5ProductbySales.map(obj => obj[Object.keys(obj)[2]]);
    const top5ProductbySalesSL = top5ProductbySales.map(obj => obj[Object.keys(obj)[4]]);
    //const top5ProductbySalesDONGIA = top5ProductbySales.map(obj => obj[Object.keys(obj)[4]]);
    const top5ProductbySalesTHANHTIEN = top5ProductbySales.map(obj => obj[Object.keys(obj)[5]]);


    var top5ProductbySales_bar = document.getElementById('top5ProductbySales').getContext('2d');
    var myChart_nhap_bar = new Chart(top5ProductbySales_bar, {
        type: 'bar',
        data: {
            labels: top5ProductbySalesTENHH,
            datasets: [{
                label: 'TOP 5 Tổng giá trị hàng hóa đã xuất',
                data: top5ProductbySalesSL,
                backgroundColor: [
                    'rgba(255, 99,");
            WriteLiteral(@" 132, 0.2)',
                    'rgba(54, 162, 235, 0.2)',
                    'rgba(255, 206, 86, 0.2)',
                    'rgba(75, 192, 192, 0.2)',
                    'rgba(153, 102, 255, 0.2)',
                    'rgba(255, 159, 64, 0.2)'
                ],
                borderColor: [
                    'rgba(255, 99, 132, 1)',
                    'rgba(54, 162, 235, 1)',
                    'rgba(255, 206, 86, 1)',
                    'rgba(75, 192, 192, 1)',
                    'rgba(153, 102, 255, 1)',
                    'rgba(255, 159, 64, 1)'
                ],
                borderWidth: 1,
                barThickness: 120

            }]
        },
        options: {
            //responsive: true,
            //maintainAspectRatio: false,
            scales: {
                y: {
                    beginAtZero: true
                },

            }
        }
    });
   

</script>
<script>
    //TỔNG XUẤT TẤT CẢ
    let top5Customer =");
#nullable restore
#line 149 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\DataVisualization\Others.cshtml"
                 Write(Html.Raw(ViewBag.top5Customer));

#line default
#line hidden
#nullable disable
            WriteLiteral(@";
    const top5CustomerIDKH = top5Customer.map(obj => obj[Object.keys(obj)[0]]);
    const top5CustomerMAKH = top5Customer.map(obj => obj[Object.keys(obj)[1]]);
    const top5CustomerTENKH = top5Customer.map(obj => obj[Object.keys(obj)[2]]);
    const top5CustomerGT = top5Customer.map(obj => obj[Object.keys(obj)[3]]);
    const top5CustomerTONGTIEN = top5Customer.map(obj => obj[Object.keys(obj)[5]]);


    var top5Customer_bar = document.getElementById('top5Customer').getContext('2d');
    var myChart_xuat_bar = new Chart(top5Customer_bar, {
        type: 'bar',
        data: {
            labels: top5CustomerTENKH,
            datasets: [{
                label: 'TOP 5 Tổng giá trị khách hàng đã mua',
                data: top5CustomerTONGTIEN,
                backgroundColor: [
                    'rgba(255, 99, 132, 0.2)',
                    'rgba(54, 162, 235, 0.2)',
                    'rgba(255, 206, 86, 0.2)',
                    'rgba(75, 192, 192, 0.2)',
                    'rg");
            WriteLiteral(@"ba(153, 102, 255, 0.2)',
                    'rgba(255, 159, 64, 0.2)'
                ],
                borderColor: [
                    'rgba(255, 99, 132, 1)',
                    'rgba(54, 162, 235, 1)',
                    'rgba(255, 206, 86, 1)',
                    'rgba(75, 192, 192, 1)',
                    'rgba(153, 102, 255, 1)',
                    'rgba(255, 159, 64, 1)'
                ],
                borderWidth: 1,
                barThickness: 120

            }]
        },
        options: {
            //responsive: true,
            //maintainAspectRatio: false,
            scales: {
                y: {
                    beginAtZero: true
                },

            }
        }
    });


</script>




");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ec5ae81b342a1ed7767f7d1e856b374fbd5358aa19080", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ElectronicsStore.Models.Dondathang>> Html { get; private set; }
    }
}
#pragma warning restore 1591
