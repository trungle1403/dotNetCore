using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore.Class
{
    public class FormattedDecimalConverter
    {
        private CultureInfo culture;

        public FormattedDecimalConverter(CultureInfo culture)
        {
            this.culture = culture;
        }

        public bool CanConvert(Type objectType)
        {
            return (objectType == typeof(decimal) ||
                    objectType == typeof(double) ||
                    objectType == typeof(float));
        }

        public void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(Convert.ToString(value, culture));
        }

        public object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}