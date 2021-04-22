﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIAutomationBDD.Helper.ResponseData
{
    public class ResponseDataHelper
    {
        public static T DeserializeJsonResponse<T>(string responseData) where T : class
        {
            return JsonConvert.DeserializeObject<T>(responseData);
        }
    }
}
