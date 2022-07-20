using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.SessionState;
using System.Xml.Linq;
using QLCV2020.Class;
using QLCV2020.DataConnect;
using WEB_DLL;
using System.Text;
using System.Data.SqlClient;
using System.Web.Services;
namespace QLCV2020.UserControl
{
    public partial class Header : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (HttpContext.Current.Session.GetUser().TenDangNhap.ToString() != "")
                {
                    SqlFunction sqlFun = new SqlFunction(HttpContext.Current.Session.GetConnectionString2());
                    if (sqlFun.GetOneStringField(@"SELECT top 1 TenNhanVien FROM dbo.NhanVien WHERE NhanVienID=N'" + HttpContext.Current.Session.GetUser().NhanVienID.ToString() + "'").ToString() != "")
                    {
                        lblUser_us.InnerHtml = sqlFun.GetOneStringField(@"SELECT TenNhanVien FROM dbo.NhanVien WHERE NhanVienID=N'" + HttpContext.Current.Session.GetUser().NhanVienID.ToString() + "'").ToString();
                    }
                    else
                    {
                        lblUser_us.InnerHtml = HttpContext.Current.Session.GetUser().TenDangNhap.ToString();

                    }
                    string CongViecMoi_ = "1";
                    string CongViecDangThucHien_ = "2";
                    string CongViecTreDeline_ = "3";
                    string CongViecDaHoanThanh_ = "4";

                    CongViecDangThucHien.InnerHtml = CongViecDangThucHien_;
                    CongViecMoi.InnerHtml = CongViecMoi_;
                    CongViecTreDeline.InnerHtml = CongViecTreDeline_;
                    CongViecDaHoanThanh.InnerHtml = CongViecDaHoanThanh_;
                    lblNam.InnerHtml = HttpContext.Current.Session.GetNamSudung().ToString();
                    lblDonVi.InnerHtml = HttpContext.Current.Session.GetDonVi().DonViCode.ToString() + " - "+ HttpContext.Current.Session.GetDonVi().TenDonVi.ToString();
                    HttpContext.Current.Session.Add("TuNgayHeader", HttpContext.Current.Session.GetDonVi().NgayDauKy.Value.ToString("dd/MM/yyyy"));
                    HttpContext.Current.Session.Add("DenNgayHeader", HttpContext.Current.Session.GetDonVi().NgayCuoiKy.Value.ToString("dd/MM/yyyy"));
                    HttpContext.Current.Session.Add("KeyMaHoa", HttpContext.Current.Session.GetKeyMaHoa());
                    hdfHeader_kyBaoCao.Value = HttpContext.Current.Session.GetKyBaoCao();
                }
            }
            catch(Exception ex)
            {
            }
        }
    }
}