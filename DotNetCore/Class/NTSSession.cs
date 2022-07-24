//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace DotNetCore.Class
//{
//    public static class NTSSession
//    {
//        public static string ntsNamSuDung = "ntsNamSuDung";

//        public static string GetCurrentDatetimeMMddyyyy(string format)
//        {
//            return Convert.ToDateTime(DateTime.Now).ToString(format);
//        }
//        public static int GetHeight()
//        {
//            return (int)HttpContext.Current.Session["heightSr"];
//        }

//        public static void SetHeight(int value)
//        {
//            HttpContext.Current.Session["heightSr"] = value;
//        }

//        public static int GetWidth()
//        {
//            return (int)HttpContext.Current.Session["widthSr"];
//        }

//        public static void SetWidth(int value)
//        {
//            HttpContext.Current.Session["widthSr"] = value;
//        }

//        public static void SetFullScreen(bool value)
//        {
//            HttpContext.Current.Session[ntsEnumSessionName.ntsFullScreen] = value;
//        }

//        public static bool GetFullScreen()
//        {
//            return (bool)HttpContext.Current.Session[ntsEnumSessionName.ntsFullScreen];
//        }

//        // Gán chuỗi kết nối vào SessionName
//        public static void SetConnectionString1(string sqlConnectionString)
//        {
//            HttpContext.Current.Session[ntsEnumSessionName.ntsConnectionString1] = sqlConnectionString;
//        }

//        // Lấy chuỗi kết nối từ SessionName
//        public static string GetConnectionString1()
//        {
//            return HttpContext.Current.Session[ntsEnumSessionName.ntsConnectionString1] as String;
//        }

//        // Thay đổi cơ sở dữ liệu kết nối cho chuỗi kết nối trong SessionName
//        public static void ChangeConnectionString1(string sqlConnectionString, string dbNameSource, string dbNameDes)
//        {
//            HttpContext.Current.Session[ntsEnumSessionName.ntsConnectionString1] = sqlConnectionString.Replace(dbNameSource, dbNameDes);
//        }

//        // Gán chuỗi kết nối vào SessionName
//        public static void SetConnectionString2(string sqlConnectionString)
//        {
//            HttpContext.Current.Session[ntsEnumSessionName.ntsConnectionString2] = sqlConnectionString;
//        }

//        // Lấy chuỗi kết nối từ SessionName
//        public static string GetConnectionString2()
//        {
//            return HttpContext.Current.Session[ntsEnumSessionName.ntsConnectionString2] as String;
//        }

//        // Thay đổi cơ sở dữ liệu kết nối cho chuỗi kết nối trong SessionName
//        public static void ChangeConnectionString2(string sqlConnectionString, string dbNameSource, string dbNameDes)
//        {
//            HttpContext.Current.Session[ntsEnumSessionName.ntsConnectionString2] = sqlConnectionString.Replace(dbNameSource, dbNameDes);
//        }

//        //Gán Mã đơn vị
//        public static void SetDonVi(DonVi value)
//        {
//            HttpContext.Current.Session["donvi"] = value;
//        }

//        //Lấy Mã đơn vị
//        public static DonVi GetDonVi()
//        {
//            return HttpContext.Current.Session["donvi"] as DonVi;
//        }

//        //Gán người dùng
//        public static void SetUser(User value)
//        {
//            HttpContext.Current.Session["user"] = value;
//        }

//        //Lấy người dùng
//        public static User GetUser()
//        {
//            return HttpContext.Current.Session["user"] as User;
//        }

//        //Lấy năm sử dụng
//        public static void SetNamSudung(string value)
//        {
//            HttpContext.Current.Session[ntsNamSuDung] = value;
//        }

//        public static string GetNamSudung()
//        {
//            return HttpContext.Current.Session[ntsNamSuDung] as string;
//        }

//        public static string GetKyBaoCao()
//        {
//            return (string)HttpContext.Current.Session["KyBaoCao"];
//        }

//        public static void SetKyBaoCao(string value)
//        {
//            HttpContext.Current.Session["KyBaoCao"] = value;
//        }

//        public static string GetKeyUser()
//        {
//            return (string)HttpContext.Current.Session["KeyUser"];
//        }

//        public static void SetKeyUser(string value)
//        {
//            HttpContext.Current.Session["KeyUser"] = value;
//        }

//        public static string GetKeyMaHoa()
//        {
//            return (string)HttpContext.Current.Session["MaHoa"];
//        }

//        public static void SetKeyMaHoa(string value)
//        {
//            HttpContext.Current.Session["MaHoa"] = value;
//        }
//        public static void SetNgayDauKy(string value)
//        {
//            HttpContext.Current.Session["NgayDauKy"] = value;
//        }

//        public static string GetNgayDauKy()
//        {
//            return NTSSession.GetDonVi().NgayDauKy.Value.ToString("dd/MM/yyyy").Substring(6, 4) + "/" + NTSSession.GetDonVi().NgayDauKy.Value.ToString("dd/MM/yyyy").Substring(3, 2) + "/" + NTSSession.GetDonVi().NgayDauKy.Value.ToString("dd/MM/yyyy").Substring(0, 2);
//        }

//        public static void SetNgayCuoiKy(string value)
//        {
//            HttpContext.Current.Session["NgayCuoiKy"] = value;
//        }

//        public static string GetNgayCuoiKy()
//        {
//            return NTSSession.GetDonVi().NgayCuoiKy.Value.ToString("dd/MM/yyyy").Substring(6, 4) + "-" + NTSSession.GetDonVi().NgayCuoiKy.Value.ToString("dd/MM/yyyy").Substring(3, 2) + "-" + NTSSession.GetDonVi().NgayCuoiKy.Value.ToString("dd/MM/yyyy").Substring(0, 2);
//        }
//        public static void SetDonViXetDuyet(string value)
//        {
//            HttpContext.Current.Session["DonViXetDuyet"] = value;
//        }

//        public static string GetDonViXetDuyet()
//        {
//            return (string)HttpContext.Current.Session["DonViXetDuyet"];
//        }
//    }
//    public class Screen
//    {
//        public int width { set; get; }
//        public int height { set; get; }

//        public Screen(int _width, int _height)
//        {
//            this.width = _width;
//            this.height = _height;
//        }
//    }
//    public class KyBaoCao
//    {
//        public string tuNgay;
//        public string denNgay;
//        public string kyBaoCao;
//        public string keyMaHoa;
//        public KyBaoCao(string _tuNgay, string _denNgay, string _kyBaoCao, string _keyMaHoa)
//        {
//            this.tuNgay = _tuNgay;
//            this.denNgay = _denNgay;
//            this.kyBaoCao = _kyBaoCao;
//            this.keyMaHoa = _keyMaHoa;
//        }
//    }
//}
