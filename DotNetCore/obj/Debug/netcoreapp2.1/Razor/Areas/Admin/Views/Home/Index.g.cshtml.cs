#pragma checksum "D:\Projects\DotNetCore\DotNetCore\Areas\Admin\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3c1cb4575462774c9577e044a9608daee0c9c955"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Home_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Admin/Views/Home/Index.cshtml", typeof(AspNetCore.Areas_Admin_Views_Home_Index))]
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
#line 1 "D:\Projects\DotNetCore\DotNetCore\Areas\Admin\Views\_ViewImports.cshtml"
using DotNetCore;

#line default
#line hidden
#line 2 "D:\Projects\DotNetCore\DotNetCore\Areas\Admin\Views\_ViewImports.cshtml"
using DotNetCore.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3c1cb4575462774c9577e044a9608daee0c9c955", @"/Areas/Admin/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ab99b957558742bf33286502fdd80ba7bddb56e8", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "value", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Areas/Admin/Scripts/home.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "D:\Projects\DotNetCore\DotNetCore\Areas\Admin\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Areas/Admin/Views/Shared/_AdminLayout.cshtml";

#line default
#line hidden
            BeginContext(107, 1243, true);
            WriteLiteral(@"
<div class=""main-content-inner"">
    <div class=""breadcrumbs breadcrumbs-fixed"" id=""breadcrumbs"">
        <h3>CHỨC NĂNG</h3>
        <div class=""toolbar"">
            <button id=""btnThem"" class=""btn btn-primary"" type=""button"" permiss=""them"">
                <i class=""fa fa-plus""></i>
                <span class=""hidden-320"">Thêm mới</span>
            </button>
        </div>
    </div>
    <div class=""breadcrumbs ace-save-state"">
    </div>

    <div id=""Loadding"">
    </div>
    <div class=""row"">
        <div class=""col-xs-12"" style=""
    margin-bottom: -10px;
"">
            <div class=""form-group"">
                <fieldset class=""khungvien"" style=""margin-left: 13px; margin-right: 13px;"">
                    <legend><b>Lọc theo phần mềm</b></legend>
                    <label class=""col-md-1 control-label"">Phần mềm</label>
                    <div class=""col-md-4"">
                        <select class=""form-control input-sm"" id=""PhanMem_Loc""></select>
                    </div>");
            WriteLiteral("\n                    <label class=\"col-md-1 control-label\">Test</label>\r\n                    <div class=\"col-md-4\">\r\n                        <select class=\"form-control input-sm\" id=\"test\">\r\n                            ");
            EndContext();
            BeginContext(1350, 35, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e989f5e1f23248bd867704a46f1ba71b", async() => {
                BeginContext(1372, 4, true);
                WriteLiteral("text");
                EndContext();
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
            EndContext();
            BeginContext(1385, 30, true);
            WriteLiteral("\r\n                            ");
            EndContext();
            BeginContext(1415, 35, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "78eefa20445b406ca3bae80387aeca80", async() => {
                BeginContext(1437, 4, true);
                WriteLiteral("text");
                EndContext();
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
            EndContext();
            BeginContext(1450, 9788, true);
            WriteLiteral(@"
                        </select>
                    </div>
                </fieldset>
            </div>
        </div>
    </div>
    <div class=""col-xs-12"" id=""divload"" style=""display: none"">
        <div class=""col-xs-12"">
            <div class=""row"" style=""padding-bottom: 2px;"">
                <div class=""col-md-6"">
                </div>
                <div class=""col-md-6"" style=""float: right"">
                    <span class=""input-icon"" style=""float: right;"">
                        <input type=""text"" placeholder=""Nội dung tìm kiếm ..."" onkeyup=""SearchGridByValue(Grid1,[2,3,4],this.value)"" class=""nav-search-input"" id=""nav-search-input"" autocomplete=""off"">
                        <i class=""ace-icon fa fa-search nav-search-icon""></i>
                    </span>
                </div>
            </div>
        </div>
        <div>
            <cc1:Grid ID=""Grid1"" runat=""server"" FolderStyle=""~/App_Themes/Styles/style_7"" AllowPaging=""true"" FilterType=""ProgrammaticOnly""
       ");
            WriteLiteral(@"               PageSizeOptions=""15,50,150,200,500,1000,-1"" PageSize=""50"" AutoGenerateColumns=""false"" AllowFiltering=""true"" AllowRecordSelection=""true""
                      EnableRecordHover=""false"" AllowGrouping=""false"" Width=""100%"" Height=""600"" AllowColumnResizing=""true""
                      AllowAddingRecords=""false"" AllowMultiRecordSelection=""False"" OnRebind=""Grid1_OnRebind"">
                <ScrollingSettings ScrollWidth=""100%"" ScrollHeight=""100%"" />
                <PagingSettings Position=""Bottom"" />
                <ClientSideEvents OnBeforeClientDelete=""Grid1_OnBeforeClientDelete"" OnBeforeClientEdit=""Grid1_OnBeforeClientEdit"" OnClientDblClick=""Grid1_OnClientDblClick"" />
                <FilteringSettings MatchingType=""AnyFilter"" FilterPosition=""Top"" FilterLinksPosition=""Bottom"" />
                <Columns>
                    <cc1:Column AllowDelete=""true"" AllowEdit=""true"" Width=""70px"" HeaderText=""Thao tác"" Align=""Center"">
                        <TemplateSettings TemplateId=""editBtnTempla");
            WriteLiteral(@"te"" EditTemplateId=""updateBtnTemplate"" />
                    </cc1:Column>
                    <cc1:Column HeaderText=""Mã"" DataField=""ChucNangCode"" Wrap=""true"" Width=""120px"">
                    </cc1:Column>
                    <cc1:Column HeaderText=""Tên chức năng"" DataField=""TenChucNang"" Wrap=""true"" Width=""250px"">
                    </cc1:Column>
                    <cc1:Column HeaderText=""Tên phần mềm"" DataField=""TenPhanMem"" Wrap=""true"" Width=""250px"">
                    </cc1:Column>
                    <cc1:Column HeaderText=""Diễn giải"" DataField=""DienGiai"" Wrap=""true"" Width=""350px"">
                    </cc1:Column>
                    <cc1:CheckBoxColumn HeaderText=""Ngừng theo dõi"" DataField=""NgungTD"" Width=""110px"" Align=""Center"">
                    </cc1:CheckBoxColumn>
                    <cc1:Column HeaderText=""ChucNangID"" DataField=""ChucNangID"" Width=""0px"" Visible=""false"">
                    </cc1:Column>
                </Columns>
                <Templates>
                  ");
            WriteLiteral(@"  <cc1:GridTemplate runat=""server"" ID=""editBtnTemplate"">
                        <Template>
                            <button type=""button"" id=""btnEdit"" permiss=""sua"" class=""btn btn-xs btn-info"" onclick=""Grid1.edit_record(this)""><i class=""fa fa-pencil""></i></button>
                            <button type=""button"" id=""btnDelete"" permiss=""xoa"" class=""btn btn-xs btn-danger"" onclick=""Grid1.delete_record(this)""><i class=""fa fa-trash""></i></button>
                        </Template>
                    </cc1:GridTemplate>
                </Templates>
                <LocalizationSettings CancelAllLink=""Hủy tất cả"" AddLink=""Thêm mới"" CancelLink=""Hủy""
                                      DeleteLink=""Xóa"" EditLink=""Sửa"" Filter_ApplyLink=""Tìm kiếm"" Filter_HideLink=""Đóng tìm kiếm""
                                      Filter_RemoveLink=""Xóa tìm kiếm"" Filter_ShowLink=""Mở tìm kiếm"" FilterCriteria_NoFilter=""Không tìm kiếm""
                                      FilterCriteria_Contains=""Chứa"" FilterCriteria_D");
            WriteLiteral(@"oesNotContain=""Không chứa"" FilterCriteria_StartsWith=""Bắt đầu với""
                                      FilterCriteria_EndsWith=""Kết thúc với"" FilterCriteria_EqualTo=""Bằng"" FilterCriteria_NotEqualTo=""Không bằng""
                                      FilterCriteria_SmallerThan=""Nhỏ hơn"" FilterCriteria_GreaterThan=""Lớn hơn"" FilterCriteria_SmallerThanOrEqualTo=""Nhỏ hơn hoặc bằng""
                                      FilterCriteria_GreaterThanOrEqualTo=""Lớn hơn hoặc bằng"" FilterCriteria_IsNull=""Rỗng""
                                      FilterCriteria_IsNotNull=""Không rỗng"" FilterCriteria_IsEmpty=""Trống"" FilterCriteria_IsNotEmpty=""Không trống""
                                      Paging_OfText=""của"" Grouping_GroupingAreaText=""Kéo tiêu đề cột vào đây để loại theo cột đó""
                                      JSWarning=""Có một lỗi khởi tạo lưới với ID '[GRID_ID]'. \ N \ n [Chú ý] \ n \ nHãy liên hệ bộ phận bảo trì của Nhất Tâm Soft để được giúp đỡ.""
                                      LoadingText=""Đang");
            WriteLiteral(@" tải...."" MaxLengthValidationError=""Giá trị mà bạn đã nhập vào trong cột XXXXX vượt quá số lượng tối đa ký tự YYYYY cho phép cột này.""
                                      ModifyLink=""Chỉnh sửa"" NoRecordsText=""Không có dữ liệu"" Paging_ManualPagingLink=""Trang kế »""
                                      Paging_PageSizeText=""Số dòng 1 trang:"" Paging_PagesText=""Trang:"" Paging_RecordsText=""Dòng:""
                                      ResizingTooltipWidth=""Rộng:"" SaveAllLink=""Lưu tất cả"" SaveLink=""Lưu"" TypeValidationError=""Giá trị mà bạn đã nhập vào trong cột XXXXX là không đúng.""
                                      UndeleteLink=""Không xóa"" UpdateLink=""Lưu"" />
            </cc1:Grid>
        </div>

        <div id=""mdThemMoi"" class=""modal"" data-backdrop=""static"">
            <div class=""modal-dialog"">
                <div class=""modal-content"">
                    <div class=""modal-header no-padding"">
                        <div class=""table-header"">
                            <button type=""butto");
            WriteLiteral(@"n"" class=""close"" data-dismiss=""modal"" aria-hidden=""true"">
                                <span class=""white"">&times;</span>
                            </button>
                            <span id=""tieuDeModal""></span>
                        </div>
                    </div>
                    <div class=""modal-body"">
                        <fieldset class=""khungvien"">
                            <legend><b>Thông tin chức năng</b></legend>
                            <div class=""row"" style=""padding-bottom: 2px"">
                                <div class=""col-md-3"">
                                    <label class=""validation"">Mã</label>
                                </div>
                                <div class=""col-md-5"">
                                    <input class=""form-control input-sm"" type=""text"" id=""txtMa"" />
                                </div>
                                <div class=""col-md-3"">
                                </div>
                            ");
            WriteLiteral(@"</div>
                            <div class=""row"" style=""padding-bottom: 2px"">
                                <div class=""col-md-3"">
                                    <label class=""validation"">Tên chức năng</label>
                                </div>
                                <div class=""col-md-9"">
                                    <input class=""form-control input-sm"" type=""text"" id=""txtTen"" />
                                </div>
                            </div>
                            <div class=""row"" style=""padding-bottom: 2px"">
                                <div class=""col-md-3"">
                                    <label class=""validation"">Tên phần mềm</label>
                                </div>
                                <div class=""col-md-9"">
                                    <input class=""form-control input-sm"" type=""text"" id=""selPhanMemID"" />
                                </div>
                            </div>
                            <div ");
            WriteLiteral(@"class=""row"" style=""padding-bottom: 2px"">
                                <div class=""col-md-3"">
                                    <label>Diễn giải</label>
                                </div>
                                <div class=""col-md-9"">
                                    <textarea class=""form-control input-sm"" id=""txtDienGiai"" rows=""4"">
                                    </textarea>
                                </div>
                            </div>
                        </fieldset>
                    </div>
                    <div class=""modal-footer"">
                        <label class=""middle"" style=""float: left"">
                            <input class=""ace"" type=""checkbox"" id=""ckNgungTD"" />
                            <span class=""lbl"">&nbsp;Ngừng theo dõi</span>
                        </label>
                        <a href=""#"" id=""btnLuuVaDong"" class=""btn btn-success"" onclick=""btnLuuDuLieu(this,'2');return false;"">
                            <i class=""ac");
            WriteLiteral(@"e-icon fa fa-floppy-o bigger-110""></i>&nbsp;Lưu và đóng
                        </a> &nbsp;
                        <a href=""#"" class=""btn btn-danger""
                           data-dismiss=""modal""><i class=""fa fa-close""></i>&nbsp;Đóng</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<script>
    $(function () {
        $('#test').select2()
    })
    $('#btnThem').click(function () {
        var data = NTS.getAjax(""json"", ""/Home/getAllUser"", {});
        console.log(data)
    })
</script>
");
            EndContext();
            BeginContext(11238, 53, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f32878494fe54882839a32a1486579d0", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(11291, 2, true);
            WriteLiteral("\r\n");
            EndContext();
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
