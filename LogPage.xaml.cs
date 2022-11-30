using System;
using System.Collections.Generic;
using System.Data;
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

namespace EstateAgent
{
    /// <summary>
    /// Логика взаимодействия для LogPage.xaml
    /// </summary>
    public partial class LogPage : Page
    {
        public MainWindow mainWindow;

        public LogPage(MainWindow _mainWindow)
        {
            InitializeComponent();

            mainWindow = _mainWindow;
        }

        private void EnterBtn_Click(object sender, RoutedEventArgs e)
        {
            if (LogTxtBox.Text.Length > 0)  
            {
                if (PasstxtBox.Password.Length > 0)         
                {                   
                    DataTable dt_user = mainWindow.Select("SELECT * FROM [dbo].[logins_User] WHERE [Login] = '" + LogTxtBox.Text + "' AND [Password] = '" + PasstxtBox.Password + "'");
                    if (dt_user.Rows.Count > 0)      
                    {
                        MessageBox.Show("Пользователь авторизовался");      
                    }
                    else MessageBox.Show("Пользователя не найден"); 
                }
                else MessageBox.Show("Введите пароль");  
            }
            else MessageBox.Show("Введите логин"); 
        }

        private void RegBnt_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenPage(MainWindow.pages.SignInPage);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
