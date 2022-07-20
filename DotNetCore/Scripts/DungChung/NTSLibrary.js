//Theo dõi lỗi không edit được CKE
var DauTachNhomTienTe = NTS.getAjax('string', '/Services/ServiceSystem.asmx/DauTachNhomTienTe', {});
var DauTachThapPhan = NTS.getAjax('string', '/Services/ServiceSystem.asmx/DauTachThapPhan', {});
var ThongTinUser = NTS.getAjax('json', "/Services/ServiceSystem.asmx/getUser", {});
$(".cke").removeAttr("tabindex");
function getUrl() {
    var vars = [], hash;
    var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
    for (var i = 0; i < hashes.length; i++) {
        hash = hashes[i].split('=');
        vars.push(hash[0]);
        vars[hash[0]] = hash[1];
    }
    return vars;
}
//Xu ly khong xoa
//Ket thuc xu ly khong xoa
String.prototype.replaceAll = function(strTarget, strSubString) {
    var strText = this;
    if (strText.length > 0) {
        var intIndexOfMatch = strText.indexOf(strTarget);
        while (intIndexOfMatch != -1) {
            strText = strText.replace(strTarget, strSubString)
            intIndexOfMatch = strText.indexOf(strTarget);
        }
        return (strText);
    } else {
        return "";
    }
}
function checkDate(value, flag) {
    var re = /^\d{1,2}\/\d{1,2}\/\d{4}$/;
    //Cho phép rỗng
    if (flag == true) {
        if (!value.match(re)) {
            return false;
        } else
            return true;
    } else if (value != '' && !value.match(re)) {
        return false;
    }
}
//Kiểm tra value null hoặc bằng 0
function isEmtyValue(value) {
    if (value == "0" || value == "")
        return true;
    return false;
}

function bindData(comboName, dataSource) {
    comboName.options.clear();
    if (dataSource != null) {
        $.each(JSON.parse(dataSource.toJSON()).Rows, function(index, item) {
            comboName.options.add(item[1] + "", item[0] + "", comboName.options.length);
        })
    }
}

function checkEmtyValue(value) {
    if (value == "0" || value == "")
        return true;
    return false;
}
//Kiểm tra value null
function isEmty(value) {
    if (value == "")
        return true;
    return false;
}
//Định dạng window
function dinhDangWindow(winDowName) {
    var screenWidth = screen.width;
    var screenHeight = screen.height;
    var WindowSize = winDowName.getSize();
    winDowName.setPosition(parseFloat((parseFloat(screenWidth) - parseFloat(WindowSize.width)) / 2), window.scrollY + 100);
    winDowName.Open();
}
//Định dạng số
function dinhDangSo(sender, value) {
    sender.value(formatNumber(value));
}
//Định dạng tiền tệ
//function formatNumber(str) {
//    var soAm = (str + "").substring(0, 1);
//    if (soAm == "-")
//        str = str.replace("-", "");
//    if (jQuery.type(str) == "undefined" || str == null)
//        return '0';
//    str = str.toString();
//    var m = str.lastIndexOf(DauTachThapPhan);
//    var phanNguyen = "";
//    var phanThapPhan = "";
//    if (m == -1)
//        phanNguyen = str;
//    else {
//        phanNguyen = str.substring(0, str.lastIndexOf(DauTachThapPhan));
//        phanThapPhan = str.substring(str.lastIndexOf(DauTachThapPhan), str.length);
//    }
//    var kq = "";
//    var dem = 0;
//    phanNguyen = parseFloat(phanNguyen.split(DauTachNhomTienTe).join('').split(DauTachThapPhan).join('')).toString();
//    for (var i = phanNguyen.length; i > 0; i--) {

