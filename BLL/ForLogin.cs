using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NLECloudSDK;

namespace BLL
{
    public class ForLogin
    {
        private static NLECloudAPI SDK = null;

        public static bool UserLogin(AccountLoginDTO dto)
        {
            SDK = new NLECloudAPI(TempInfo.API_HOST);
            var qry = SDK.UserLogin(dto);
            if (qry.IsSuccess())
            {
                TempInfo.Token = qry.ResultObj.AccessToken;
                return true;
            }
            return false;
        }
    }
}
