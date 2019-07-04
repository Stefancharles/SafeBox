using NLECloudSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public static class TempInfo
    {
        public static String API_HOST = ApplicationSettings.Get("ApiHost");


        public static String Token;                        //登录后返回的Token
        
    }
}
