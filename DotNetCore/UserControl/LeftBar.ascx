<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LeftBar.ascx.cs" Inherits="QLCV2020.UserControl.LeftBar" %>
<asp:Repeater runat="server" ID="rpMainMenu" OnInit="rpMainMenu_OnInit">
    <HeaderTemplate>
        <div id="sidebar" class="sidebar responsive ace-save-state" style="position: absolute; z-index: 1000" data-sidebar="true" data-sidebar-scroll="true" data-sidebar-hover="true">
            <%--			 <div id="sidebar" class="sidebar sidebar-fixed responsive menu-1024">	--%>
            <!-- sidebar menu start-->
            <ul class="nav nav-list">
    </HeaderTemplate>
    <ItemTemplate>
        <li class="<%# Eval("DuongDan").ToString() == HttpContext.Current.Request.Url.AbsolutePath.ToString() ? "active":  CheckOpen(DataBinder.Eval(Container.DataItem, "MenuID").ToString()) %> ">
            <a href="<%# Eval("DuongDan") %>" class="<%# Eval("DuongDan").ToString() =="" ? "dropdown-toggle": "" %>" <%# Eval("MenuButton").ToString() =="True" ? "onclick=\"OnClickMenu('"+DataBinder.Eval(Container.DataItem, "DuongDan").ToString()+"')\"": "" %> >
                <i class='menu-icon <%# Eval("Icon") %>'></i>
                <span class="menu-text"><%# Eval("TenMenu") %></span>
                <%# Eval("DuongDan").ToString() =="" ? "<b class='arrow fa fa-angle-down'></b>": "" %>
            </a><b class="arrow"></b>
            <%# ChildMenu(DataBinder.Eval(Container.DataItem, "MenuID").ToString())%>
        </li>
    </ItemTemplate>
    <FooterTemplate>
        </ul>
                <!-- sidebar menu end-->
        <div class="sidebar-toggle sidebar-collapse" id="sidebar-collapse">
            <i id="sidebar-toggle-icon" class="ace-icon fa fa-angle-double-left ace-save-state" data-icon1="ace-icon fa fa-angle-double-left" data-icon2="ace-icon fa fa-angle-double-right"></i>
        </div>
        </div>
    </FooterTemplate>
</asp:Repeater>

