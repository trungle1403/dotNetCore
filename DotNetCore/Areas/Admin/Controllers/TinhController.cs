using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using DotNetCore.Class;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace DotNetCore.Areas.Admin.Controllers
{
    public class TinhController : Controller
    {
        public IConfiguration Configuration { get; }
        //public TinhController(IConfiguration Config)
        //{
        //    Configuration = Config;
        //}
        public IActionResult Index()
        {
            NTSSession.SetConnectionString2(Configuration.GetConnectionString("ConnectionStringQLCV"));
            return View();
        }
        [HttpPost]
        public string GetAll()
        {
            ExecPermiss ep = new ExecPermiss();
            try
            {
                //if (!NTSSecurity.Validate())
                //{
                //    ep.Msg = "Bạn không có quyền truy cập!";
                //    return JSonHelper.ToJson(ep);
                //}

                DataTable duLieu = SqlHelper.ExecuteDataset(NTSSession.GetConnectionString2(), "Proc_GetAll_Tinh").Tables[0];
                var customerData = duLieu.AsEnumerable();
                //return JSonHelper.ToJson(duLieu);
                ep.Result = duLieu;
                return JSonHelper.ToJson(ep);
            }
            catch (Exception ex)
            {
                //return JSonHelper.ToJson(new DataTable());
                ep.Err = true;
                ep.Logs = ex.Message.ToString();
                ep.Msg = "Có lỗi xãy ra";
                return JSonHelper.ToJson(ep);
            }
        }



        [HttpPost]
        public string kiemTraTonTai(string ma, string tenCot, string tenBang)
        {
            string stSQL = "select ketQua=(case when count(" + tenCot + ") > 0 then 'true' else 'false' end) from " + tenBang + " where " + tenCot + " = " + ma;
            DataTable duLieu = SqlHelper.ExecuteDataset(NTSSession.GetConnectionString2(), CommandType.Text, stSQL).Tables[0];
            return duLieu.Rows[0][0].ToString();
        }

        [HttpPost]
        public string kiemTraTonTaiSua(string ma, string tenCot, string tenBang, string tenCotxet, string maID)
        {
            string stSQL = "select ketQua=(case when count(" + tenCot + ") > 0 then 'true' else 'false' end) from " + tenBang + " where " + tenCot + " = " + ma + " and " + tenCotxet + " not in (select tmp." + tenCotxet + " from " + tenBang + " tmp where tmp." + tenCotxet + " = " + maID + ")";
            DataTable duLieu = SqlHelper.ExecuteDataset(NTSSession.GetConnectionString2(), CommandType.Text, stSQL).Tables[0];
            return duLieu.Rows[0][0].ToString();
        }

        [HttpPost]
        public string LuuThongTin(object[] data)
        {
            string fun = "";
            if (kiemTraTonTai("'" + data[1].ToString() + "'", "TinhCode", "Tinh") == "true" && data[0].ToString() == "them")
            {
                return JSonHelper.ToJson("2_Đã tồn tại mã trong hệ thống");
            }
            if (kiemTraTonTaiSua("'" + data[1].ToString() + "'", "TinhCode", "Tinh", "TinhID", "'" + data[6].ToString() + "'") == "true" && data[0].ToString() == "sua")
            {
                return JSonHelper.ToJson("2_Đã tồn tại mã trong hệ thống");
            }


            try
            {
                SqlParameter[] para = {
                    new SqlParameter("@Loai",data[0].ToString()),
                    new SqlParameter("@TinhCode",data[1].ToString()),
                    new SqlParameter("@TenTinh",  data[2].ToString()),
                    new SqlParameter("@TenVietTat",  data[3].ToString()),
                    new SqlParameter("@DienGiai", data[4].ToString()),
                    new SqlParameter("@NgungSD", DungChung.NormalizationBoolean(data[5].ToString())),
                    new SqlParameter("@TinhID", DungChung.NormalizationGuid(data[6].ToString())),
                };
                DataTable duLieu = SqlHelper.ExecuteDataset(NTSSession.GetConnectionString2(), "Proc_LuuThongTinTinh", para).Tables[0];
                //Returning Json Data
                if (data[0].ToString() == "them")
                {
                    return JSonHelper.ToJson("1_Thêm mới dữ liệu thành công!");
                }
                else
                {
                    return JSonHelper.ToJson("1_Cập nhật dữ liệu thành công!");
                }
            }
            catch (Exception ex)
            {
                return JSonHelper.ToJson("0_Thao tác thất bại!");
            }
        }

        [HttpPost]
        public string LoadDuLieuSua(string ma)
        {
            try
            {
                SqlParameter[] para = {
                    new SqlParameter("@TinhID",DungChung.NormalizationGuid(ma)),
                };
                DataTable duLieu = SqlHelper.ExecuteDataset(NTSSession.GetConnectionString2(), "Proc_GetTinhTheoID", para).Tables[0];
                //Returning Json Data

                return JSonHelper.ToJson(duLieu);
            }
            catch (Exception ex)
            {
                return JSonHelper.ToJson(new DataTable());
            }
        }

        [HttpPost]
        public string Xoa(string ma)
        {
            try
            {
                SqlParameter[] para = {
                    new SqlParameter("@TinhID",DungChung.NormalizationGuid(ma)),
                };
                DataSet duLieu = SqlHelper.ExecuteDataset(NTSSession.GetConnectionString2(), "Delete_Tinh", para);
                //Returning Json Data

                return JSonHelper.ToJson("1_Xóa dữ liệu thành công!");
            }
            catch (Exception ex)
            {
                return JSonHelper.ToJson("0_Xóa dữ liệu không thành công!");
            }
        }

    }
}