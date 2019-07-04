using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NLECloudSDK;
using NLECloudSDK.Model;

namespace BLL
{
    public class MainBusiess
    {
        static NLECloudAPI SDK = new NLECloudAPI(TempInfo.API_HOST);
        public static SensorBaseInfoDTO getSafeBoxState()
        {
            var qry = SDK.GetSensorInfo(9969, "alarm", TempInfo.Token);
            return qry.ResultObj;
        }

        public static SensorBaseInfoDTO getDeployState()
        {
            var qry = SDK.GetSensorInfo(9969, "DefenseState", TempInfo.Token);
            return qry.ResultObj;
        }

        public static void onDefense()
        {
            var qry = SDK.Cmds(9969, "defense", 1, TempInfo.Token);
        }

        public static void onRevoke()
        {
            var qry = SDK.Cmds(9969, "defense", 0, TempInfo.Token);
        }

        public static void OpenLock()
        {
            var qry = SDK.Cmds(9969, "ctrl", 1, TempInfo.Token);
        }
    }
}
