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
        public static string SerializeToJSON(System.Data.DataSet argDs)
        {
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(argDs);
            return JSONString;
        }

        public static System.Data.DataSet DeserializeFromJSON(string sourceJson)
        {
            System.Data.DataSet dataSet = JsonConvert.DeserializeObject<System.Data.DataSet> (sourceJson);
            return dataSet;
        }

    }
}
