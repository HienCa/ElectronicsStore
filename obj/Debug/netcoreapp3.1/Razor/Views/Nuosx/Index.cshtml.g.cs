#pragma checksum "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Nuosx\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3af169e9fe770de9f07edc96cf9b7f4679f6cefe"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Nuosx_Index), @"mvc.1.0.view", @"/Views/Nuosx/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3af169e9fe770de9f07edc96cf9b7f4679f6cefe", @"/Views/Nuosx/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d5b5393bb9c64daa29820e07180089a8626bd590", @"/Views/_ViewImports.cshtml")]
    public class Views_Nuosx_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ElectronicsStore.Models.Nuosx>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Nuosx", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "TrashList", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("formAdd"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("formEdit"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Nuosx\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "_Admin";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""d-flex justify-content-between mb-2"">

    <div class=""d-flex justify-content-between "">
        <button type=""button"" class=""btn btn-success mr-2"" data-toggle=""modal"" data-target=""#addModal"">
            Thêm mới nước sản xuất
        </button>
        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3af169e9fe770de9f07edc96cf9b7f4679f6cefe6231", async() => {
                WriteLiteral("\r\n            <button type=\"submit\" class=\"btn btn-info\">\r\n                <i class=\"fas fa-trash-restore\"></i>\r\n            </button>\r\n        ");
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
<div class=""table-responsive"">

    <table class=""table table-striped table-bordered"" id=""productTable"">
        <thead>
            <tr>
                <th class=""text-center"">ID</th>
                <th>Mã nước sản xuất</th>
                <th>Tên nước sản xuất</th>

                <th class=""d-none""></th>
                <th></th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 36 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Nuosx\Index.cshtml"
              
                int count = 1;
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 39 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Nuosx\Index.cshtml"
             foreach (var item in Model)
            {


#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td class=\"d-flex justify-content-center\">");
#nullable restore
#line 43 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Nuosx\Index.cshtml"
                                                         Write(count);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 44 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Nuosx\Index.cshtml"
                   Write(item.Mansx);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 45 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Nuosx\Index.cshtml"
                   Write(item.Tennsx);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td class=d-none>");
#nullable restore
#line 46 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Nuosx\Index.cshtml"
                                Write(item.Idnsx);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</td>


                    <td>
                        <button onclick=""showModalEdit(this)"" type=""button"" class=""btn btn-primary"" data-toggle=""modal""
                                data-target=""#editModal"">
                            <i class=""fas fa-pen text-white""></i>
                        </button>
                        <button onclick=""showModalDetail(this)"" type=""button"" class=""btn btn-info"" data-toggle=""modal""
                                data-target=""#detailModal"">
                            <i class=""fas fa-info-circle text-white""></i>
                        </button>
                        <button data-id=""");
#nullable restore
#line 58 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Nuosx\Index.cshtml"
                                    Write(item.Idnsx);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" data-code=\"");
#nullable restore
#line 58 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Nuosx\Index.cshtml"
                                                            Write(item.Mansx);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" data-name=\"");
#nullable restore
#line 58 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Nuosx\Index.cshtml"
                                                                                    Write(item.Tennsx);

#line default
#line hidden
#nullable disable
            WriteLiteral(@""" type=""button"" class=""btn btn-danger deleteBtn""
                                data-toggle=""modal"" data-target=""#deleteModal"">
                            <i class=""fas fa-trash text-white""></i>
                        </button>
                    </td>
");
#nullable restore
#line 63 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Nuosx\Index.cshtml"
                       count++; 

#line default
#line hidden
#nullable disable
            WriteLiteral("                </tr>\r\n");
#nullable restore
#line 65 "D:\ĐH-08CNTT1\HienCa\ElectronicsStore\Views\Nuosx\Index.cshtml"


            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

        </tbody>
    </table>
</div>

<div class=""modal fade"" id=""addModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""addModalLabel""
     aria-hidden=""true"">
    <div class=""modal-dialog w-90"" role=""document"" style=""display: flex;
        align-items: center;
        justify-content: center;"">
        <div class=""modal-content "">
            <div class=""modal-header"">
                <h5 class=""modal-title"" id=""addProductModalLabel"">Thêm mới nhóm hàng</h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3af169e9fe770de9f07edc96cf9b7f4679f6cefe12904", async() => {
                WriteLiteral(@"

                <div class=""modal-body"">

                    <div class=""row"">
                        <div class=""col-md-12 col-sm-12"">
                            <div class=""row d-flex align-items-center"">
                                <div class=""col-md-2 col-sm-12"">
                                    Mã nước sản xuất
                                </div>
                                <div class=""col-md-10 col-sm-12"">
                                    <input id=""MansxA"" name=""Mansx"" maxlength=""255"" type=""text""
                                           class=""form-control"">

                                </div>
                            </div>
                        </div>

                        <div class=""col-md-12 col-sm-12 mt-2"">
                            <div class=""row d-flex align-items-center"">
                                <div class=""col-md-2 col-sm-12"">
                                    Tên nước sản xuất
                                </div>
     ");
                WriteLiteral(@"                           <div class=""col-md-10 col-sm-12"">
                                    <input id=""TennsxA"" name=""Tennsx"" maxlength=""255"" required
                                           type=""text"" class=""form-control"">

                                </div>
                            </div>
                        </div>


                    </div>
                </div>


                <div class=""modal-footer"">
                    <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Đóng</button>
                    <button type=""submit"" id=""addButton"" disabled class=""btn btn-primary"">Lưu</button>
                </div>

            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_3.Value;
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

        </div>
    </div>
</div>
<div class=""modal fade"" id=""editModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""editModal"" aria-hidden=""true"">
    <div class=""modal-dialog w-90"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"" id=""editModal"">Cập nhật thông tin</h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3af169e9fe770de9f07edc96cf9b7f4679f6cefe17241", async() => {
                WriteLiteral(@"

                <div class=""modal-body"">
                    <input id=""id"" name=""Idnsx"" class=""d-none"" type=""text"">
                    <div class=""row"">
                        <div class=""col-md-12 col-sm-12"">
                            <div class=""row d-flex align-items-center"">
                                <div class=""col-md-2 col-sm-12"">
                                    Mã nước sản xuất
                                </div>
                                <div class=""col-md-10 col-sm-12"">
                                    <input id=""MansxE"" name=""Mansx"" maxlength=""255"" type=""text""
                                           class=""form-control"">
                                </div>
                            </div>
                        </div>

                        <div class=""col-md-12 col-sm-12 mt-2"">
                            <div class=""row d-flex align-items-center"">
                                <div class=""col-md-2 col-sm-12"">
                           ");
                WriteLiteral(@"         Tên nước sản xuất
                                </div>
                                <div class=""col-md-10 col-sm-12"">
                                    <input id=""TennsxE"" name=""Tennsx"" maxlength=""255"" required
                                           type=""text"" class=""form-control"">

                                </div>
                            </div>
                        </div>


                    </div>
                </div>

                <div class=""modal-footer"">
                    <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Đóng</button>
                    <button type=""submit"" id=""editButton"" class=""btn btn-primary"">Lưu</button>
                </div>
            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
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

        </div>
    </div>

</div>
<div class=""modal fade"" id=""detailModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""detailModal""
     aria-hidden=""true"">
    <div class=""modal-dialog w-90"" role=""document"" style=""display: flex;
        align-items: center;
        justify-content: center;"">
        <div class=""modal-content "">
            <div class=""modal-header"">
                <h5 class=""modal-title"" id=""detailModal"">Thông tin chi tiết</h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body"">

                <div class=""row"">
                    <div class=""col-md-12 col-sm-12"">
                        <div class=""row d-flex align-items-center"">
                            <div class=""col-md-2 col-sm-12"">
                                Mã nước sản xuất
                            </div>
       ");
            WriteLiteral(@"                     <div class=""col-md-10 col-sm-12"">
                                <input id=""MansxD"" name=""Mansx"" maxlength=""255"" type=""text""
                                       class=""form-control"" disabled>
                            </div>
                        </div>
                    </div>

                    <div class=""col-md-12 col-sm-12 mt-2"">
                        <div class=""row d-flex align-items-center"">
                            <div class=""col-md-2 col-sm-12"">
                                Tên nước sản xuất
                            </div>
                            <div class=""col-md-10 col-sm-12"">
                                <input id=""TennsxD"" name=""Tennsx"" maxlength=""255"" required
                                       type=""text"" class=""form-control"" disabled>

                            </div>
                        </div>
                    </div>


                </div>
            </div>

            <div class=""modal-footer"">
  ");
            WriteLiteral(@"              <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Đóng</button>
            </div>

        </div>
    </div>
</div>

<div class=""modal fade"" id=""deleteModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""deleteModal""
     aria-hidden=""true"">
    <div class=""modal-dialog"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"" id=""deleteModal"">Bạn có chắc chắn muốn xóa?</h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3af169e9fe770de9f07edc96cf9b7f4679f6cefe23976", async() => {
                WriteLiteral(@"
                <input id=""idD"" name=""id"" class=""d-none"" type=""text"">

                <div class=""modal-body"">
                    Dòng dữ liệu này sẽ bị mất, bạn có muốn tiếp tục xóa?
                </div>
                <div class=""modal-footer"">
                    <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Đóng</button>
                    <button type=""submit"" id=""deleteModalBtn"" class=""btn btn-primary"">Xóa</button>
                </div>
            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
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

        </div>
    </div>

</div>

<script>
    const formAdd = document.getElementById(""formAdd"");
    const addButton = document.getElementById(""addButton"");

    const formEdit = document.getElementById(""formEdit"");
    const editButton = document.getElementById(""editButton"");

    formAdd.addEventListener('change', function () {
        if (formAdd.checkValidity()) {
            addButton.disabled = false;
        } else {
            addButton.disabled = true;
        }
    });
    formEdit.addEventListener('change', function () {
        if (formEdit.checkValidity()) {
            editButton.disabled = false;
        } else {
            editButton.disabled = true;
        }
    });
</script>

<script>
    function validateForm(form, saveButton) {
        // Lặp qua tất cả các trường input, textarea và select của form
        let formIsValid = true;
        const fields = form.querySelectorAll(""input, textarea, select"");
        let currentFieldIsValid = true;
     ");
            WriteLiteral(@"   fields.forEach((field) => {
            if (field === event.target) {
                currentFieldIsValid = field.checkValidity();
            }

            if (!currentFieldIsValid || !field.checkValidity()) {
                // Nếu trường không hợp lệ, đánh dấu form không hợp lệ và hiển thị lỗi
                formIsValid = false;
                field.classList.add(""is-invalid"");
                field.setAttribute('placeholder', 'không hợp lệ!');
                field.style.color = ""red"";
            } else {
                field.classList.remove(""is-invalid"");
                field.setAttribute('placeholder', '');
                field.style.color = ""black"";
            }
        });

        // Enable hoặc disable nút lưu dữ liệu tùy thuộc vào trạng thái hợp lệ của form
        saveButton.disabled = !formIsValid;
    }

    // Lấy tham chiếu tới form và nút lưu dữ liệu từ DOM


    // Đăng ký sự kiện ""change"" cho các trường input, textarea và select của form
    formAdd.add");
            WriteLiteral(@"EventListener(""change"", () => {
        validateForm(formAdd, addButton);
    });

    formEdit.addEventListener(""change"", () => {
        validateForm(formEdit, editButton);
    });
</script>
<!-- Bootstrap JavaScript -->
<script src=""https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js""></script>
<script>
    function showModalDetail(row) {
        // Trích xuất thông tin từ các ô trong dòng được click
        const cells = row.parentElement.parentElement.cells;
        const ma = cells[1].textContent;
        const ten = cells[2].textContent;

        // Gán giá trị cho các input trong modal
        document.querySelector('#MansxD').value = ma;
        document.querySelector('#TennsxD').value = ten;


        // Hiển thị modal
        $('#detailModal').modal('show');
    }
    function showModalEdit(row) {
        // Trích xuất thông tin từ các ô trong dòng được click
        const cells = row.parentElement.parentElement.cells;
        const ma = cells[1].textCont");
            WriteLiteral(@"ent;
        const ten = cells[2].textContent;
        const id = cells[3].textContent;

        // Gán giá trị cho các input trong modal
        document.querySelector('#MansxE').value = ma;
        document.querySelector('#TennsxE').value = ten;
        document.querySelector('#id').value = id;

        // Hiển thị modal
        $('#editModal').modal('show');
    }

    //Khi nhấn xóa trên table
    $('#deleteModal').on('show.bs.modal', function (event) {
        var button = $(event.relatedTarget); // Nút ""Xóa"" được nhấn
        var id = button.data('id'); // Lấy giá trị id được lưu trong data-id của nút ""Xóa""
        var name = button.data('name'); // Lấy giá trị của cột tên được lưu trong data-name của nút ""Xóa""
        var code = button.data('code');
        // Tiếp tục với các cột còn lại
        document.getElementById(""idD"").value = id;
        // Hiển thị thông tin của dòng lên modal xác nhận
        var modal = $(this);
        modal.find('.modal-body').text('Bạn có chắc chắn");
            WriteLiteral(" muốn xóa dòng có mã là \' + code + \' và tên là \' + name);\r\n    });\r\n\r\n\r\n\r\n</script>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ElectronicsStore.Models.Nuosx>> Html { get; private set; }
    }
}
#pragma warning restore 1591
