using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore.Class
{
    public class JSonHelper
    {
        public static string ToJson(object obj)
        {
            CultureInfo culture = new CultureInfo("vi-VN");
            var converter = new FormattedDecimalConverter(culture);
            string json = JsonConvert.SerializeObject(obj);
            return json;
        }

        public static object FromJson(string obj)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject(obj);
        }

        public static DataTable ToTable(string obj)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<DataTable>(obj);
        }
    }
}
