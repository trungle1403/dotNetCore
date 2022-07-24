using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using DotNetCore.Class;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

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
                //string connectionString = Configuration.GetConnectionString("ConnectionStringQLCV");
                //string connectionString2 = Configuration.GetConnectionString("MyConn");
                //SqlFunction sqlFun = new SqlFunction(connectionString);
                //SqlFunction sqlFun2 = new SqlFunction(connectionString2);
                //DataTable tab = sqlFun.GetData("SELECT * FROM dbo.tblUsers");
                //DataTable tab2 = SqlHelper.ExecuteDataset(connectionString, CommandType.Text, @"SELECT * FROM dbo.tblUsers", null).Tables[0];
                //return JsonHelper.ToJson(SqlHelper.ExecuteDataset(connectionString, CommandType.Text,
                //@"SELECT * FROM dbo.tblUsers", null).Tables[0]);
                DataTable tab = new DataTable();
                tab.Columns.Add("Name", typeof(String));
                tab.Columns.Add("CustFName", typeof(String));
                for (int i = 0; i < 3; i++)
                {
                    tab.Rows.Add("trung" + i,"value");
                }
                return JsonHelper.ToJson(tab);
            }
            catch (Exception ex)
            {
                return JsonHelper.ToJson(null);
            }
        }
    }
}