//        if (!isNaN(phanNguyen.substring(i, i - 1))) {
//            kq = phanNguyen.substring(i, i - 1).toString() + kq;
//            if (dem == 2 && i != 1) {
//                kq = DauTachNhomTienTe + kq;
//                dem = 0;
//            } else {
//                dem = dem + 1;
//            }
//        }
//    } 
//    if (phanThapPhan != '' && phanThapPhan != DauTachThapPhan && parseFloat(phanThapPhan.split(DauTachThapPhan).join('').split(DauTachNhomTienTe).join('')).toString() != "0") {
//        phanThapPhan = parseFloat(phanThapPhan.split(DauTachThapPhan).join('').split(DauTachNhomTienTe).join('')).toString();
//        phanThapPhan = DauTachThapPhan + phanThapPhan;
//    } else if (phanThapPhan == DauTachThapPhan) {
//        phanThapPhan = DauTachThapPhan;
//    }
//    else
//    { phanThapPhan = ''; }
//    if (kq + phanThapPhan == '')
//        return 0;

//    kq = kq + phanThapPhan;
//    if (soAm == "-")
//        kq = "-" + kq + "";
//    return kq;
//}
//Định dạng tiền tệ
function formatNumber(str) {
    str = str.replace(/[^0-9,.-]/g, '');
    var soAm = (str + "").substring(0, 1);
    if (soAm == "-")
        str = str.replace("-", "");
    if (jQuery.type(str) == "undefined" || str == null)
        return '0';
    str = str.toString();
    var m = str.lastIndexOf(DauTachThapPhan);
    var phanNguyen = "";
    var phanThapPhan = "";
    if (m == -1)
        phanNguyen = str;
    else {
        phanNguyen = str.substring(0, str.lastIndexOf(DauTachThapPhan));
        phanThapPhan = str.substring(str.lastIndexOf(DauTachThapPhan), str.length);
    }
    var kq = "";
    var dem = 0;
    phanNguyen = phanNguyen.replace(/[^0-9.-]/g, '');
    phanThapPhan = phanThapPhan.replace(/[^0-9.,]/g, '');
    phanNguyen = parseFloat(phanNguyen.split(DauTachNhomTienTe).join('').split(DauTachThapPhan).join('')).toString();
    for (var i = phanNguyen.length; i > 0; i--) {

        if (!isNaN(phanNguyen.substring(i, i - 1))) {
            kq = phanNguyen.substring(i, i - 1).toString() + kq;
            if (dem == 2 && i != 1) {
                kq = DauTachNhomTienTe + kq;
                dem = 0;
            } else {
                dem = dem + 1;
            }
        }
    };
    if (phanThapPhan != '' && phanThapPhan != DauTachThapPhan) {
        phanThapPhan = phanThapPhan.split(DauTachThapPhan).join('').split(DauTachNhomTienTe).join('').toString();
        phanThapPhan = ',' + phanThapPhan;
    } else if (phanThapPhan == ',') {
        phanThapPhan = ',';
    }
    else {
        phanThapPhan = '';
    }

    if (kq + phanThapPhan == '' && soAm == "-")
        return soAm + "";

    kq = kq + phanThapPhan;
    if (soAm == "-")
        kq = "-" + kq + "";
    return kq;
}
function formatNumberJS(str) {
    try {
        str += "";
        if (DauTachThapPhan == '.') {
            str = str.replaceAll(DauTachNhomTienTe, '');
            if ($.isNumeric(str)) {
                return str.replaceAll(",", ".");
            }
            return "0";
        }
        else {
            str = str.replaceAll('.', '');
            str = str.replaceAll(',', '.');
            if ($.isNumeric(str)) {
                return str;
            }
            return "0";
        }
    }
    catch (e) {
        return "0";
    }
}
// Code goc
//function formatNumber(str) {
//    var soAm = (str + "").substring(0, 1);
//    if (soAm == "-")
//        str = str.replace("-", "");
//    if (jQuery.type(str) == "undefined" || str == null)
//        return '0';
//    str = str.toString();
//    var m = str.lastIndexOf(",");
//    var phanNguyen = "";
//    var phanThapPhan = "";
//    if (m == -1)
//        phanNguyen = str;
//    else {
//        phanNguyen = str.substring(0, str.lastIndexOf(","));
//        phanThapPhan = str.substring(str.lastIndexOf(","), str.length);
//    }
//    var kq = "";
//    var dem = 0;
//    phanNguyen = parseFloat(phanNguyen.split(".").join('').split(",").join('')).toString();
//    for (var i = phanNguyen.length; i > 0; i--) {

