#pragma checksum "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Shared\_Home.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8269e030633eaa26286a69c01f661a2732fae6f2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__Home), @"mvc.1.0.view", @"/Views/Shared/_Home.cshtml")]
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
#line 1 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Shared\_Home.cshtml"
using ElectronicsStore.ViewModel;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8269e030633eaa26286a69c01f661a2732fae6f2", @"/Views/Shared/_Home.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d5b5393bb9c64daa29820e07180089a8626bd590", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__Home : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/Index.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/tab/tab.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "OrderedDetails", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/tab/tab.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<!DOCTYPE html>\r\n\r\n<html lang=\"en\">\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8269e030633eaa26286a69c01f661a2732fae6f25863", async() => {
                WriteLiteral(@"
    <meta charset=""UTF-8"">
    <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <link rel=""stylesheet"" href=""https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css"">
    <link rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.1/css/all.min.css""
          integrity=""sha512-+4zCK9k+qNFUR5X+cKL9EIR+ZOhtIloNl9GIKS57V1MyNsYpYcUrUeQc9vNfzsWfV28IaLL3i96P9sdNyeRssA==""
          crossorigin=""anonymous"" />
    <!-- ===== CSS ===== -->
    <!-- ===== Boxicons CSS ===== -->
    <link href='https://unpkg.com/boxicons@2.1.1/css/boxicons.min.css' rel='stylesheet'>

    <!-- ===== Modal ===== -->

    <link href=""https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css"" rel=""stylesheet"">
    <script src=""https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js""></script>

    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "8269e030633eaa26286a69c01f661a2732fae6f27099", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "8269e030633eaa26286a69c01f661a2732fae6f28277", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    <style>\r\n        a {\r\n            text-decoration: none;\r\n        }\r\n\r\n        .div-hover:hover {\r\n            opacity: 0.6;\r\n        }\r\n\r\n        \r\n    </style>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8269e030633eaa26286a69c01f661a2732fae6f210352", async() => {
                WriteLiteral(@"
    <nav>
        <div class=""nav-bar "">
            <i class='bx bx-menu sidebarOpen'></i>
            <span class=""logo navLogo""><a href=""/Home/Index"">Electronics Store</a></span>
            <div class=""w-50"">
                <input id=""search-input"" type=""text"" class=""form-control w-100"" style=""border:none"" placeholder=""Bạn tìm linh kiện gì..."">

            </div>
            <div");
                BeginWriteAttribute("class", " class=\"", 1718, "\"", 1726, 0);
                EndWriteAttribute();
                WriteLiteral(@">
                <button type=""button"" class=""bg-white border-0 p-2 text-dark"" style=""border-radius: 5px"" data-bs-toggle=""modal"" data-bs-target=""#OrderDetail"">
                    Đơn hàng
                </button>

            </div>
            <div class=""menu "">
                <div class=""logo-toggle"">
                    <span class=""logo""><a href=""#"">Electronics Store</a></span>
                    <i class='bx bx-x siderbarClose'></i>
                </div>
                <div class=""row"">



                    <div class=""col-12"">
                        <a href=""/Home/Cart"" class=""bg-white p-2 text-dark"" style=""border-radius: 5px; text-decoration: none; position: relative;"">
                            <i class=""fas fa-cart-plus""
                               style=""color: #de0146""></i> Giỏ hàng <span class=""p-1"" style=""position:absolute;background-color: #fff;border-radius: 10px;color: #de0146;font-weight: bolder;top:-15px;right: -20px;box-shadow: rgba(100, 100, 111, 0.2) 0px ");
                WriteLiteral(@"7px 29px 0px;"">+<span id=""count-items"">0</span></span>
                        </a>
                    </div>

                </div>

            </div>

            <div class=""darkLight-searchBox"">
                <div class=""dark-light"">
                    <i class='bx bx-moon moon'></i>
                    <i class='bx bx-sun sun'></i>
                </div>

                <div class=""searchBox"">
                    <div class=""searchToggle"">
                        <i class='bx bx-x cancel'></i>
                        <i class='bx bx-search search'></i>
                    </div>

                    <div class=""search-field"">
                        <input id=""search-input2"" type=""text"" placeholder=""Nhập tên linh kiện..."">
                        <i class='bx bx-search'></i>
                    </div>
                </div>
            </div>
            <div class=""text-white "" style=""cursor:pointer"">
");
#nullable restore
#line 92 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Shared\_Home.cshtml"
                 if (ViewData["Login"] != null)
                {
                    KhachhangViewModel khachhangview = ViewData["Login"] as KhachhangViewModel;

#line default
#line hidden
#nullable disable
                WriteLiteral("                <div id=\"InfoDropDown\">\r\n                    <div class=\"d-flex justify-content-center align-items-center div1\" style=\"position: relative;\">\r\n");
#nullable restore
#line 97 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Shared\_Home.cshtml"
                         if (khachhangview.ExistingImage != null)
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <img");
                BeginWriteAttribute("src", " src=\"", 4155, "\"", 4197, 2);
                WriteAttributeValue("", 4161, "/Images/", 4161, 8, true);
#nullable restore
#line 99 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Shared\_Home.cshtml"
WriteAttributeValue("", 4169, khachhangview.ExistingImage, 4169, 28, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"mr-2\" style=\"width: 50px; height: 50px;border-radius: 50%;border:4px solid #fff\" /> <span> ");
#nullable restore
#line 99 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Shared\_Home.cshtml"
                                                                                                                                                                         Write(khachhangview.Tenkh);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</span>
                            <div class=""p-2 div2 product"" id=""InfoDropDownItem""
                                 style=""display:none;position: absolute;top: 50px;right:-50px;box-shadow: rgba(100, 100, 111, 0.2) 0px 7px 29px 0px;background-color: #de0146;border-radius: 5px;width:250px"">

                                <div class=""p-2 div-hover"">
                                    <a class=""div-hover-a"" href=""/Home/PersonalPage""
                                       style=""color: #fff;text-decoration: none;"">Thông tin cá nhân</a>
                                </div>
                                <div class=""p-2 div-hover"">
                                    <a class=""div-hover-a"" href=""/Home/OrderedDetails""
                                       style=""color: #fff;text-decoration: none;"">Lịch sử đơn hàng</a>
                                </div>
");
                WriteLiteral(@"                                <div class=""mt-2 p-2 div-hover"">
                                    <a href=""/Access/Logout""
                                       class=""div-hover-a"" style=""color: #fff;text-decoration: none;"">Đăng xuất</a>
                                </div>
                            </div>
");
#nullable restore
#line 120 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Shared\_Home.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <i class=\"fas fa-user-circle mr-3\" style=\"font-size: 32px\"></i> <span> ");
#nullable restore
#line 123 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Shared\_Home.cshtml"
                                                                                              Write(khachhangview.Tenkh);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span>\r\n");
#nullable restore
#line 124 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Shared\_Home.cshtml"

                        }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </div>\r\n                </div>\r\n");
#nullable restore
#line 129 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Shared\_Home.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                    <a style=""text-decoration:none;color:white "" href=""/Access/Login"">

                        <div class=""d-flex justify-content-center align-items-center"">
                            <i class=""fas fa-user-circle mr-3"" style=""font-size: 32px""></i> <span> Tài khoản</span>
                        </div>
                    </a>
");
#nullable restore
#line 138 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Shared\_Home.cshtml"

                }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
            </div>
        </div>
    </nav>

    <div id=""OrderDetail"" class=""modal fade "" tabindex=""-1"">

        <div class=""modal-dialog"">
            <div class=""modal-content container  text-white"" style=""background-color: #de0146;"">
                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8269e030633eaa26286a69c01f661a2732fae6f218312", async() => {
                    WriteLiteral(@"
                    <div class=""modal-header"">
                        <h1 class=""modal-title fs-5"" id=""exampleModalLabel"">Thông tin đơn hàng</h1>
                        <button type=""button"" class=""btn-close  text-white"" data-bs-dismiss=""modal"" aria-label=""Close""></button>
                    </div>
                    <div class=""modal-body"">
                        <h3 class=""text-center"">Electronics Store</h3>
                        <h4 class=""text-center mt-3"">Vui lòng cung cấp thông tin!</h4>
                        <div class=""d-flex justify-content-center mt-4"">
                            <div class="" w-75 "">
                                <span>Mã đơn hàng</span>
                                <textarea type=""text"" autofocus class=""form-control w-100 mb-2"" style=""height: 40px;"" required name=""Madh"" placeholder=""Nhập mã đơn hàng...""></textarea>
                                <span>Số điện thoại khi mua hàng</span>
                                <input type=""number"" minlength=""9"" m");
                    WriteLiteral(@"axlength=""12"" class=""form-control w-100 "" required name=""Sdt"" placeholder=""Nhập số điện thoại khi đặt hàng..."">
                            </div>
                        </div>
                    </div>
                    <div class=""modal-footer d-flex justify-content-center"">
                        <button type=""submit"" class=""btn btn-lg text-white"" style=""border: 4px solid #fff;"">Tra cứu</button>
                    </div>
                ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\r\n            </div>\r\n        </div>\r\n    </div>\r\n    ");
#nullable restore
#line 174 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Shared\_Home.cshtml"
Write(RenderBody());

#line default
#line hidden
#nullable disable
                WriteLiteral(@"

    <footer class=""text-center text-lg-start bg-white text-muted mt-3"">


        <!-- Section: Links  -->
        <section class=""pt-3"">
            <div class=""container text-center text-md-start mt-5"">
                <!-- Grid row -->
                <div class=""row mt-3"">
                    <!-- Grid column -->
                    <div class=""col-md-3 col-lg-4 col-xl-3 mx-auto mb-4"">
                        <!-- Content -->
                        <h6 class=""text-uppercase fw-bold mb-4"">
                            <i class=""fas fa-gem me-3""></i> Electronics Store
                        </h6>
                        <p>
                            Cảm Ơn !!!
                        </p>
                    </div>
                    <!-- Grid column -->
                    <!-- Grid column -->
                    <div class=""col-md-2 col-lg-2 col-xl-2 mx-auto mb-4"">
                        <!-- Links -->
                        <h6 class=""text-uppercase fw-bold mb-4"">
       ");
                WriteLiteral(@"                     Sản Phẩm
                        </h6>
                        <p>
                            <a href=""#!"" class=""text-reset"">Linh kiện điện tử</a>
                        </p>

                        <p>
                            <a href=""#!"" class=""text-reset"">Main Board</a>
                        </p>
                        <p>
                            <a href=""#!"" class=""text-reset"">Màn Hình</a>
                        </p>
                        <p>
                            <a href=""#!"" class=""text-reset"">VGA</a>
                        </p>
                    </div>

                    <div class=""col-md-3 col-lg-2 col-xl-2 mx-auto mb-4"">
                        <h6 class=""text-uppercase fw-bold mb-4"">
                            Trang liên quan
                        </h6>
                        <p>
                            <a href=""#!"" class=""text-reset"">...</a>
                        </p>
                        <p>
                  ");
                WriteLiteral(@"          <a href=""#!"" class=""text-reset"">...</a>
                        </p>
                        <p>
                            <a href=""#!"" class=""text-reset"">...</a>
                        </p>
                        <p>
                            <a href=""#!"" class=""text-reset"">...</a>
                        </p>
                    </div>

                    <div class=""col-md-4 col-lg-3 col-xl-3 mx-auto mb-md-0 mb-4"">
                        <h6 class=""text-uppercase fw-bold mb-4"">Contact</h6>
                        <p><i class=""fas fa-home me-3""></i> Bình Mỹ, Củ Chi, Hồ Chí Minh</p>
                        <p>
                            <i class=""fas fa-envelope me-3""></i>
                            electronicsstore@gmail.com
                        </p>
                        <p><i class=""fas fa-phone me-3""></i> + 0384319202</p>
                        <p><i class=""fas fa-print me-3""></i> + 0384319203</p>
                    </div>
                </div>
           ");
                WriteLiteral(@" </div>
        </section>

        <div class=""text-center p-4 "" style=""background-color: rgba(0, 0, 0, 0.05);"">
            © 2023. Công ty cổ phần ElectronicsStore. GPDKKD: 0303217... do sở KH & ĐT TP.HCM cấp ngày dd/MM/yyyy.
            GPMXH: 5-0-0/GP-BTTTT do Bộ Thông Tin và Truyền Thông cấp ngày dd/MM/yyyy.
            Địa chỉ: 001A, Bình Mỹ, Củ Chi, TP.Hồ Chí Minh. Điện thoại: 028 38122001. Email:
            cskh@ElectronicsStore.com. Chịu trách nhiệm nội dung: Nguyễn Văn Hiền.
        </div>
    </footer>
    <script src=""https://code.jquery.com/jquery-3.2.1.slim.min.js""
            integrity=""sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN""
            crossorigin=""anonymous""></script>

    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8269e030633eaa26286a69c01f661a2732fae6f225871", async() => {
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
                WriteLiteral(@"
    <script>

        const body = document.querySelector(""body""),
            nav = document.querySelector(""nav""),
            modeToggle = document.querySelector("".dark-light""),
            searchToggle = document.querySelector("".searchToggle""),
            sidebarOpen = document.querySelector("".sidebarOpen""),
            siderbarClose = document.querySelector("".siderbarClose"");

        let getMode = localStorage.getItem(""mode"");
        if (getMode && getMode === ""dark-mode"") {
            body.classList.add(""dark"");
        }

        // js code to toggle dark and light mode
        modeToggle.addEventListener(""click"", () => {
            modeToggle.classList.toggle(""active"");
            body.classList.toggle(""dark"");

            // js code to keep user selected mode even page refresh or file reopen
            if (!body.classList.contains(""dark"")) {
                localStorage.setItem(""mode"", ""light-mode"");
            } else {
                localStorage.setItem(""mode"", ""da");
                WriteLiteral(@"rk-mode"");
            }
        });

        // js code to toggle search box
        searchToggle.addEventListener(""click"", () => {
            searchToggle.classList.toggle(""active"");
        });


        //   js code to toggle sidebar
        sidebarOpen.addEventListener(""click"", () => {
            nav.classList.add(""active"");
        });

        body.addEventListener(""click"", e => {
            let clickedElm = e.target;

            if (!clickedElm.classList.contains(""sidebarOpen"") && !clickedElm.classList.contains(""menu"")) {
                nav.classList.remove(""active"");
            }
        });

    </script>


    <script>
        //search product
        // Lấy danh sách sản phẩm
        // Lấy danh sách sản phẩm
        const productList = document.getElementById('product-list').querySelectorAll('.productItem');

        // Lấy ô input và thêm sự kiện khi người dùng nhập giá trị vào ô input
        const searchInput = document.getElementById('search-input');
  ");
                WriteLiteral(@"      const searchInput2 = document.getElementById('search-input2');
        searchInput.addEventListener('input', () => {
            const keyword = searchInput.value.toLowerCase(); // Chuyển giá trị nhập vào thành chữ thường
            productList.forEach((product) => {
                const productName = product.querySelector('.card-title').innerText.toLowerCase(); // Lấy tên sản phẩm và chuyển thành chữ thường
                if (productName.includes(keyword)) { // Nếu tên sản phẩm chứa keyword, hiển thị sản phẩm đó
                    product.style.display = 'block';
                } else { // Nếu không, ẩn sản phẩm đó đi
                    product.style.display = 'none';
                }
            });
        });
        searchInput2.addEventListener('input', () => {
            const keyword = searchInput2.value.toLowerCase(); // Chuyển giá trị nhập vào thành chữ thường
            productList.forEach((product) => {
                const productName = product.querySelector('.card-");
                WriteLiteral(@"title').innerText.toLowerCase(); // Lấy tên sản phẩm và chuyển thành chữ thường
                if (productName.includes(keyword)) { // Nếu tên sản phẩm chứa keyword, hiển thị sản phẩm đó
                    product.style.display = 'block';
                } else { // Nếu không, ẩn sản phẩm đó đi
                    product.style.display = 'none';
                }
            });
        });


        // Đẩy các sản phẩm block lại gần nhau
        let visibleProducts = document.querySelectorAll("".card.product:not([style*='display: none'])"");
        for (let i = 0; i < visibleProducts.length; i++) {
            visibleProducts[i].classList.remove(""mb-2"");
            if (i !== visibleProducts.length - 1) {
                visibleProducts[i].classList.add(""mb-2"");
            }
        }



        const productType = document.querySelectorAll('.product-type');

        productType.forEach((type) => {
            type.addEventListener('click', () => {
                let Nhomhh = type");
                WriteLiteral(@".querySelector('.Idnhh').value;

                productList.forEach((product) => {
                    const productType = product.querySelector('.Idnhh').value.trim(); // Lấy tên sản phẩm và chuyển thành chữ thường
                    if (productType.includes(Nhomhh)) { // Nếu tên sản phẩm chứa keyword, hiển thị sản phẩm đó
                        product.style.display = 'block';
                    } else { // Nếu không, ẩn sản phẩm đó đi
                        product.style.display = 'none';

                    }
                });
            });


        });
    </script>
    <script>

        let cartItems = JSON.parse(localStorage.getItem('cartItems')) || [];
        document.getElementById(""count-items"").innerText = cartItems.length;


    </script>
    <script>
        const InfoDropDown = document.getElementById(""InfoDropDown"");
        const InfoDropDownItem = document.getElementById(""InfoDropDownItem"");
        InfoDropDown.addEventListener(""click"", function () {
  ");
                WriteLiteral(@"          if (InfoDropDownItem.style.display == ""none"") {
                InfoDropDownItem.style.display = ""block""
                console.log(""sssss"")
            } else if (InfoDropDownItem.style.display == ""block"") {
                InfoDropDownItem.style.display = ""none""
                console.log(""aaaa"")


            }
        })
    </script>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n</html>");
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
