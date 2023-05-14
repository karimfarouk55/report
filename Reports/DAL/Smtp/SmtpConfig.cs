using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DAL.Smtp
{
    public class SmtpConfig
    {
        public static string GetConnectionString()
        {
            JObject json = JObject.Parse(File.ReadAllText(@"SmtpConfig.json"));
            string value = (string)json["ConnectionString"];
            return value;
        }
    }
}
