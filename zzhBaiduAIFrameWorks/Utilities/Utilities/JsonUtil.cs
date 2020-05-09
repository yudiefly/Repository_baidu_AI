using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Utilities
{
    public class JsonUtil
    {
        #region
        
        public static T Deserialize<T>(string json)
        {
            T m = JsonConvert.DeserializeObject<T>(json);
            return m;
        }
        public static string Serialize<T>(T model)
        {
            return JsonConvert.SerializeObject(model);
        }

        public static string SerializeObject(object o)
        {
            return JsonConvert.SerializeObject(o);
        }
       
        #endregion
    }
}
