using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore.Class
{
    #region gán phân quyền
    public class PageInfo
    {
        public static string KeyMaHoaXacNhan = "rateAnd2013";
        public static string KeyMaHoaMatKhau = "rateAnd2012";
        public PageInfo()
        {
            try
            {
                if (NTSSession.GetUser().UserID.ToString() == "" || NTSSession.GetUser().UserID == null)
                {

                    HttpContext.Current.Session.Abandon();
                    HttpContext.Current.Session.Clear();
                    HttpContext.Current.Session.Remove("lanDangNhap");
                    HttpContext.Current.Session.RemoveAll();
                    HttpContext.Current.Response.Redirect("/hethong/login");
                }
                else
                {
                    string _pageName = HttpContext.Current.Request.FilePath.ToString();
                    DataSet ds = new DataSet();
                    SqlParameter[] paraValue = {
                    new SqlParameter("@UserID", NTSSession.GetUser().UserID),
                };
                    ds = SqlHelper.ExecuteDataset(
                    NTSSession.GetConnectionString1()
                    , CommandType.Text
                    , @"SELECT top 1 convert(nvarchar(250), MenuID), TenMenu, NoiDungTieuDe = (CASE WHEN ISNULL(NoiDungTieuDe, '') = '' THEN TenMenu ELSE NoiDungTieuDe END) FROM dbo.Menu WHERE (DuongDan LIKE N'%" + _pageName + @"') OR  (DuongDanTuyetDoi LIKE N'%" + _pageName + @"');
                    SELECT top 1 Permission FROM dbo.UserPermiss WHERE MenuID in (SELECT top 1 MenuID FROM dbo.Menu WHERE (DuongDan LIKE N'%" + _pageName + @"') OR  (DuongDanTuyetDoi LIKE N'%" + _pageName + @"')) and UserID ='" + NTSSession.GetUser().UserID + "'"
                    , paraValue);
                    NoiDungTieuDe = ds.Tables[0].Rows[0]["NoiDungTieuDe"].ToString();
                    if (ds.Tables[0].Rows.Count != 0)// có đường dẫn trang
                    {
                        if (NTSSession.GetUser().UserGroupCode.ToString().ToLower() == "admin")//là nhóm admin toàn quyền
                        {
                            Permiss.Xem = true;
                            Permiss.Them = true;
                            Permiss.Xoa = true;
                            Permiss.Sua = true;
                            Permiss.Nap = true;
                            Permiss.InAn = true;
                            Permiss.Quyen1 = true;
                            Permiss.Quyen2 = true;
                            Permiss.Quyen3 = true;
                            HttpContext.Current.Session.Add("CurrentPermiss", "false;true;true;true;true;true;true;true;true");
                        }
                        if (NTSSession.GetUser().UserGroupCode.ToString().ToLower() != "")//tạm mở test pm
                        {
                            Permiss.Xem = true;
                            Permiss.Them = true;
                            Permiss.Xoa = true;
                            Permiss.Sua = true;
                            Permiss.Nap = true;
                            Permiss.InAn = true;
                            Permiss.Quyen1 = true;
                            Permiss.Quyen2 = true;
                            Permiss.Quyen3 = true;
                            HttpContext.Current.Session.Add("CurrentPermiss", "false;true;true;true;true;true;true;true;true");
                        }
                        else if (ds.Tables[1].Rows.Count != 0)// có phân quyền
                        {
                            string permiss = "";
                            string _vPermissValue = "";
                            permiss = ds.Tables[1].Rows[0]["Permission"].ToString();
                            string _vPermiss = permiss.ToString();
                            _vPermiss = NTSSecurity._mDecrypt(_vPermiss, "rateAnd2012", true).Split(';')[2];
                            _vPermissValue += NTSSecurity.HasPermission(TypeAudit.View, Convert.ToInt32(_vPermiss)).ToString().ToLower();
                            _vPermissValue += ";" + NTSSecurity.HasPermission(TypeAudit.AddNew, Convert.ToInt32(_vPermiss)).ToString().ToLower();
                            _vPermissValue += ";" + NTSSecurity.HasPermission(TypeAudit.Delete, Convert.ToInt32(_vPermiss)).ToString().ToLower();
                            _vPermissValue += ";" + NTSSecurity.HasPermission(TypeAudit.Edit, Convert.ToInt32(_vPermiss)).ToString().ToLower();
                            _vPermissValue += ";" + NTSSecurity.HasPermission(TypeAudit.LoadData, Convert.ToInt32(_vPermiss)).ToString().ToLower();
                            _vPermissValue += ";" + NTSSecurity.HasPermission(TypeAudit.Print, Convert.ToInt32(_vPermiss)).ToString().ToLower();
                            _vPermissValue += ";" + NTSSecurity.HasPermission(TypeAudit.PlusP1, Convert.ToInt32(_vPermiss)).ToString().ToLower();
                            _vPermissValue += ";" + NTSSecurity.HasPermission(TypeAudit.PlusP2, Convert.ToInt32(_vPermiss)).ToString().ToLower();
                            _vPermissValue += ";" + NTSSecurity.HasPermission(TypeAudit.PlusP3, Convert.ToInt32(_vPermiss)).ToString().ToLower();
                            Permiss.Xem = true;
                            Permiss.Them = (_vPermissValue.Split(';')[1].ToString() == "true");
                            Permiss.Xoa = (_vPermissValue.Split(';')[2].ToString() == "true");
                            Permiss.Sua = (_vPermissValue.Split(';')[3].ToString() == "true");
                            Permiss.Nap = (_vPermissValue.Split(';')[4].ToString() == "true");
                            Permiss.InAn = (_vPermissValue.Split(';')[5].ToString() == "true");
                            Permiss.Quyen1 = (_vPermissValue.Split(';')[6].ToString() == "true");
                            Permiss.Quyen2 = (_vPermissValue.Split(';')[7].ToString() == "true");
                            Permiss.Quyen3 = (_vPermissValue.Split(';')[8].ToString() == "true");
                            HttpContext.Current.Session.Add("CurrentPermiss", _vPermissValue);
                        }
                        else
                        {
                            HttpContext.Current.Response.Redirect("/khongcoquyentruycap.html");
                        }
                    }
                    else//không có đường dẫn trang
                    {
                        HttpContext.Current.Response.Redirect("/404.html");
                    }
                }
            }
            catch (Exception)
            {
                HttpContext.Current.Response.Redirect("/khongcoquyentruycap.html");
            }
        }
        private string pNoiDungTieuDe = string.Empty;
        public string NoiDungTieuDe
        {
            get { return pNoiDungTieuDe; }
            set { pNoiDungTieuDe = value; }
        }
        private ExecPermiss permiss = new ExecPermiss();
        public ExecPermiss Permiss
        {
            get { return permiss; }
            set { permiss = value; }
        }
        public string KhongCoQuyenTruyCap
        {
            get
            {
                return "/khongcoquyentruycap.html";
            }
        }
        public string KhongTimThayTrang
        {
            get
            {
                return "/404.html";
            }
        }
    }

    public class ExecPermiss
    {
        private bool xem = false;
        public bool Xem
        {
            get { return xem; }
            set { xem = value; }
        }
        private bool them = false;
        public bool Them
        {
            get { return them; }
            set { them = value; }
        }
        private bool sua = false;
        public bool Sua
        {
            get { return sua; }
            set { sua = value; }
        }
        private bool xoa = false;
        public bool Xoa
        {
            get { return xoa; }
            set { xoa = value; }
        }
        private bool inan = false;
        public bool InAn
        {
            get { return inan; }
            set { inan = value; }
        }
        private bool nap = false;
        public bool Nap
        {
            get { return nap; }
            set { nap = value; }
        }
        private bool quyen1 = false;
        public bool Quyen1
        {
            get { return quyen1; }
            set { quyen1 = value; }
        }
        private bool quyen2 = false;
        public bool Quyen2
        {
            get { return quyen2; }
            set { quyen2 = value; }
        }
        private bool quyen3 = false;
        public bool Quyen3
        {
            get { return quyen3; }
            set { quyen3 = value; }
        }
        private bool err = false;
        public bool Err
        {
            get { return err; }
            set { err = value; }
        }
        private string errcode = string.Empty;
        public string ErrCode
        {
            get { return errcode; }
            set { errcode = value; }
        }
        private string errCatch = string.Empty;
        public string ErrCatch
        {
            get { return errCatch; }
            set { errCatch = value; }
        }
        private object result;
        public object Result
        {
            get { return result; }
            set { result = value; }
        }
        private string msg = string.Empty;
        public string Msg
        {
            get { return msg; }
            set { msg = value; }
        }
        private string logs = string.Empty;
        public string Logs
        {
            get { return logs; }
            set { logs = value; }
        }
        private bool redirect = false;
        public bool Redirect
        {
            get { return redirect; }
            set { redirect = value; }
        }
        private string redirecturl = "";
        public string RedirectUrl
        {
            get { return redirecturl; }
            set { redirecturl = value; }
        }
    }
    #endregion
    public class NTSSecurity
    {
        public static bool Validate(string cookeiToken, string formToken)
        {
            try
            {
                AntiForgery.Validate(cookeiToken, formToken);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool Validate(HttpContext httpContext)
        {
            try
            {
                string cookeiToken = httpContext.Request.Cookies["__RequestVerificationToken"].Value;
                string formToken = httpContext.Request.Headers["__RequestVerificationToken"].ToString();
                AntiForgery.Validate(cookeiToken, formToken);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool Validate()
        {
            try
            {
                string cookeiToken = HttpContext.Current.Request.Cookies["__RequestVerificationToken"].Value;
                string formToken = HttpContext.Current.Request.Headers["__RequestVerificationToken"].ToString();
                AntiForgery.Validate(cookeiToken, formToken);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        const string TOKENALPHABET = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789-.";
        public static string NewToken(int length = 32)
        {
            var rnd = new RNGCryptoServiceProvider();
            var tokenBytes = new byte[length];
            rnd.GetBytes(tokenBytes);
            var token =
                Enumerable
                    .Range(0, length)
                    .Select(i => TOKENALPHABET[tokenBytes[i] % TOKENALPHABET.Length])
                    .ToArray();

            return new String(token);
        }
        public static bool HasPermission(Guid UserID, Guid MenuID, TypeAudit audit)
        {
            if (!ntsSqlFunctions._IsRegis)
                return false;

            UsersDataContext _vdata = new UsersDataContext();
            UserPermiss user = _vdata.UserPermisses.Where(userP => userP.UserID == UserID && userP.MenuID == MenuID).FirstOrDefault();
            if (user != null)
                return HasPermission(audit, Convert.ToInt32(ntsSecurity._mDecrypt(user.Permission, "rateAnd2012", true).Split(';')[2]));

            return false;
        }

        public static bool HasPermission(TypeAudit audit, int permission)
        {
            if (((int)audit & permission) == (int)audit)
                return true;
            return false;
        }
        public static string _mDecrypt(string toDecrypt, string key, bool useHashing)
        {
            try
            {
                if (toDecrypt == "") { return ""; }
                byte[] keyArray;
                byte[] toEncryptArray = Convert.FromBase64String(toDecrypt);
                if (useHashing)
                {
                    System.Security.Cryptography.MD5CryptoServiceProvider hashmd5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
                    keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                }
                else
                    keyArray = UTF8Encoding.UTF8.GetBytes(key);
                System.Security.Cryptography.TripleDESCryptoServiceProvider tdes = new System.Security.Cryptography.TripleDESCryptoServiceProvider();
                tdes.Key = keyArray;
                tdes.Mode = System.Security.Cryptography.CipherMode.ECB;
                tdes.Padding = System.Security.Cryptography.PaddingMode.PKCS7;
                System.Security.Cryptography.ICryptoTransform cTransform = tdes.CreateDecryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
                return UTF8Encoding.UTF8.GetString(resultArray);
            }
            catch (Exception ex)
            {
                return "Dữ liệu bị mã hoá";
            }
        }
        /// <summary>
        /// Hàm này được gọi trong catch và gọi theo dạng catch (Exception ex){  ntsLibraryFunctions.Insert_MaCodeLoi(ex.HResult.ToString(), ex.Message);} 
        /// </summary>
        /// <param name="MaCodeMCS">ex.HResult.ToString();</param>
        /// <param name="MoTaMCS">ex.Message</param>
        public static string Insert_MaCodeLoi(string MaCodeMCS, string MoTaMCS)
        {
            try
            {
                decimal MaCodeNTS = (decimal)SqlHelper.ExecuteScalar(NTSSession.GetConnectionString2(), CommandType.Text,
               "SELECT 1+ISNULL(MAX(CONVERT(DECIMAL,RIGHT(MaCodeNTS,7))),0) FROM MaCodeLoi WHERE MaCodeNTS LIKE N'NTS%'", null);
                SqlParameter[] paraValue = {
                    new SqlParameter("@MaCodeNTS","NTS"+ MaCodeNTS.ToString("0000000")),
                    new SqlParameter("@MaCodeMCS", MaCodeMCS),
                    new SqlParameter("@MoTaNTS", ""),
                    new SqlParameter("@MoTaMCS", MoTaMCS),
                    new SqlParameter("@GhiChu", "")
            };
                return "<br/>Mã lỗi: " + (string)SqlHelper.ExecuteScalar(NTSSession.GetConnectionString2(), "Insert_MaCodeLoi", paraValue);
            }
            catch
            {
                return "Mã lỗi: -1";
            }
        }
        public static string Insert_MaCodeLoi(Exception ex)
        {

            try
            {
                decimal MaCodeNTS = (decimal)SqlHelper.ExecuteScalar(NTSSession.GetConnectionString2(), CommandType.Text,
               "SELECT 1+ISNULL(MAX(CONVERT(DECIMAL,RIGHT(MaCodeNTS,7))),0) FROM MaCodeLoi WHERE MaCodeNTS LIKE N'NTS%'", null);
                SqlParameter[] paraValue = {
                    new SqlParameter("@MaCodeNTS","NTS"+ MaCodeNTS.ToString("0000000")),
                    new SqlParameter("@MaCodeMCS", ex.HResult.ToString()),
                    new SqlParameter("@MoTaNTS", ""),
                    new SqlParameter("@MoTaMCS", ex.Message),
                    new SqlParameter("@GhiChu", "")
            };
                return "<br/>Mã lỗi: " + (string)SqlHelper.ExecuteScalar(NTSSession.GetConnectionString2(), "Insert_MaCodeLoi", paraValue);
            }
            catch
            {
                return "Mã lỗi: -1";
            }
        }
        /// <summary>
        /// Thao tác không có dấu
        /// </summary>
        /// <param name="tab">Datatable dữ liệu cần ghi</param>
        /// <param name="thaoTac">Them| Sửa | Xóa | Sua</param>
        public static void ghiLogs(DataTable tab, string thaoTac)
        {
            try
            {
                string year = DateTime.Now.Year.ToString();
                string month = DateTime.Now.Month.ToString();
                string day = DateTime.Now.Day.ToString();
                string userID = NTSSession.GetUser().TenDangNhap;
                string maDonVi = NTSSession.GetDonVi().DonViCode;
                string fileName = userID + ".txt";
                string nhanDangDL = maDonVi + "\t" + userID + "\t" + (tab.TableName == "" ? "\t" + HttpContext.Current.Request.RawUrl.ToString() : tab.TableName) + "\t" + DateTime.Now.ToString() + "\t" + thaoTac + "\t";
                string filePath = HttpContext.Current.Server.MapPath("/Logs/" + year + "/" + month + "/" + maDonVi + "/" + fileName);
                FileInfo fi = new FileInfo(filePath);
                if (!fi.Directory.Exists)
                    fi.Directory.Create();
                if (!fi.Exists)
                {
                    using (StreamWriter sw = fi.CreateText())
                    {
                        sw.WriteLine(nhanDangDL + JSonHelper.ToJson(tab));
                        sw.Flush();
                        sw.Close();
                    }
                }
                else
                {
                    using (var sw = new StreamWriter(filePath, true))
                    {
                        sw.WriteLine(nhanDangDL + JSonHelper.ToJson(tab));
                        sw.Flush();
                        sw.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Insert_MaCodeLoi(ex.HResult.ToString(), JSonHelper.ToJson(tab));
            }
        }
    }
}
