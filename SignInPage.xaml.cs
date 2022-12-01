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
    /// Логика взаимодействия для SignInPage.xaml
    /// </summary>
    public partial class SignInPage : Page
    {
        public MainWindow mainWindow;

        public SignInPage(MainWindow _mainWindow)
        {
            InitializeComponent();
            mainWindow = _mainWindow;
        }

        private void EnterBtn_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenPage(MainWindow.pages.LogPage);
        }

        private void RegBnt_Click(object sender, RoutedEventArgs e)
        {

            if (LogTxtBox.Text.Length > 0) // проверяем логин
            {
                if (PasstxtBox.Password.Length > 0) // проверяем пароль
                {
                    if (PasstxtBox.Password.Length > 0) // проверяем второй пароль
                    {
                        string[] dataLogin = LogTxtBox.Text.Split('@'); // делим строку на две части
                        if (dataLogin.Length == 2) // проверяем если у нас две части
                        {
                            string[] data2Login = dataLogin[1].Split('.'); // делим вторую часть ещё на две части
                            if (data2Login.Length == 2)
                            {
                                if (PasstxtBox.Password.Length >= 6)
                                {
                                    bool en = true; // английская раскладка
                                    bool symbol = false; // символ
                                    bool number = false; // цифра

                                    for (int i = 0; i < PasstxtBox.Password.Length; i++) // перебираем символы
                                    {
                                        if (PasstxtBox.Password[i] >= 'А' && PasstxtBox.Password[i] <= 'Я') en = false; // если русская раскладка
                                        if (PasstxtBox.Password[i] >= '0' && PasstxtBox.Password[i] <= '9') number = true; // если цифры
                                        if (PasstxtBox.Password[i] == '_' || PasstxtBox.Password[i] == '-' || PasstxtBox.Password[i] == '!') symbol = true; // если символ
                                    }

                                    if (!en)
                                        MessageBox.Show("Доступна только английская раскладка"); // выводим сообщение
                                    else if (!symbol)
                                        MessageBox.Show("Добавьте один из следующих символов: _ - !"); // выводим сообщение
                                    else if (!number)
                                        MessageBox.Show("Добавьте хотя бы одну цифру"); // выводим сообщение
                                    if (en && symbol && number) // проверяем соответствие
                                    {
                                        if (PasstxtBox.Password == PasstxtBox_Check.Password) // проверка на совпадение паролей
                                        {
                                            DataTable dt_user = mainWindow.Select($"INSERT INTO [dbo].[Accounts] VALUES ('{LogTxtBox.Text}', '{PasstxtBox.Password}')");
                                            MessageBox.Show("Пользователь зарегистрирован");
                                        }
                                        else MessageBox.Show("Пароли не совподают");
                                    }
                                }
                                else MessageBox.Show("пароль слишком короткий, минимум 6 символов");
                            }
                            else MessageBox.Show("Укажите логин в форме х@x.x");
                        }
                        else MessageBox.Show("Укажите логин в форме х@x.x");
                    }
                    else MessageBox.Show("Повторите пароль");
                }
                else MessageBox.Show("Укажите пароль");
            }
            else MessageBox.Show("Укажите логин");
        }
            private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        
        private void NumTxtBox_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void NumTxtBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }
    }
}
