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
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Configuration;
using NLECloudSDK;
using BLL;
using System.Windows.Threading;
namespace SafeBox
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        DispatcherTimer time ;
        

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            time = new DispatcherTimer();
            time.Interval = TimeSpan.FromMilliseconds(3000);
            time.Tick += time_Tick;
            time.Start();
        }

        void time_Tick(object sender, EventArgs e)
        {
            int i = int.Parse(MainBusiess.getSafeBoxState().Value.ToString());
            if (i == 2)
            {
                imgWarring.Source = new BitmapImage(new Uri("/Resources/Open.png", UriKind.Relative));
                labSafeBoxState.Content = "警报";
            }
            else
            {
                imgWarring.Source = new BitmapImage(new Uri("/Resources/Close.png", UriKind.Relative));
                labSafeBoxState.Content = "安全";
            }
            int j = int.Parse(MainBusiess.getDeployState().Value.ToString());
            if(j == 0)
            {
                labDefenseState.Content = "撤防";
            }
            else
            {
                labDefenseState.Content = "布防";
            }
        }

        private void btnDeploy_Click(object sender, RoutedEventArgs e)
        {
            MainBusiess.onDefense();
        }

        private void btnOpenLock_Click(object sender, RoutedEventArgs e)
        {
            MainBusiess.OpenLock();
        }

        private void btnRevoke_Click(object sender, RoutedEventArgs e)
        {
            MainBusiess.onRevoke();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new HistoryData().Show();
        }
    }
}