//        if (!isNaN(phanNguyen.substring(i, i - 1))) {
//            kq = phanNguyen.substring(i, i - 1).toString() + kq;
//            if (dem == 2 && i != 1) {
//                kq = "." + kq;
//                dem = 0;
//            } else {
//                dem = dem + 1;
//            }
//        }
//    }
//    if (phanThapPhan != '' && phanThapPhan != ',' && parseFloat(phanThapPhan.split(",").join('').split(".").join('')).toString() != "0") {
//        phanThapPhan = parseFloat(phanThapPhan.split(",").join('').split(".").join('')).toString();
//        phanThapPhan = ',' + phanThapPhan;
//    } else if (phanThapPhan == ',') {
//        phanThapPhan = ',';
//    }
//    else { phanThapPhan = ''; }
//    if (kq + phanThapPhan == '')
//        return 0;

//    kq = kq + phanThapPhan;
//    if (soAm == "-")
//        kq = "-" + kq + "";
//    return kq;
//}
var keyEnter = 0;
function performSearch(grid, index, value) {
    if (keyEnter != "1") {
        return false
    }
    keyEnter = 0;
    for (var i = index; i < grid.ColumnsCollection.length - 1; i++) {
        var s = grid.ColumnsCollection[i].DataField;
        if (grid.ColumnsCollection[i].Visible == true) {
            grid.addFilterCriteria(s, OboutGridFilterCriteria.Contains, value);
        }
    }
    grid.executeFilter();
    searchTimeout = null;
    return false;
}
var searchTimeout = null;

function searchValue(grid, index, value) {
    if (keyEnter != "1") {
        return false
    }
    keyEnter = 0;
    if (searchTimeout != null) {
        return false;
    }
    if (searchTimeout != null) {
        return false;
    }
    if (jQuery.type(value) == "undefined")
        value = '';
    for (var i = index; i < grid.ColumnsCollection.length; i++) {
        if (grid.ColumnsCollection[i].HeaderText != "") {
            var s = grid.ColumnsCollection[i].DataField;
            if (grid.ColumnsCollection[i].Visible == true && s != "") {
                grid.addFilterCriteria(s, OboutGridFilterCriteria.Contains, value);
            }
        }
    }
    //if (jQuery.type(grid.executeFilter()) == "undefined") {
    //    alert("Looix");
    //    return false;
    //}
    searchTimeout = window.setTimeout(grid.executeFilter(), 2000);
    searchTimeout = null;
    return false;
}
// tìm kiếm trong grid
// Range là mảng index cột trong grid
function SearchGridByValue(gridID, Range, value) {
    if (keyEnter != "1") {
        return false
    }
    keyEnter = 0;
    if (searchTimeout != null) {
        return false;
    }
    (jQuery.type(value) == "undefined") && (value = '');
    (jQuery.isEmptyObject(Range)) && (Range.length = 0);
    if (Range.length > 0 && Range[0] == -1) {
        for (var i = index; i < grid.ColumnsCollection.length; i++) {
            if (grid.ColumnsCollection[i].HeaderText != "") {
                var s = grid.ColumnsCollection[i].DataField;
                if (grid.ColumnsCollection[i].Visible == true && s != "") {
                    grid.addFilterCriteria(s, OboutGridFilterCriteria.Contains, value);
                }
            }
        }
    }
    else {
        for (var i = 0; i < Range.length; i++) {
            if (gridID.ColumnsCollection[Range[i]].HeaderText != "") {
                var ColName = gridID.ColumnsCollection[Range[i]].DataField;
                (gridID.ColumnsCollection[Range[i]].Visible == true && ColName != "") && (gridID.addFilterCriteria(ColName, OboutGridFilterCriteria.Contains, value));
            }
        }
    }

    gridID.executeFilter();
    (value == '' || value == undefined) && (gridID.executeFilter());
    return false;
}

