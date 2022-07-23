using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCore.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public string getViTriCongViec()
        {
            try
            {

                return JSonHelper.ToJson(SqlHelper.ExecuteDataset(NTSSession.GetConnectionString2(), CommandType.Text,
                @"SELECT ViTriViecLamID,
                   TenViTriViecLam
                   FROM dbo.ViTriViecLam WHERE ISNULL(NgungSD,0)=0 order by ViTriViecLamCode asc", null).Tables[0]);
            }
            catch (Exception)
            {
                return JSonHelper.ToJson(null);
            }
        }
    }
}