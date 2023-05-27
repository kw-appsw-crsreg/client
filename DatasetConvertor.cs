using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace _2023AppSWClient
{
    internal class DatasetConvertor
    {
        public static string SerializeToJSON(DataSet argDs)
        {
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(argDs);
            return JSONString;
        }
    }
}