function bieuDoTron(result, tenBieuDo, DivID) {
    var dataTableGoogle = new google.visualization.DataTable();
    for (var i = 0; i < result.Columns.length; i++) {
        if (i == 0)
            dataTableGoogle.addColumn('string', result.Columns[i].Name);
        else
            dataTableGoogle.addColumn('number', result.Columns[i].Name);
    }
    dataTableGoogle.addRows(
        JSON.parse(result.toJSON()).Rows
    );
    // Instantiate and draw our chart, passing in some options
    var chart = new google.visualization.PieChart(document.getElementById(DivID));
    chart.draw(dataTableGoogle, {
        title: tenBieuDo,
        position: "top",
        fontsize: "14px",
        chartArea: {
            width: '100%',
            height: '100%'
        },
    });
}

function bieuDoTron3D(result, tenBieuDo, DivID) {
    var dataTableGoogle = new google.visualization.DataTable();
    for (var i = 0; i < result.Columns.length; i++) {
        if (i == 0)
            dataTableGoogle.addColumn('string', result.Columns[i].Name);
        else
            dataTableGoogle.addColumn('number', result.Columns[i].Name);
    }
    dataTableGoogle.addRows(
        JSON.parse(result.toJSON()).Rows
    );
    // Instantiate and draw our chart, passing in some options
    //var chart = new google.visualization.PieChart(document.getElementById(DivID));
    var options = {
        title: tenBieuDo,
        position: "top",
        fontsize: "12px",
        top: '20px',
        chartArea: {
            width: '100%',
            height: '80%'
        },
        is3D: true
    };

    var chart = new google.visualization.PieChart(document.getElementById(DivID));

    chart.draw(dataTableGoogle, options);

    //chart.draw(dataTableGoogle,
    //    {
    //        title: tenBieuDo,
    //        position: "top",
    //        fontsize: "14px",
    //        top:'20px',
    //        chartArea: { width: '300px', height: '100%' },
    //        is3D:true
    //    });
}

function veBieuDoCot(result, tenBieuDo, DivID) {

    var dataTableGoogle = new google.visualization.DataTable();
    for (var i = 0; i < result.Columns.length; i++) {
        if (i == 0)
            dataTableGoogle.addColumn('string', result.Columns[i].Name);
        else
            dataTableGoogle.addColumn('number', result.Columns[i].Name);
    }
    dataTableGoogle.addRows(
        JSON.parse(result.toJSON()).Rows
    );
    // Instantiate and draw our chart, passing in some options
    var chart = new google.visualization.ColumnChart(document.getElementById(DivID));
    chart.draw(dataTableGoogle, {
        title: tenBieuDo,
        position: "top",
        fontsize: "14px",
    });
}

function veBieuDoPhatTrien(result, tenBieuDo, DivID) {
    if (result == null) {
        $('#' + DivID).html("");

    } else {
        var dataTableGoogle = new google.visualization.DataTable();
        for (var i = 0; i < result.Columns.length; i++) {
            if (i == 0)
                dataTableGoogle.addColumn('string', result.Columns[i].Name);
            else
                dataTableGoogle.addColumn('number', result.Columns[i].Name);
        }
        dataTableGoogle.addRows(
            JSON.parse(result.toJSON()).Rows
        );
        var options = {
            title: tenBieuDo,
        };
        var chart = new google.visualization.LineChart(document.getElementById(DivID));
        chart.draw(dataTableGoogle, options);
    }

}
var pickerFn = $.fn.datepicker,
    placeholder = 'dd/MM/yyyy';
