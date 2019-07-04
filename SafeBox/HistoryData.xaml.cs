using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using NLECloudSDK;
using NLECloudSDK.Model;
using BLL;
namespace SafeBox
{
    /// <summary>
    /// HistoryData.xaml 的交互逻辑
    /// </summary>
    public partial class HistoryData : Window
    {
        public HistoryData()
        {
            InitializeComponent();
            this.Loaded += HistoryData_Loaded;
        }
        NLECloudAPI SDK;

        void HistoryData_Loaded(object sender, RoutedEventArgs e)
        {
            SDK = new NLECloudAPI(TempInfo.API_HOST);

            var query2 = new SensorDataFuzzyQryPagingParas()
            {
                DeviceID = 9969,
                ApiTags = "alarm",

                Method = 2,
                TimeAgo = 30,
                Sort = "DESC",
                PageSize = 1000,
                PageIndex = 1
            };
            var qry = SDK.GetSensorDatas(query2, TempInfo.Token);

            List<SensorDataPointDTO> list = new List<SensorDataPointDTO>();
            foreach (var s in qry.ResultObj.DataPoints)
            {
                list.AddRange(s.PointDTO);
            }
            dgHistory.ItemsSource = list;
        }
    }
}
