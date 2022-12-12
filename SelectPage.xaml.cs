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
    /// Логика взаимодействия для SelectPage.xaml
    /// </summary>
    public partial class SelectPage : Page
    {
        public MainWindow mainWindow;

        public SelectPage(MainWindow _mainWindow)
        {
            InitializeComponent();
            mainWindow = _mainWindow;
        }

        private void EnterBtn_Click(object sender, RoutedEventArgs e)
        {
            const int roleClient = 3;
            const int roleAgent = 4;

            if (LogTxtBox.Text.Length > 0)
            {
                if (PasstxtBox.Password.Length > 0) // проверяем введён ли пароль         
                {             // ищем в базе данных пользователя с такими данными         
                    DataTable dt_user = mainWindow.Select("SELECT * FROM [dbo].[Client] WHERE [Login] = '" + LogTxtBox.Text + "' AND [Password] = '" + PasstxtBox.Password + "'" + roleClient + "'");
                    DataTable dt_users = mainWindow.Select("SELECT * FROM [dbo].[Agent] WHERE [Login] = '" + LogTxtBox.Text + "' AND [Password] = '" + PasstxtBox.Password + "'" + roleAgent + "'");

                    if (dt_user.Rows.Count > 0) // если такая запись существует       
                    {
                        MessageBox.Show("Клиент авторизовался");
                        mainWindow.OpenPage(MainWindow.pages.CabinetCl);
                    }
                    else if (dt_users.Rows.Count > 0)
                    {
                        MessageBox.Show("Риелтор авторизовался");
                        mainWindow.OpenPage(MainWindow.pages.CabinetAg);
                    }
                    else MessageBox.Show("Пользователь не найден"); // выводим ошибку


                }
                else MessageBox.Show("Введите пароль"); // выводим ошибку
            }
            else MessageBox.Show("Введите логин"); // выводим ошибку 
        }



        private void RegBntClient_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenPage(MainWindow.pages.SignInPage2);
        }

        private void RegBntAgent_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenPage(MainWindow.pages.SignInPage);
        }
    }
}
