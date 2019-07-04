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
using BLL;

namespace SafeBox
{
    /// <summary>
    /// Login.xaml 的交互逻辑
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            AccountLoginDTO dto = new AccountLoginDTO();
            dto.Account = "123";// txtName.Text.Trim();
            dto.Password = "test";// pasPwd.Password;

            bool isLogin = ForLogin.UserLogin(dto);
            if(isLogin)
            {
                new MainWindow().Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("登录失败", "提示");

            }
        }

        private void TxtName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
