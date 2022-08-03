var tempthem = "them";
$(document).ready(function () {
    //  $('.tieu-de-trang').text('CHỨC VỤ');
    $('#TinhID').val('');
    $('#btnThemMoi').click(function () {
        if (!ntspermiss.them) {
            NTS.canhbao("User bạn đang sử dụng không thể thực hiện thao tác thêm mới. Vui lòng kiểm tra lại.");
            return false;
        }
        $('#tieuDeModal').text('Thêm mới Tỉnh/Thành phố');
        $('#TinhCode').value('');
        $('#TenTinh').value('');
        $('#TenVietTat').value('');
        $('#DienGiai').value('');
        $('#NgungSD').value('');
        $('#TinhID').val('');
        tempthem = "them";
        $('#mdThemMoi').modal('show');
    });
    $(document).on('click', '.btnSuaGrid1', function () {
        if (!ntspermiss.sua) {
            NTS.canhbao("User bạn đang sử dụng không thể thực hiện thao tác chỉnh sửa. Vui lòng kiểm tra lại.");
            return false;
        }
        $('#TinhID').val($(this).attr('data'));

        SuaDanhHieu($(this).attr('data'));
    });
    $(document).on('click', '.btnXoaGrid1', function () {
        if (!ntspermiss.xoa) {
            NTS.canhbao("User bạn đang sử dụng không thể thực hiện thao tác xóa. Vui lòng kiểm tra lại.");
            return false;
        }
        var ID = $(this).attr('data');
        XoaDanhHieu(ID);
    });
});
var btnThaoTac = function (cell, formatterParams, onRendered) { //plain text value
    //console.log(cell.getRow().getData());
    return `<button class='btn btn-xs btn-primary btnSuaGrid1' title="Sửa" data='${cell.getRow().getData().TinhID}' ><i class='fa fa-pencil'></i></button>&ensp;<button class='btn btn-xs btn-danger btnXoaGrid1' title="Xoá" data='${cell.getRow().getData().TinhID}'><i class='fa fa-trash'></i></button>`;
};
function updateFooter() {
    var el = document.getElementById("row-count");
    if (table != undefined) {
        if (table.rowManager.activeRows.length > 0) {
            el.innerHTML = 'Dòng: ' + (table.rowManager.table.footerManager.links[0].page * table.rowManager.table.footerManager.links[0].size - table.rowManager.table.footerManager.links[0].size + 1) + ' - ' + (table.rowManager.table.footerManager.links[0].page * table.rowManager.table.footerManager.links[0].size - table.rowManager.table.footerManager.links[0].size + table.rowManager.displayRowsCount) + ' của ' + table.rowManager.activeRows.length + " - ";
        }
        else {
            el.innerHTML = 'Dòng: 0 - 0 của 0 - ';
        }
    }
}
$(document).on('click', '.tabulator-page', function () {
    updateFooter();
});
$(document).on('change', '.tabulator-page-size', function () {
    updateFooter();
});
$(document).on('click', '.tabulator-footer', function () {
    updateFooter();
});
var table = new Tabulator("#Grid1", {
    height: 500,
    layout: "fitColumns",
    pagination: "local",
    selectable: 1,
    paginationSize: 50,
    paginationSizeSelector: [50, 100, 150, 250, 500, true],
    columns: [ //Define Table Columns
        { title: "Thao tác", hozAlign: "center", formatter: btnThaoTac, width: 80, headerSort: false },
        { title: "TinhID", field: "TinhID", formatter: 'textarea', width: 150, visible: false },
        { title: "Mã", field: "TinhCode", formatter: 'textarea', hozAlign: "left", visible: true, width: 110 },
        { title: "Tên Tỉnh/Thành phố", field: "TenTinh", formatter: 'textarea', hozAlign: "left", width: 350 },
        { title: "Tên viết tắt", field: "TenVietTat", formatter: 'textarea', hozAlign: "left", width: 150 },
        { title: "Ghi chú", field: "DienGiai", hozAlign: "left", formatter: "textarea" },
        {
            title: "Ngưng sử dụng", field: "NgungSD", hozAlign: "center", formatter: (cell) => {
                const value = cell.getValue();
                if (value)
                    return `<input type="checkbox" checked disabled='disabled' />`;
                else
                    return `<input type="checkbox" disabled='disabled' />`;
            }, width: 110, headerSort: false
        },

    ],
    footerElement: "<span id='row-count' style='color:#102D4F;font-size: 13px; font-family: Arial, Helvetica, sans-serif;font-weight:100'></span>", //add element element to footer to contain count
    dataFiltered: updateFooter, //call updateFooter function when callback triggered
    dataLoaded: updateFooter, //call updateFooter function when callback triggered
    rowDblClick: function (e, row) { //trigger an alert message when the row is clicked
        $('#TinhID').val(row.getData().TinhID);
        SuaDanhHieu(row.getData().TinhID);
    },
    locale: true,
    langs: TabulatorLangsVi,
    placeholder: 'Không có dữ liệu',
});


