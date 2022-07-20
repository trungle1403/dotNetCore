<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="QLCV2020.UserControl.Header" %>
<style>
    span#select2-selkybaocao-container {
        font-size: 12px !important;
    }

    label#ctl00_ctl16_lblNam {
        font-size: 15px;
    }
    .scroll-content {
    max-height: 300px !important;
}
</style>

<div id="navbar" class="navbar navbar-fixed-top">
    <input type="hidden" id="hdfHeader_kyBaoCao" value="" runat="server" />
    <div class="navbar-container ace-save-state" id="navbar-container">
        <button type="button" class="navbar-toggle menu-toggler pull-left" id="menu-toggler" data-target="#sidebar">
            <span class="sr-only">Toggle sidebar</span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
        </button>
        <div class="navbar-header pull-left">
            <a href="/trang-chu.html" class="navbar-brand">
                <small style="font-weight: bold;">
                    <i class="fa fa-universal-access"></i>
                    QLCV - <span style="color: yellow; font-weight: bold;">NTSOFT</span>
                </small>
            </a>
        </div>
        <div class="navbar-buttons navbar-header pull-right" role="navigation">
            <ul class="nav ace-nav">

                <li class="dropdown-modal">
                    <a href="/tra-cuu-nhanh.html">
                        <i class="ace-icon fa fa-search"></i>
                    </a>
                </li>
                <li class="purple dropdown-modal">
                    <a data-toggle="dropdown" class="dropdown-toggle" href="#" aria-expanded="false">
                        <i class="ace-icon fa fa-bell"></i>
                        <span class="badge badge-important">8</span>
                    </a>

                    <ul class="dropdown-menu-right dropdown-navbar navbar-blue dropdown-menu dropdown-caret dropdown-close">
                        <li class="dropdown-header">
                            <i class="ace-icon fa fa-exclamation-triangle"></i>
                            Thông báo
                        </li>

                        <li class="dropdown-content ace-scroll" style="position: relative;">
                            <div class="scroll-track" style="display: none;">
                                <div class="scroll-bar"></div>
                            </div>
                            <div class="scroll-content" style="">
                                <ul class="dropdown-menu dropdown-navbar navbar-pink">
                                    <li>
                                        <a href="#">
                                            <div class="clearfix">
                                                <span class="pull-left">
                                                    <i class="btn btn-xs no-hover btn-warning fa fa-comment"></i>
                                                    Công việc mới
                                                </span>
                                                <span class="pull-right badge badge-info" runat="server" id="CongViecMoi">+12</span>
                                            </div>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="#">
                                            <div class="clearfix">
                                                <span class="pull-left">
                                                    <i class="btn btn-xs no-hover btn-primary fa fa-comment"></i>
                                                    Công việc đang thực hiện
                                                </span>
                                                <span class="pull-right badge badge-info" runat="server" id="CongViecDangThucHien">+12</span>
                                            </div>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="#">
                                            <div class="clearfix">
                                                <span class="pull-left">
                                                    <i class="btn btn-xs no-hover btn-danger fa fa-comment"></i>
                                                    Công việc trễ deline
                                                </span>
                                                <span class="pull-right badge badge-info" runat="server" id="CongViecTreDeline">+12</span>
                                            </div>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="#">
                                            <div class="clearfix">
                                                <span class="pull-left">
                                                    <i class="btn btn-xs no-hover  btn-success  fa fa-comment"></i>
                                                    Công việc đã hoàn thành
                                                </span>
                                                <span class="pull-right badge badge-info" runat="server" id="CongViecDaHoanThanh">+12</span>
                                            </div>
                                        </a>
                                    </li>
                                </ul>
                            </div>
                        </li>
                        <li class="dropdown-footer">
                            <a href="#">Đi đến công việc
										<i class="ace-icon fa fa-arrow-right"></i>
                            </a>
                        </li>
                    </ul>
                </li>
                <li class="green dropdown-modal" id="dropdown-menu">
                    <a data-toggle="dropdown" class="dropdown-toggle" href="#">
                        <i class="ace-icon fa fa-calendar icon-animated-vertical" style="width: 60px;">
                            <label id="lblNam" style="padding-top: 0px; vertical-align: unset; line-height: 1.5; display: unset;" runat="server"></label>
                        </i>
                    </a>
                    <ul class="dropdown-menu-right dropdown-navbar navbar-blue dropdown-menu dropdown-caret" onclick="event.stopPropagation();">
                        <li class="dropdown-header">
                            <i class="ace-icon fa fa-calendar"></i>
                            Cập nhật kỳ báo cáo
                        </li>
                        <li class="dropdown-content">
                            <ul class="dropdown-menu dropdown-navbar">
                                <li style="line-height: 25px; padding: 10px;scroll-behavior:unset">
                                    <div class="row">
                                        <div class="col-md-5">
                                            <label>Kỳ báo cáo</label>
                                        </div>
                                        <div class="col-md-7">
                                            <select id="selKyBaoCao_head" name="selKyBaoCao_head" class="form-control input-sm">
                                            </select>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-5">
                                            <label>Từ ngày</label>
                                        </div>
                                        <div class="col-md-7">
                                            <div class="input-group">
                                                <input class="form-control input-sm date-picker" value="<%= Session["TuNgayHeader"] %>" type="text" id="txtTuNgay_head" data-date-format="dd/mm/yyyy" placeholder="dd/mm/yyyy" />
                                                <span class="input-group-addon" style="padding: 6px; border-radius: 0px 3px 3px 0px!important;">
                                                    <i class="fa fa-calendar bigger-110"></i>
                                                </span>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-5">
                                            <label>Đến ngày</label>
                                        </div>
                                        <div class="col-md-7">
                                            <div class="input-group">
                                                <input class="form-control input-sm date-picker" type="text" id="txtDenNgay_head" value="<%= Session["DenNgayHeader"] %>" data-date-format="dd/mm/yyyy" placeholder="dd/mm/yyyy" />
                                                <span class="input-group-addon" style="padding: 6px; border-radius: 0px 3px 3px 0px!important;">
                                                    <i class="fa fa-calendar bigger-110"></i>
                                                </span>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-5">
                                            <label>Key mã hoá</label>
                                        </div>
                                        <div class="col-md-7">
                                            <input class="form-control input-sm" type="password" id="KeyMaHoa_H" value="<%= Session["KeyMaHoa"] %>" placeholder="Nhập vào key mã hoá dữ liệu" />
                                        </div>
                                    </div>
                                </li>
                            </ul>

                        </li>
                        <li class="dropdown-footer" style="text-align: center; padding: 0px !important; background-color: #ECF2F7;">
                            <div>
                                <a href="#" id="btnLuuVaDongKyBaoCao" class="btn btn-success" onclick="capNhatKyBaoCao();return false;">
                                    <i class="ace-icon fa fa-floppy-o bigger-110"></i>&nbsp;Cập nhật </a>
                            </div>
                        </li>
                    </ul>
                </li>












                <li class="light-blue dropdown-modal">
                    <a data-toggle="dropdown" href="#" class="dropdown-toggle">
                        <img class="nav-user-photo" src="/Content/themes/Theme_1/images/avatars/user.jpg" alt="Jason's Photo" />
                        <span class="user-info">
                            <small>Chào,</small>
                            <label id="lblUser_us" style="padding-top: 0px; vertical-align: unset; line-height: 1.5; display: unset;" runat="server"></label>
                        </span>
                        <i class="ace-icon fa fa-caret-down"></i>
                    </a>
                    <ul class="user-menu dropdown-menu-right dropdown-menu dropdown-yellow dropdown-caret dropdown-close">
                        <li>
                            <a href="#">
                                <i class="ace-icon fa fa-user"></i>
                                <label id="lblDonVi" style="padding-top: 0px; vertical-align: unset; line-height: 1.5; display: unset;" runat="server"></label>
                            </a>
                        </li>
                        <li>
                            <a href="/doi-mat-khau.html">
                                <i class="ace-icon fa fa-lock"></i>
                                Đổi mật khẩu
                            </a>
                        </li>
                        <li class="divider"></li>
                        <li>
                            <a href="/dang-xuat.html">
                                <i class="ace-icon fa fa-power-off"></i>
                                Đăng xuất
                            </a>
                        </li>
                    </ul>
                </li>


            </ul>
        </div>
    </div>
</div>


