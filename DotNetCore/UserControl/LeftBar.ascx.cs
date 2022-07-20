using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB_DLL;
using QLCV2020.Class;
using System.Web.SessionState;
namespace QLCV2020.UserControl
{
    public partial class LeftBar : System.Web.UI.UserControl
    {
        StringBuilder sb = new StringBuilder();
        StringBuilder sb_ = new StringBuilder();
        protected void Page_Load(object sender, EventArgs e)
        {
            sb.Append("");

        }
        protected void rpMainMenu_OnInit(object sender, EventArgs e)
        {
            rpMainMenu.DataSource = LoadMainMenu_lv1();
            rpMainMenu.DataBind();

        }
        protected string CheckOpen(string motherID)
        {
            DataTable dtData = LoadMainMenu_child(motherID);
            sb_.Clear();
            if (dtData != null && dtData.Rows.Count > 0)
            {

                foreach (DataRow row in dtData.Rows)
                {
                    if (row["DuongDan"].ToString().ToLower() == HttpContext.Current.Request.Url.AbsolutePath.ToString().ToLower())
                    {
                        sb_.Append("active open");
                    }
                    else
                    {
                        DataTable dtData1 = LoadMainMenu_child(row["MenuID"].ToString());
                        if (dtData1 != null && dtData1.Rows.Count > 0)
                        {

                            foreach (DataRow row1 in dtData1.Rows)
                            {
                                if (row1["DuongDan"].ToString().ToLower() == HttpContext.Current.Request.Url.AbsolutePath.ToString().ToLower())
                                {
                                    sb_.Append("active open");
                                }
                                else
                                {
                                    DataTable dtData2 = LoadMainMenu_child(row1["MenuID"].ToString());
                                    if (dtData2 != null && dtData2.Rows.Count > 0)
                                    {

                                        foreach (DataRow row2 in dtData2.Rows)
                                        {
                                            if (row2["DuongDan"].ToString().ToLower() == HttpContext.Current.Request.Url.AbsolutePath.ToString().ToLower())
                                            {
                                                sb_.Append("active open");
                                            }
                                            else
                                            {
                                                DataTable dtData3 = LoadMainMenu_child(row2["MenuID"].ToString());
                                                if (dtData3 != null && dtData3.Rows.Count > 0)
                                                {

                                                    foreach (DataRow row3 in dtData3.Rows)
                                                    {
                                                        if (row3["DuongDan"].ToString().ToLower() == HttpContext.Current.Request.Url.AbsolutePath.ToString().ToLower())
                                                        {
                                                            sb_.Append("active open");
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return sb_.ToString();
        }
        protected string ChildMenu(string motherID)
        {
            StringBuilder sb = new StringBuilder();
            DataTable dtData = LoadMainMenu_child(motherID);
            sb.Append("");
            if (dtData != null && dtData.Rows.Count > 0)
            {
                sb.Append("<ul class='submenu nav-hide'>");
                foreach (DataRow row in dtData.Rows)
                {
                    if (row["DuongDan"].ToString().ToLower() == HttpContext.Current.Request.Url.AbsolutePath.ToString().ToLower())
                    {
                        sb.AppendFormat("<li class=\"active\"><a href=\"{0}\" " + (row["MenuButton"].ToString() == "True" ? "onclick=\"OnClickMenu('{0}')\"" : "") + ">", row["DuongDan"]);
                    }
                    else
                    {
                        if (row["DuongDan"].ToString() == "" || row["DuongDan"].ToString() == null)
                        {
                            sb.AppendFormat("<li class=\"" + CheckOpen(row["MenuID"].ToString()) + "\"><a class=\"dropdown-toggle\" href=\"{0}\">", row["DuongDan"]);
                        }
                        else
                        {
                            sb.AppendFormat("<li class=\"" + CheckOpen(row["MenuID"].ToString()) + "\"><a href=\"{0}\" "+(row["MenuButton"].ToString()=="True"? "onclick=\"OnClickMenu('{0}')\"":"") +">", row["DuongDan"]);
                        }
                    }
                    sb.AppendFormat("<i class='menu-icon {0}' ></i>", row["Icon"]);
                    sb.AppendFormat("{0}", row["TenMenu"]);
                    if (row["DuongDan"].ToString() == "" || row["DuongDan"].ToString() == null)
                    {
                        sb.Append("<b class=\"arrow fa fa-angle-down\"></b></a>");
                    }
                    else
                    {
                        sb.Append("</a>");
                    }
                    sb.Append(ChildMenu(row["MenuID"].ToString()));
                    sb.Append("</li>");
                }
                sb.Append("</ul>");
            }

            return sb.ToString();
        }
        public DataTable LoadMainMenu_child(string motherID)
        {

            try
            {
                SqlFunction sqlFun2 = new SqlFunction(HttpContext.Current.Session.GetConnectionString2());
                System.Data.SqlClient.SqlConnectionStringBuilder connBuilder = new System.Data.SqlClient.SqlConnectionStringBuilder();
                connBuilder.ConnectionString = HttpContext.Current.Session.GetConnectionString2();
                string database1 = connBuilder.InitialCatalog;
                string dieuKien = "",dieuKien2="",TongHop="";
                if (HttpContext.Current.Session.GetUser().UserGroupCode.Contains("QL"))
                {
                    dieuKien = "" + database1 + ".dbo.NhanVien.PhongBanID =N'" + HttpContext.Current.Session.GetUser().PhongBanID + "'";
                    dieuKien2 = "" + database1 + ".dbo.PhongBan.PhongBanID =N'" + HttpContext.Current.Session.GetUser().PhongBanID + "'";
                }
                if (!HttpContext.Current.Session.GetUser().UserGroupCode.Contains("QL") && !HttpContext.Current.Session.GetUser().UserGroupCode.Contains("LD") && !HttpContext.Current.Session.GetUser().UserGroupCode.Contains("GS"))
                {
                    dieuKien = "" + database1 + ".dbo.NhanVien.NhanVienID =N'" + HttpContext.Current.Session.GetUser().NhanVienID + "'";
                    dieuKien2 = "1=2";
                }
                if (HttpContext.Current.Session.GetUser().UserGroupCode.Contains("LD"))
                {
                    TongHop = @"UNION ALL
                  SELECT [MenuID] = '11111111-0000-0000-0000-000000000000'
                  ,[TenMenu] = N'Tổng hợp'
                  , DuongDan = ('/thong-ke/' + CONVERT(NVARCHAR(50), '11111111-0000-0000-0000-000000000000'))
                  ,[Icon] = 'fa fa-bar-chart'
                  ,[MenuID_cha] = '00000000-0000-0000-0000-000000000000'
                  ,[SapXep] = 999
                  ,[MenuButton] = 0";
                }
                if (HttpContext.Current.Session.GetUser().UserGroupCode.Contains("LD")|| HttpContext.Current.Session.GetUser().UserGroupCode.Contains("GS"))
                {
                    dieuKien = "1=1";
                    dieuKien2 = "1=1";
                }
                SqlFunction sqlFun = new SqlFunction(HttpContext.Current.Session.GetConnectionString1());
                if (motherID == "00000000-0000-0000-0000-000000000000")
                {
                    return sqlFun.GetData(@"SELECT * FROM (SELECT
                  [MenuID]
                  ,[TenMenu]
                  ,DuongDan = isnull(DuongDan,'')
                  ,[Icon]
                  ,[MenuID_cha]
                  ,[SapXep]
                  ,[MenuButton]
                  FROM [dbo].[Menu]   WHERE  isnull(HienThi,0) = '1' and isnull(MenuButton,0) = '0' and MenuID_cha = '" + motherID + "' AND MenuID IN (SELECT MenuID FROM dbo.UserPermiss  where UserID = N'" + HttpContext.Current.Session.GetUser().UserID + @"')
                  UNION ALL
                  SELECT[MenuID] = NhanVienID
                  ,[TenMenu] = TenNhanVien
                  , DuongDan = ('/thong-ke/' + CONVERT(NVARCHAR(50), NhanVienID))
                  ,[Icon] = 'fa fa-bar-chart'
                  ,[MenuID_cha] = '" + motherID + @"'
                  ,[SapXep] = 998
                  ,[MenuButton] = 0
                  FROM " + database1 + ".dbo.NhanVien WHERE " + database1 + ".dbo.NhanVien.NgungTD = 0 and " + dieuKien + @"
                  "+ TongHop + @"
                  UNION ALL
                  SELECT[MenuID] = PhongBanID
                  ,[TenMenu] = TenPhongBan
                  , DuongDan = ('/thong-ke/' + CONVERT(NVARCHAR(50), PhongBanID))
                  ,[Icon] = 'fa fa-bar-chart'
                  ,[MenuID_cha] = '" + motherID + @"'
                  ,[SapXep] = 1000
                  ,[MenuButton] = 0
                  FROM " + database1 + ".dbo.PhongBan WHERE " + database1 + ".dbo.PhongBan.NgungTD = 0 and " + dieuKien2 + ") AS bang1 ORDER BY  SapXep,(case when CHARINDEX(' ',TenMenu,1) > 0 then ltrim(right(TenMenu,CHARINDEX(' ',REVERSE(TenMenu),1))) else TenMenu END) ASC ");
                }
                else
                {
                    return sqlFun.GetData(@"SELECT * FROM (SELECT
                  [MenuID]
                  ,[TenMenu]
                  ,DuongDan = isnull(DuongDan,'')
                  ,[Icon]
                  ,[MenuID_cha]
                  ,[SapXep]
                  ,[MenuButton]
                  FROM [dbo].[Menu]   WHERE  isnull(HienThi,0) = '1' and isnull(MenuButton,0) = '0' and MenuID_cha = '" + motherID + "' AND MenuID IN (SELECT MenuID FROM dbo.UserPermiss  where UserID = N'" + HttpContext.Current.Session.GetUser().UserID + @"')
                 ) AS bang1 ORDER BY  SapXep ");
                }    
            }
            catch (Exception)
            {
                return null;
            }
        }
        public DataTable LoadMainMenu_lv1()
        {
            try
            {
                SqlFunction sqlFun = new SqlFunction(HttpContext.Current.Session.GetConnectionString1());
                return sqlFun.GetData(@"SELECT * FROM (SELECT
                  [MenuID]
                  ,[TenMenu]
                  ,DuongDan = isnull(DuongDan,'')
                  ,[Icon]
                  ,[MenuID_cha]
                  ,[SapXep]
                  ,[MenuButton]
                  FROM [dbo].[Menu] WHERE   isnull(HienThi,0) = '1' and  isnull(MenuButton,0) = '0' and MenuID_cha IS NULL AND MenuID IN (SELECT MenuID FROM dbo.UserPermiss  where UserID = N'" + HttpContext.Current.Session.GetUser().UserID + @"')
                   UNION ALL
                  SELECT[MenuID] = '00000000-0000-0000-0000-000000000000'
                  ,[TenMenu] = N'Thống kê theo nhân viên/Phòng/Bộ phận'
                  , DuongDan = ''
                  ,[Icon] = 'fa fa-bar-chart'
                  ,[MenuID_cha] = NULL
                  ,[SapXep] = '99'
                  ,[MenuButton] = 0
                 ) AS bang1
                  ORDER BY bang1.SapXep,bang1.TenMenu");
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}