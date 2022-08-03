using Microsoft.AspNetCore.Http;
using DotNetCore.DataConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB_DLL;
using Newtonsoft.Json;

namespace DotNetCore.Class
{
    public static class NTSSession 
    {
        public static string ntsNamSuDung = "ntsNamSuDung";

        public static string GetCurrentDatetimeMMddyyyy(string format)
        {
            return Convert.ToDateTime(DateTime.Now).ToString(format);
        }
        public static HttpContext context;
        public static ISession session = context.Session;
        public static int GetHeight()
        {
            return (int)session.GetInt32("heightSr");
        }
        
        public static void SetHeight(int value)
        {
            session.SetInt32("heightSr", value);
        }

        public static int GetWidth()
        {
            return (int)session.GetInt32("widthSr");
        }

        public static void SetWidth(int value)
        {
            session.SetInt32("widthSr", value);
        }

        //public static void SetFullScreen(bool value)
        //{
        //    session[ntsEnumSessionName.ntsFullScreen] = value;
        //}

        public static int GetFullScreen()
        {
            return (int)session.GetInt32(ntsEnumSessionName.ntsFullScreen);
        }

        // Gán chuỗi kết nối vào SessionName
        public static void SetConnectionString1(string sqlConnectionString)
        {
            session.SetString(ntsEnumSessionName.ntsConnectionString1, sqlConnectionString);
        }

        // Lấy chuỗi kết nối từ SessionName
        public static string GetConnectionString1()
        {
            return session.GetString(ntsEnumSessionName.ntsConnectionString1) as String;
        }

        // Thay đổi cơ sở dữ liệu kết nối cho chuỗi kết nối trong SessionName
        public static void ChangeConnectionString1(string sqlConnectionString, string dbNameSource, string dbNameDes)
        {
            session.SetString(ntsEnumSessionName.ntsConnectionString1, sqlConnectionString.Replace(dbNameSource, dbNameDes));
        }

        // Gán chuỗi kết nối vào SessionName
        public static void SetConnectionString2(string sqlConnectionString)
        {
            session.SetString(ntsEnumSessionName.ntsConnectionString2, sqlConnectionString);
        }

        // Lấy chuỗi kết nối từ SessionName
        public static string GetConnectionString2()
        {
            return session.GetString(ntsEnumSessionName.ntsConnectionString2) as String;
        }

        // Thay đổi cơ sở dữ liệu kết nối cho chuỗi kết nối trong SessionName
        public static void ChangeConnectionString2(string sqlConnectionString, string dbNameSource, string dbNameDes)
        {
            session.SetString(ntsEnumSessionName.ntsConnectionString2, sqlConnectionString.Replace(dbNameSource, dbNameDes));
        }

        //Gán Mã đơn vị 
        public static void SetDonVi(DonVi value)
        {
            session.SetString("donvi", JsonConvert.SerializeObject(value));
        }

        //Lấy Mã đơn vị
        public static DonVi GetDonVi()
        {
            return JsonConvert.DeserializeObject<DonVi>(session.GetString("donvi"));
        }

        //Gán người dùng
        public static void SetUser(User value)
        {
            session.SetString("user", JsonConvert.SerializeObject(value));
        }

        //Lấy người dùng
        public static User GetUser()
        {
            return JsonConvert.DeserializeObject<User>(session.GetString("user"));
        }

        //Lấy năm sử dụng
        public static void SetNamSudung(string value)
        {
            session.SetString(ntsNamSuDung, value);
        }

        public static string GetNamSudung()
        {
            return session.GetString(ntsNamSuDung) as string;
        }

        public static string GetKyBaoCao()
        {
            return (string)session.GetString("KyBaoCao");
        }

        public static void SetKyBaoCao(string value)
        {
            session.SetString("KyBaoCao", value);
        }

        //public static string GetKeyUser()
        //{
        //    return (string)session["KeyUser"];
        //}

        //public static void SetKeyUser(string value)
        //{
        //    session["KeyUser"] = value;
        //}

        //public static string GetKeyMaHoa()
        //{
        //    return (string)session["MaHoa"];
        //}

        //public static void SetKeyMaHoa(string value)
        //{
        //    session["MaHoa"] = value;
        //}
        //public static void SetNgayDauKy(string value)
        //{
        //    session["NgayDauKy"] = value;
        //}

        //public static string GetNgayDauKy()
        //{
        //    return NTSSession.GetDonVi().NgayDauKy.Value.ToString("dd/MM/yyyy").Substring(6, 4) + "/" + NTSSession.GetDonVi().NgayDauKy.Value.ToString("dd/MM/yyyy").Substring(3, 2) + "/" + NTSSession.GetDonVi().NgayDauKy.Value.ToString("dd/MM/yyyy").Substring(0, 2);
        //}

        //public static void SetNgayCuoiKy(string value)
        //{
        //    session["NgayCuoiKy"] = value;
        //}

        //public static string GetNgayCuoiKy()
        //{
        //    return NTSSession.GetDonVi().NgayCuoiKy.Value.ToString("dd/MM/yyyy").Substring(6, 4) + "-" + NTSSession.GetDonVi().NgayCuoiKy.Value.ToString("dd/MM/yyyy").Substring(3, 2) + "-" + NTSSession.GetDonVi().NgayCuoiKy.Value.ToString("dd/MM/yyyy").Substring(0, 2);
        //}
        //public static void SetDonViXetDuyet(string value)
        //{
        //    session["DonViXetDuyet"] = value;
        //}

        //public static string GetDonViXetDuyet()
        //{
        //    return (string)session["DonViXetDuyet"];
        //}
    }
    public class Screen
    {
        public int width { set; get; }
        public int height { set; get; }

        public Screen(int _width, int _height)
        {
            this.width = _width;
            this.height = _height;
        }
    }
    public class KyBaoCao
    {
        public string tuNgay;
        public string denNgay;
        public string kyBaoCao;
        public string keyMaHoa;
        public KyBaoCao(string _tuNgay, string _denNgay, string _kyBaoCao, string _keyMaHoa)
        {
            this.tuNgay = _tuNgay;
            this.denNgay = _denNgay;
            this.kyBaoCao = _kyBaoCao;
            this.keyMaHoa = _keyMaHoa;
        }
    }
}