$.fn.datepicker = function() {
    var datePicker = pickerFn.apply(this, arguments);
    var self = this;
    self.attr('placeholder', placeholder);
    return datePicker;
};
// control boostrap
//Ngày bỗ sung: 18/12/2018
//Người bỗ sung: Vịnh
// Nội dung: các hàm sử dụng cho theme boostrap
function Loadding(class_) {
    $('.' + class_).append('<div class="message-loading-overlay"><i class="fa-spin ace-icon fa fa-spinner orange2 bigger-260"></i></div>');
}
function Loadding_Finish(class_) {
    $('.' + class_).find('.message-loading-overlay').remove();
}
function An_HienNut(idBotton, thaoTac) {
    $('#' + idBotton).css("visibility", '' + thaoTac + '');
    $('#' + idBotton).css("display", '' + thaoTac + '');
}
function HienThiControl(idBotton, visibe) {
    if (visibe) {
        $('#' + idBotton).css("visibility", "visible");
        $('#' + idBotton).css("display", "inline-block");
    } else {
        $('#' + idBotton).css("visibility", "hidden");
        $('#' + idBotton).css("display", "none");
    }
}
//Loại bỏ các khoảng trắng ở đầu, cuối và dư thừa của chuỗi.
function trimSpace(str) {
    if (str == "" || str == null)
        return "";
    else
        return str.replace(/(?:(?:^|\n)\s+|\s+(?:$|\n))/g, "").replace(/\s+/g, " ");
}
//kiem tra email
function KiemTraEmail(sEmail) {
    var filter = /^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/;
    if (filter.test(sEmail)) {
        return true;
    } else {
        return false;
    }
}
//kiem tra sdt
function KiemTraSDT(txtPhone) {
    var filter = /^[0-9]+$/;
    if (filter.test(txtPhone)) {
        return true;
    } else {
        return false;
    }
} 
function kiemTraTenDangNhap(chuoi) {
    var usernameRegex = /^[a-zA-Z0-9-_]+$/;
    if (usernameRegex.test(chuoi)) {
        return true;
    } else {
        return false;
    }
}
$(document).keypress(function (e) {
    if (!e.shiftKey && e.keyCode == 13) {
        keyEnter = 1;
        return false;
    }
});

var now = new Date();
var dayArray = new Array(9);
function layThoiGianTheoKyBaoCao(idTuNgay, idDenNgay, idKyBaoCao) {
    $('#' + idTuNgay + '').prop('disabled', true);
    $('#' + idDenNgay + '').prop('disabled', true);
    var ngayHienTai = '';
    var thangHienTai = '';
    dayArray[0] = "01";
    dayArray[1] = "02";
    dayArray[2] = "03";
    dayArray[3] = "04";
    dayArray[4] = "05";
    dayArray[5] = "06";
    dayArray[6] = "07";
    dayArray[7] = "08";
    dayArray[8] = "09";
    if (now.getDate() < 10)
        ngayHienTai = dayArray[now.getDate() - 1];
    else
        ngayHienTai = now.getDate();
    if ($('#' + idKyBaoCao + '').val() < 10)
        thangHienTai = dayArray[$('#' + idKyBaoCao + '').val() - 1];
    else
        thangHienTai = $('#' + idKyBaoCao + '').val();
    if ($('#' + idKyBaoCao + '').val() == "") {
        $('#' + idTuNgay + '').prop('disabled', false);
        $('#' + idDenNgay + '').prop('disabled', false);
    } else if ($('#' + idKyBaoCao + '').val() < 13) {
        $('#' + idTuNgay + '').val('01/' + thangHienTai + '/' + now.getFullYear());
        $('#' + idDenNgay + '').val(getDaysOfMonth(new Date().getFullYear(), $('#' + idKyBaoCao + '').val()) + '/' + thangHienTai + '/' + now.getFullYear());
    }
    else if ($('#' + idKyBaoCao + '').val() == 13) {
        $('#' + idTuNgay + '').val('01/01/' + now.getFullYear());
        $('#' + idDenNgay + '').val('31/12/' + now.getFullYear());
    }
    else if ($('#' + idKyBaoCao + '').val() == 14) {
        $('#' + idTuNgay + '').val('01/01/' + now.getFullYear());
        $('#' + idDenNgay + '').val('31/03/' + now.getFullYear());
    }
    else if ($('#' + idKyBaoCao + '').val() == 15) {
        $('#' + idTuNgay + '').val('01/04/' + now.getFullYear());
        $('#' + idDenNgay + '').val('30/06/' + now.getFullYear());
    }
    else if ($('#' + idKyBaoCao + '').val() == 16) {
        $('#' + idTuNgay + '').val('01/07/' + now.getFullYear());
        $('#' + idDenNgay + '').val('30/09/' + now.getFullYear());
    }
    else if ($('#' + idKyBaoCao + '').val() == 17) {
        $('#' + idTuNgay + '').val('01/10/' + now.getFullYear());
        $('#' + idDenNgay + '').val('31/12/' + now.getFullYear());
    }
    else if ($('#' + idKyBaoCao + '').val() == 18) {
        $('#' + idTuNgay + '').val('01/01/' + now.getFullYear());
        $('#' + idDenNgay + '').val('30/06/' + now.getFullYear());
    }
    else if ($('#' + idKyBaoCao + '').val() == 19) {
        $('#' + idTuNgay + '').val('01/07/' + now.getFullYear());
        $('#' + idDenNgay + '').val('31/12/' + now.getFullYear());
    }
    else if ($('#' + idKyBaoCao + '').val() == 20) {
        $('#' + idTuNgay + '').prop('disabled', false);
        $('#' + idDenNgay + '').prop('disabled', false);
    }
}
function getDaysOfMonth(year, month) {
    return new Date(year, month, 0).getDate();
}

