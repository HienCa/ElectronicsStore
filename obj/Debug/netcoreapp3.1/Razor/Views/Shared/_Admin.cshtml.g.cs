#pragma checksum "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Shared\_Admin.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9d84b6e3e2a88531b404b05d0efd16fad257fe30"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__Admin), @"mvc.1.0.view", @"/Views/Shared/_Admin.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9d84b6e3e2a88531b404b05d0efd16fad257fe30", @"/Views/Shared/_Admin.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d5b5393bb9c64daa29820e07180089a8626bd590", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__Admin : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/SidebarAdmin.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/multiSelectDropdown/virtual-select.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/tab/tab.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Logout", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Access", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/tab/tab.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("<!DOCTYPE html>\r\n<!-- Created by CodingLab |www.youtube.com/CodingLabYT-->\r\n<html lang=\"en\" dir=\"ltr\">\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9d84b6e3e2a88531b404b05d0efd16fad257fe306138", async() => {
                WriteLiteral(@"
    <meta charset=""UTF-8"">
    <link rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.3.0/css/all.min.css""
          integrity=""sha512-SzlrxWUlpfuzQ+pcUCosxcglQRNAq/DZjVsC0lE40xsADsfeQoEypE+enwcOiGjk/bSuGGKHEyjSoQ1zVisanQ==""
          crossorigin=""anonymous"" referrerpolicy=""no-referrer"" />
    <!--<title> Drop Down Sidebar Menu | CodingLab </title>-->
    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "9d84b6e3e2a88531b404b05d0efd16fad257fe306798", async() => {
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
                WriteLiteral(@"

    <link rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.1/css/all.min.css""
          integrity=""sha512-+4zCK9k+qNFUR5X+cKL9EIR+ZOhtIloNl9GIKS57V1MyNsYpYcUrUeQc9vNfzsWfV28IaLL3i96P9sdNyeRssA==""
          crossorigin=""anonymous"" />
    <!-- Boxiocns CDN Link -->
    <link href='https://unpkg.com/boxicons@2.0.7/css/boxicons.min.css' rel='stylesheet'>
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <link rel=""stylesheet"" type=""text/css""
          href=""https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css"">
    <!-- DataTables CSS -->
    <link rel=""stylesheet"" href=""https://cdn.datatables.net/1.10.25/css/jquery.dataTables.min.css"">
    <script src=""https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js""></script>
    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "9d84b6e3e2a88531b404b05d0efd16fad257fe308827", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "9d84b6e3e2a88531b404b05d0efd16fad257fe3010005", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9d84b6e3e2a88531b404b05d0efd16fad257fe3011892", async() => {
                WriteLiteral(@"
    <div class=""sidebar close"">
        <div class=""logo-details text-center"">
            <i class='bx bx-menu' style=""cursor: pointer;""></i>
            
            <span class=""logo_name""><a style=""text-decoration:none;color:black"">ElectronicsStore</a></span>

        </div>
        <ul class=""nav-links"">
            <!-- <li>
              <a href=""#"">
                <i class='bx bx-grid-alt'></i>
                <span class=""link_name"">Dashboard</span>
              </a>
              <ul class=""sub-menu blank"">
                <li><a class=""link_name"" href=""#"">Category</a></li>
              </ul>
            </li> -->
            <li>
                <div class=""iocn-link"">
                    <a href=""#"">
                        <i class='bx bx-collection'></i>
                        <span class=""link_name"">Danh Mục</span>
                    </a>
                    <i class='bx bxs-chevron-down arrow'></i>
                </div>
                <ul class=""sub-menu fadeI");
                WriteLiteral(@"nDown"">
                    <li><a class=""link_name"" href=""#"">Danh Mục</a></li>
                    <li><a href=""/Nhomhh/Index"">Nhóm hàng hóa</a></li>
                    <li><a href=""/Thuonghieu/Index"">Thương hiệu</a></li>
                    <li><a href=""/Nuosx/Index"">Nước sản xuất</a></li>
                    <li><a href=""/Nhacungcap/Index"">Nhà cung cấp</a></li>
                    <li><a href=""/Hanghoa/Index"">Hàng Hóa</a></li>
");
                WriteLiteral(@"                    <li><a href=""/Nhanvien/Index"">Nhân viên</a></li>
                    <li><a href=""/Khachhang/Index"">Khách hàng</a></li>
                    <li><a href=""/Nganhang/Index"">Ngân hàng</a></li>
                    <li><a href=""/Hinhthucthanhtoan/Index"">Hình thức thanh toán</a></li>
                   

                </ul>
            </li>
            <li>
                <div class=""iocn-link"">
                    <a href=""#"">
                        <i class='bx bx-book-alt'></i>
                        <span class=""link_name"">Quản lý</span>
                    </a>
                    <i class='bx bxs-chevron-down arrow'></i>
                </div>
                <ul class=""sub-menu"">
                    <li><a class=""link_name"" href=""#"">Quản lý</a></li>
                    <li><a href=""/Dondathang/Index"">Đơn đặt hàng</a></li>
                    <li><a href=""/Phieunhapkho/Index"">Phiếu Nhập kho</a></li>
                    <li><a href=""/Phieuxuatkho/Index"">Phiếu Xuất K");
                WriteLiteral(@"ho</a></li>
                    <li><a href=""/Phieuthunokh/Index"">Phiếu Thu Nợ</a></li>
                    <li><a href=""/Phieutranoncc/Index"">Phiếu Trả Nợ</a></li>
                </ul>
            </li>
            <li>
                <div class=""iocn-link"">
                    <a href=""#"">
                        <!-- <i class='bx bx-book-alt'></i> -->
                        <i class='bx bx-line-chart'></i>

                        <span class=""link_name"">Thống Kê</span>
                    </a>
                    <i class='bx bxs-chevron-down arrow'></i>
                </div>
                <ul class=""sub-menu"">
                    <li><a class=""link_name"" href=""#"">Thống kê</a></li>
                    <li><a href=""/Phieunhapkho/ShowReport"">Nhập kho</a></li>
                    <li><a href=""/Phieuxuatkho/ShowReport"">Xuất Kho</a></li>
                    <li><a href=""/Phieunhapkho/InventoryReport"">Tồn Kho</a></li>
                    <li><a href=""/Phieunhapkho/XuatNhapTonReport"">Xu");
                WriteLiteral(@"ất Nhập Tồn</a></li>
                    <li><a href=""/DataVisualization/Index"">Data Visualization</a></li>
                </ul>
            </li>
            <li>
                <div class=""iocn-link"">
                    <a href=""#"">
                        <i class='bx bx-cog'></i>
                        <span class=""link_name"">Cài đặt</span>
                    </a>
                    <i class='bx bxs-chevron-down arrow'></i>
                </div>
                <ul class=""sub-menu"">
                    <li><a class=""link_name"" href=""#"">Cài đặt</a></li>
");
                WriteLiteral(@"                    <li><a href=""/Home/Settings"">Số dòng hiển thị</a></li>
                </ul>
            </li>

            <li>
                <div class=""profile-details"">
                    <div class=""profile-content"">
                        <!--<img src=""image/profile.jpg"" alt=""profileImg"">-->
                    </div>
                    <div class=""name-job"">
                        <!-- <div class=""profile_name"">HSHOP</div> -->
                    </div>
                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9d84b6e3e2a88531b404b05d0efd16fad257fe3017055", async() => {
                    WriteLiteral("\r\n                        <button type=\"submit\" style=\"border:none\"> <i class=\'bx bx-log-out\'></i></button>\r\n                    ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_5.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\r\n                </div>\r\n            </li>\r\n        </ul>\r\n    </div>\r\n    <section class=\"home-section\" style=\"background-color: #eeeeee;\">\r\n        <div class=\"home-content d-flex justify-content-center\">\r\n            <h2 class=\"text-center\">");
#nullable restore
#line 139 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Shared\_Admin.cshtml"
                               Write(ViewBag.Head);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h2>\r\n\r\n        </div>\r\n        <div class=\"ml-2 mr-2\">\r\n            <div class=\"p-2 rounded\" style=\"background-color: #fff;\">\r\n                ");
#nullable restore
#line 144 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Shared\_Admin.cshtml"
           Write(RenderBody());

#line default
#line hidden
#nullable disable
                WriteLiteral(@"

            </div>

        </div>
    </section>


    <!-- Sidebar Admin-->
    <script>
        let arrow = document.querySelectorAll("".arrow"");
        for (var i = 0; i < arrow.length; i++) {
            arrow[i].addEventListener(""click"", (e) => {
                let arrowParent = e.target.parentElement.parentElement;//selecting main parent of arrow
                arrowParent.classList.toggle(""showMenu"");
            });
        }
        let sidebar = document.querySelector("".sidebar"");
        let sidebarBtn = document.querySelector("".bx-menu"");
        console.log(sidebarBtn);
        sidebarBtn.addEventListener(""click"", () => {
            sidebar.classList.toggle(""close"");
        });
    </script>



    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9d84b6e3e2a88531b404b05d0efd16fad257fe3020554", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
    <!-- Custom table -->
    <!-- DataTables JS -->
    <script src=""https://cdn.datatables.net/1.10.25/js/jquery.dataTables.min.js""></script>

    <!-- Vietnamese language file for DataTables -->
    <script src=""https://cdn.datatables.net/plug-ins/1.10.25/i18n/Vietnamese.json""></script>
    <script src=""https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js""></script>

    <script>
        var defaultLength = 10;

        // Nếu đã lưu trữ số hàng hiển thị trên localstorage thì lấy giá trị đó
        if (localStorage.getItem(""productTableLength"")) {
            defaultLength = parseInt(localStorage.getItem(""productTableLength""));
        }

        $(document).ready(function () {
            $('#productTable').DataTable({
                ""lengthMenu"": [[10, 25, 50, -1], [10, 25, 50, ""All""]],
                ""language"": {
                    ""lengthMenu"": ""Hiển thị _MENU_ bản ghi"",
                    ""search"": ""Tìm kiếm:"",
                },
                ""pageLength");
                WriteLiteral(@""": defaultLength, // Số bản ghi hiển thị ban đầu
                ""search"": {
                    ""search"": """", // Giá trị tìm kiếm ban đầu
                    ""placeholder"": ""Tìm kiếm..."", // Chú thích tìm kiếm
                },
                ""language"": {
                    ""decimal"": """",
                    ""emptyTable"": ""Không có dữ liệu"",
                    ""info"": ""Hiển thị từ _START_ đến _END_ của _TOTAL_ bản ghi"",
                    ""infoEmpty"": ""Hiển thị từ 0 đến 0 của 0 bản ghi"",
                    ""infoFiltered"": ""(được lọc từ tổng số _MAX_ bản ghi)"",
                    ""infoPostFix"": """",
                    ""thousands"": "","",
                    ""lengthMenu"": ""Hiển thị _MENU_ bản ghi"",
                    ""loadingRecords"": ""Đang tải..."",
                    ""processing"": ""Đang xử lý..."",
                    ""search"": ""Tìm kiếm:"",
                    ""zeroRecords"": ""Không tìm thấy bản ghi nào phù hợp"",

                    ""paginate"": {
                        ""first"": ""Đầ");
                WriteLiteral(@"u tiên"",
                        ""last"": ""Cuối cùng"",
                        ""next"": ""Sau"",
                        ""previous"": ""Trước""
                    },
                    ""aria"": {
                        ""sortAscending"": "": Sắp xếp tăng dần"",
                        ""sortDescending"": "": Sắp xếp giảm dần""
                    }
                }

            });
        });


        // Lưu trữ số hàng hiển thị vào localstorage khi người dùng thay đổi giá trị
        $('#productTable').on('length.dt', function (e, settings, len) {
            localStorage.setItem(""productTableLength"", len);
        });


    </script>
    ");
#nullable restore
#line 237 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Shared\_Admin.cshtml"
Write(await RenderSectionAsync("Scripts", required: false));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n");
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