var GetAll = NTS.getAjax("/DanhMuc/Tinh/GetAll", {});
if (GetAll.Err == false) {
    table.setData(GetAll.Result);
}
else {
    NTS.thongbaoloi(GetAll.Msg);
}

$(document).on('keyup', '#timKiem', function (e) {
    if (e.keyCode == '13') {
        table.setFilter(matchAny, { value: $(this).val() });
        updateFooter();
    }
});

$('#btnLuuVaDong').on('click', function () {
    if (isEmty($('#TinhCode').value())) {
        NTS.canhbao('Mã không được để trống!');
        $('#TinhCode').focus();
        return false;
    }
    if (isEmty($('#TenTinh').value())) {
        NTS.canhbao('Tên không được để trống!');
        $('#TenTinh').focus();
        return false;
    }
    var param = new Array();

    param[0] = tempthem;
    param[1] = $('#TinhCode').value();
    param[2] = $('#TenTinh').value();
    param[3] = $('#TenVietTat').value();
    param[4] = $('#DienGiai').value();
    param[5] = $('#NgungSD').value();
    param[6] = $('#TinhID').val();


    var result = NTS.getAjax("/DanhMuc/Tinh/LuuThongTin", { data: param });
    if (result.split('_')[0] == "1") {
        table.clearData();
        var GetAll = NTS.getAjax("/DanhMuc/Tinh/GetAll", {});
        if (GetAll.Err == false) {
            table.setData(GetAll.Result);
        }
        else {
            NTS.thongbaoloi(GetAll.Msg);
        }
        NTS.thongbao(result.split('_')[1]);
        $('#mdThemMoi').modal('hide');
        return false;
    } else
        if (result.split('_')[0] == "2") {
            NTS.canhbao(result.split('_')[1]);
            return false;
        }
        else {
            NTS.thongbaoloi('Thêm thất bại');
            return false;
        }
})
function LoadDataEdit(data) {
    $('#mdThemMoi').modal('show');
}

function SuaDanhHieu(ID) {
    if (!ntspermiss.sua) {
        NTS.canhbao("User bạn đang sử dụng không thể thực hiện thao tác chỉnh sửa. Vui lòng kiểm tra lại.");
        return false;
    }
    $('#tieuDeModal').text('Cập nhật Tỉnh/Thành phố');
    var result = NTS.getAjax('/DanhMuc/Tinh/LoadDuLieuSua', { ma: ID });
    if (result.length > 0) {

        $('#TinhCode').value(result[0].TinhCode);
        $('#TenTinh').value(result[0].TenTinh);
        $('#DienGiai').value(result[0].DienGiai);
        $('#NgungSD').value(result[0].NgungSD);
        $('#TenVietTat').value(result[0].TenVietTat);
        $('#TinhID').value(result[0].TinhID);
        $('#mdThemMoi').modal('show');
        tempthem = "sua";
    }
    else {
        NTS.thongbaoloi('Tải dữ liệu sửa thất bại')
    }
}
function XoaDanhHieu(ID) {
    if (!ntspermiss.xoa) {
        NTS.canhbao("User bạn đang sử dụng không thể thực hiện thao tác xóa. Vui lòng kiểm tra lại.");
        return false;
    }
    var result_ktxoa = NTS.getAjax('/DanhMuc/DungChung/KiemTraXoaDT', { TenCot: 'TinhID', ID: ID, TenBangHienTai: 'Tinh', CacBangKhongXet: [] });
    if (result_ktxoa == "") {
        bootbox.confirm({
            title: 'Cảnh báo',
            message: NTS.CauThongBaoXoa,
            className: 'bb-alternate-modal',
            buttons: {
                cancel: {
                    label: '<i class="fa fa-close"></i> Hủy bỏ',
                    className: "btn-danger btn-sm",
                },
                confirm: {
                    label: '<i class="fa fa-check"></i> Chấp nhận',
                    className: "btn-primary btn-sm",
                }
            },
            callback: function (result) {
                if (result) {
                    var result = NTS.getAjax('/DanhMuc/Tinh/Xoa', { ma: ID });
                    if (result.split('_')[0] == "1") {
                        var GetAll = NTS.getAjax("/DanhMuc/Tinh/GetAll", {});
                        if (GetAll.Err == false) {
                            table.setData(GetAll.Result);
                        }
                        else {
                            NTS.thongbaoloi(GetAll.Msg);
                        }
                        NTS.thongbao(result.split('_')[1]);
                    }
                    else {
                        NTS.thongbaoloi('Xóa thất bại');
                    }
                }
            }
        });
    }
    else
        bootbox.dialog({
            title: "Cảnh báo",
            message: "Dữ liệu này đang được sử dụng. Không thể xoá, danh sách kèm theo:<br><table>" + result_ktxoa + "</table>",
            className: 'bb-alternate-modal',
            buttons: {
                cancel: {
                    label: '<i class="fa fa-close"></i> Đóng',
                    className: "btn-danger btn-sm",
                }
            },
        })
}