$(function () {
    $('.date-picker').datepicker({
        format: 'dd/mm/yyyy',//use this option to display seconds
        autoclose: true,
        todayHighlight: true,
        startDate: new Date('1970-01-01'),
        endDate: new Date('2079-12-31')
    }).next().on(ace.click_event, function () {
        $(this).prev().focus();
    });
    $(document).on('keyup', '.number-format', function () {
        $(this).val(formatNumber($(this).val()));
    });
    $(document).on('change', '.number-format', function (evt) {
        $(this).val(formatNumber($(this).val()));
    });
    //set
    $("botton").one('dblclick', function (event) {
        event.preventDefault();
    });
});
function getAjax(kieuTraVe, duongDanAjax, duLieuGui) {
    var result = null;
    $.ajax({
        type: "POST",
        url: duongDanAjax,
        data: JSON.stringify(duLieuGui),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            result = response.d;
        },
        error: function (response) {
            result = null;
            console.log(response);
        }
    });
    if (result === null) return null;
    // xử lý kiểu trả về
    switch (kieuTraVe.toLowerCase()) {
        case "string":
            return result;
            break;
        case "boolean":
            try {
                return JSON.parse((result).toString().toLowerCase());
            } catch (e) {
                return false;
            }
            break;
        case "json":
            try {
                return JSON.parse(result.toString());
            } catch (e) {
                console.log(e);
            }
            break;
        default:
            return null;
            break;
    }
}
var quyenTruyCap;
function kiemTraPhanQuyen() {
    $.ajax({
        type: "POST",
        url: "../../Services/ServiceSystem.asmx/kiemTraPhanQuyen",
        data: "{}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            quyenTruyCap = JSON.parse(response.d);
        },
        error: function () {
            quyenTruyCap = "";
        }
    });
}
function Loadding(class_) {
    $('' + class_ + '').append('<div class="message-loading-overlay"><i class="fa-spin ace-icon fa fa-spinner orange2 bigger-260"></i></div>');
}
function Loadding_Finish(class_) {
    $('' + class_ + '').find('.message-loading-overlay').remove();
}
function An_HienNut(idBotton, thaoTac) {
    $('' + idBotton + '').css("visibility", '' + thaoTac + '');
    $('' + idBotton + '').css("display", '' + thaoTac + '');
}
function HienThiControl(idBotton, visibe) {
    if (visibe) {
        $('' + idBotton + '').css("visibility", "visible");
        $('' + idBotton + '').css("display", "inline-block");
    }
    else {
        $('' + idBotton + '').css("visibility", "hidden");
        $('' + idBotton + '').css("display", "none");
    }
}
function HienThongBao(tieudeTB, noidungTB, loaiTB) {
    switch (loaiTB) {
        case "Loi":
            //lỗi
            $.gritter.add({
                title: tieudeTB,
                text: noidungTB,
                class_name: 'gritter-error' + (!$('#gritter-light').get(0).checked ? ' gritter-light' : '')
            });
            break;
        case "ThanhCong":
            //thành công
            $.gritter.add({
                title: tieudeTB,
                text: noidungTB,
                class_name: 'gritter-success' + (!$('#gritter-light').get(0).checked ? ' gritter-light' : '')
            });
            break;
        case "CanhBao":
            //cảnh báo
            $.gritter.add({
                title: tieudeTB,
                text: noidungTB,
                class_name: 'gritter-warning' + (!$('#gritter-light').get(0).checked ? ' gritter-light' : '')
            });
            break;
        case "ChiTiet":
            // hiện chi tiêt cảnh báo
            $.gritter.add({
                title: tieudeTB,
                text: noidungTB,
                class_name: 'gritter-warning gritter-center' + (!$('#gritter-light').get(0).checked ? ' gritter-light' : '')
            });
            break;

    }
}
//Loại bỏ các khoảng trắng ở đầu, cuối và dư thừa của chuỗi.
function trimSpace(str) {
    if (str == "")
        return str;
    else
        return str.replace(/(?:(?:^|\n)\s+|\s+(?:$|\n))/g, "").replace(/\s+/g, " ");
}
//kiem tra email
function KiemTraEmail(sEmail) {
    var filter = /^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/;
    if (filter.test(sEmail)) {
        return true;
    }
    else {
        return false;
    }
}
//kiem tra sdt
function KiemTraSDT(txtPhone) {
    var filter = /^[0-9]+$/;
    if (filter.test(txtPhone)) {
        return true;
    }
    else {
        return false;
    }
}
//kiem tra ngay thang năm 
function KiemTraNgay(dtValue) {
    var dtRegex = new RegExp(/\b\d{1,2}[\/-]\d{1,2}[\/-]\d{4}\b/);
    return dtRegex.test(dtValue);
}
//cho input chỉ nhập số
function isNumberKey(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 31 && (charCode < 48 || charCode > 57))
        return false;

    return true;
}
//function loadComBobox(idCombo, textChon, tenBang, cotTruyVan, dieuKien) {
//    $('#' + idCombo + '').empty().append("<option value=''>" + textChon + "</option>");
//    $.ajax({
//        type: "POST",
//        url: "../../Services/ServiceSystem.asmx/loadCombobox",
//        data: "{\"tenBang\":\"" + tenBang + "\", \"cotTruyVan\":\"" + cotTruyVan + "\", \"dieuKien\":\"" + dieuKien + "\" }",
//        contentType: "application/json; charset=utf-8",
//        dataType: "json",
//        async: false,
//        success: function (response) {
//            var array = JSON.parse(response.d);
//            if (array != '') {
//                for (var i = 0; i < array.length; ++i) {
//                    if (cotTruyVan.split(",").length > 2) {
//                        $('#' + idCombo + '').append(`<option value='${array[i][cotTruyVan.split(",")[0] + ""]}'>${array[i][cotTruyVan.split(",")[1].split("=")[0] + ""]}</option>`);
//                    }
//                    else {
//                        $('#' + idCombo + '').append(`<option value='${array[i][cotTruyVan.split(",")[0] + ""]}'>${array[i][cotTruyVan.split(",")[1]]}</option>`);
//                    }
//                }
//            }
//        },
//        error: function (x, e) {
//        }
//    });
//    $('#' + idCombo).select2({
//        width: '100%'
//    });
//}
function loadComBoboxTuMang(idCombo, textChon, tenValue, tenText, mangdulieu) {
    $('#' + idCombo).empty().append(`<option value=''>${textChon}</option>`);
    if (mangdulieu != '') {
        for (var i = 0; i < mangdulieu.length; ++i)
            $('#' + idCombo + '').append(`<option value='${mangdulieu[i][tenValue]}'>${mangdulieu[i][tenText]}</option>`);
    }
    $('#' + idCombo).select2({
        width: '100%'
    });
}

function Tru2So(a, b) {
    var param = new Array();
    param[0] = a;
    param[1] = b;
    var data = NTS.getAjax('string', "/Services/ServiceSystem.asmx/Tru2So", { data: param });
    return data;
}
function Nhan2So(a, b) {
    var param = new Array();
    param[0] = a;
    param[1] = b;
    var data = NTS.getAjax('string', "/Services/ServiceSystem.asmx/Nhan2So", { data: param });
    return data;
}