using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using DotNetCore.Class;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;

namespace DotNetCore.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        public IConfiguration Configuration { get; }
        public HomeController(IConfiguration Config)
        {
            Configuration = Config;
        }
        [Area("Admin")]
        public IActionResult Index()
        {
            ViewBag.Conn = Configuration.GetConnectionString("ConnectionStringQLCV");
            return View();
        }

        [HttpPost]
        public string getAllUser()
        {
            try
            {
                HttpContext.Session.SetString("hongbeoi", "deo");
                var abc = HttpContext.Session.GetString("hongbeoi");
                string connectionString = Configuration.GetConnectionString("ConnectionStringQLCV");
                string connectionString2 = Configuration.GetConnectionString("MyConn");
                SqlFunction sqlFun = new SqlFunction(connectionString);
                SqlFunction sqlFun2 = new SqlFunction(connectionString2);
                var tab = sqlFun2.GetOneStringField("SELECT TenDonVi FROM DonVi");
                DataTable tab2 = SqlHelper.ExecuteDataset(connectionString2, CommandType.Text, @"SELECT * FROM dbo.NhanVien", null).Tables[0];
                var data = JSonHelper.ToJson(SqlHelper.ExecuteDataset(connectionString2, CommandType.Text,
                @"SELECT * FROM dbo.NhanVien", null).Tables[0]);
                return data;
            }
            catch (Exception ex)
            {
                return JSonHelper.ToJson(null);
            }
        }
    }
}