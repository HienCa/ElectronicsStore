#pragma checksum "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Home\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1bbf99bcc8ae8cfaf20c10b2b05c5507fac548c9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Details), @"mvc.1.0.view", @"/Views/Home/Details.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1bbf99bcc8ae8cfaf20c10b2b05c5507fac548c9", @"/Views/Home/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d5b5393bb9c64daa29820e07180089a8626bd590", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ElectronicsStore.ViewModel.HanghoaViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width: 430px;height: 600px;border-radius: 5px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-responsive"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Home\Details.cshtml"
  
    Layout = "_Home";

#line default
#line hidden
#nullable disable
            WriteLiteral("<div");
            BeginWriteAttribute("class", " class=\"", 87, "\"", 95, 0);
            EndWriteAttribute();
            WriteLiteral(" style=\"margin-top:70px;\">\r\n    <div");
            BeginWriteAttribute("class", " class=\"", 132, "\"", 140, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n        <div class=\"card\">\r\n            <div class=\"card-body\">\r\n                <h3 class=\"card-title\">");
#nullable restore
#line 9 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Home\Details.cshtml"
                                  Write(Model.Tenvl);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n                <h6 class=\"card-subtitle\">Mã sản phẩm: ");
#nullable restore
#line 10 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Home\Details.cshtml"
                                                  Write(Model.Mavl);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n                <div class=\"row\">\r\n                    <div class=\"col-lg-5 col-md-12 col-sm-12\">\r\n                        <div class=\"white-box text-center \">\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "1bbf99bcc8ae8cfaf20c10b2b05c5507fac548c95197", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 594, "~/Images/", 594, 9, true);
#nullable restore
#line 14 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Home\Details.cshtml"
AddHtmlAttributeValue("", 603, Model.ExistingImage, 603, 20, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n                    <div class=\"col-lg-7 col-md-12 col-sm-12\">\r\n\r\n                     \r\n");
#nullable restore
#line 21 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Home\Details.cshtml"
                         if (Model.Giakm != null)
                        {
                        float? giakm = Model.Giakm;
                                        string giakms = giakm.HasValue ? giakm.Value.ToString("#,###.##") : "";

                                        string giabans = (Model.Giaban).ToString("#,###.##");

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"d-flex mt-2\">\r\n                            <h1 class=\"text-danger font-weight-bolder mr-2\">");
#nullable restore
#line 28 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Home\Details.cshtml"
                                                                       Write(giakms);

#line default
#line hidden
#nullable disable
            WriteLiteral(" đ</h1>\r\n                            <h5 class=\"text-dark \" style=\"text-decoration: line-through; opacity: 0.7;\">");
#nullable restore
#line 29 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Home\Details.cshtml"
                                                                                                   Write(giabans);

#line default
#line hidden
#nullable disable
            WriteLiteral(" đ</h5>\r\n                        </div>\r\n");
#nullable restore
#line 31 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Home\Details.cshtml"
                        }
                        else
                        {
                            string giabans = (Model.Giaban).ToString("#,###.##");


#line default
#line hidden
#nullable disable
            WriteLiteral("                        <h1 class=\"text-danger font-weight-bolder mr-2\">");
#nullable restore
#line 36 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Home\Details.cshtml"
                                                                   Write(giabans);

#line default
#line hidden
#nullable disable
            WriteLiteral(" đ</h1>\r\n");
#nullable restore
#line 37 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Home\Details.cshtml"

                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                        <h4 class=\"box-title mt-3\">Mô tả sản phẩm</h4>\r\n                        <p>\r\n                            ");
#nullable restore
#line 43 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Home\Details.cshtml"
                       Write(Model.Mota);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        </p>
                        <div class=""d-flex mt-5 mb-1"">
                            <button class=""btn btn-lg btn-danger text-white w-75 mr-2"">MUA NGAY</button>
                            <button class=""btn btn-lg w-25 btn-primary btn-rounded"">TRẢ GÓP</button>
                        </div>
                        <span>Gọi <span class=""text-danger"">0506-2001</span> để được tư vấn mua hàng (Miễn phí)</span>
                        <h3 class=""box-title mt-4"">Key Highlights</h3>
                        <ul class=""list-unstyled"">
                            <li><i class=""fa fa-check text-success""></i>Sturdy structure</li>
                            <li><i class=""fa fa-check text-success""></i>Designed to foster easy portability</li>
                            <li>
                                <i class=""fa fa-check text-success""></i>Perfect furniture to flaunt your wonderful
                                collectibles
                            </li>
            ");
            WriteLiteral(@"            </ul>
                    </div>
                    <div class=""col-lg-12 col-md-12 col-sm-12"">
                        <h3 class=""box-title mt-5"">Thông số kỹ thuật</h3>
                        <div class=""table-responsive"">
                            <table class=""table table-striped table-product"">
                                <tbody>
                                    <tr>
                                        <td width=""390"">Brand</td>
                                        <td>Stellar</td>
                                    </tr>
                                    <tr>
                                        <td>Delivery Condition</td>
                                        <td>Knock Down</td>
                                    </tr>
                                    <tr>
                                        <td>Seat Lock Included</td>
                                        <td>Yes</td>
                                    </tr>
                           ");
            WriteLiteral(@"         <tr>
                                        <td>Type</td>
                                        <td>Office Chair</td>
                                    </tr>
                                    <tr>
                                        <td>Style</td>
                                        <td>Contemporary&amp;Modern</td>
                                    </tr>
                                    <tr>
                                        <td>Wheels Included</td>
                                        <td>Yes</td>
                                    </tr>
                                    <tr>
                                        <td>Upholstery Included</td>
                                        <td>Yes</td>
                                    </tr>
                                    <tr>
                                        <td>Upholstery Type</td>
                                        <td>Cushion</td>
                                    </tr>
          ");
            WriteLiteral(@"                          <tr>
                                        <td>Head Support</td>
                                        <td>No</td>
                                    </tr>
                                    <tr>
                                        <td>Suitable For</td>
                                        <td>Study&amp;Home Office</td>
                                    </tr>
                                    <tr>
                                        <td>Adjustable Height</td>
                                        <td>Yes</td>
                                    </tr>
                                    <tr>
                                        <td>Model Number</td>
                                        <td>F01020701-00HT744A06</td>
                                    </tr>
                                    <tr>
                                        <td>Armrest Included</td>
                                        <td>Yes</td>
                        ");
            WriteLiteral(@"            </tr>
                                    <tr>
                                        <td>Care Instructions</td>
                                        <td>
                                            Handle With Care,Keep In Dry Place,Do Not Apply Any Chemical For
                                            Cleaning.
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Finish Type</td>
                                        <td>Matte</td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<div class=""pl-4 pr-4 mt-3"" style=""border-radius: 10px;"">
    <div class=""bg-white p-4"">
        <div class=""border-bottom"">
            <h4>Đánh giá sản phẩm</h4>
   ");
            WriteLiteral(@"     </div>
        <div class="" mt-5 "">
            <div class=""text-center"">
                <p>Hãy là người đầu tiên đánh giá sản phẩm này</p>
                <button class=""btn btn-danger"" style=""opacity: 0.9;"">GỬI ĐÁNH GIÁ</button>
            </div>
        </div>

    </div>
</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ElectronicsStore.ViewModel.HanghoaViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591