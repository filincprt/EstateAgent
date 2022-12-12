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
            mainWindow.OpenPage(MainWindow.pages.SelectPage);
        }

        private void RegBnt_Click(object sender, RoutedEventArgs e)
        {
            const int role = 3;

            if (LogTxtBox.Text.Length > 0) // проверяем логин
            {
                    bool en4 = true;
                    bool number4 = false;

                    for (int i = 0; i < LogTxtBox.Text.Length; i++)
                    {
                        if (LogTxtBox.Text[i] >= 'А' && LogTxtBox.Text[i] <= 'я') en4 = false;
                        if (LogTxtBox.Text[i] == '0' || LogTxtBox.Text[i] == '9') number4 = true;
                    }
                    if (!en4)
                        MessageBox.Show("Доступна только английская раскладка"); // выводим сообщение
                    else if (number4)
                        MessageBox.Show("Цифры запрещены в логине"); // выводим сообщение
                    if (en4 && !number4) // проверяем соответствие
                    {

                        DataTable dt_user1 = mainWindow.Select("SELECT * FROM [dbo].[Client] WHERE [Login] = '" + LogTxtBox.Text + "' AND [Password] = '" + PasstxtBox.Password + "'");
                        if (dt_user1.Rows.Count > 0) // если такая запись существует       
                        {
                            MessageBox.Show("Пользователь уже зарегестрирован"); // говорим, что авторизовался         
                        }
                        else if (PasstxtBox.Password.Length > 0) // проверяем пароль
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
                                    if (PasstxtBox_Check.Password.Length > 0) // проверяем второй пароль
                                    {
                                        if (PasstxtBox.Password == PasstxtBox_Check.Password) // проверка на совпадение паролей
                                        {
                                            if (FirstNameTxtBox.Text.Length > 0)
                                            {
                                                bool number1 = false;
                                                bool sumbol1 = false;

                                                for (int i = 0; i < FirstNameTxtBox.Text.Length; i++)
                                                {
                                                    if (FirstNameTxtBox.Text[i] >= '0' && FirstNameTxtBox.Text[i] <= '9') number1 = true;
                                                    if (FirstNameTxtBox.Text[i] >= '_' && FirstNameTxtBox.Text[i] <= '-') sumbol1 = true;
                                                }
                                                if (number1)
                                                    MessageBox.Show("Числа запрещены в поле Имя");
                                                else if (sumbol1)
                                                    MessageBox.Show("Символы запрещены в поле Имя");
                                                if (!number1 && !sumbol1)
                                                {
                                                    if (MiddleNameTxtBox.Text.Length > 0)
                                                    {
                                                        bool number2 = false;
                                                        bool sumbol2 = false;

                                                        for (int i = 0; i < MiddleNameTxtBox.Text.Length; i++)
                                                        {
                                                            if (MiddleNameTxtBox.Text[i] >= '0' && MiddleNameTxtBox.Text[i] <= '9') number2 = true;
                                                            if (MiddleNameTxtBox.Text[i] >= '_' && MiddleNameTxtBox.Text[i] <= '-') sumbol2 = true;
                                                        }
                                                        if (number2)
                                                            MessageBox.Show("Числа запрещены в поле Имя");
                                                        else if (sumbol2)
                                                            MessageBox.Show("Символы запрещены в поле Имя");
                                                        if (!number2 && !sumbol2)
                                                        {
                                                            if (LastNameTxtBox.Text.Length > 0)
                                                            {
                                                                bool number3 = false;
                                                                bool sumbol3 = false;

                                                                for (int i = 0; i < LastNameTxtBox.Text.Length; i++)
                                                                {
                                                                    if (LastNameTxtBox.Text[i] >= '0' && LastNameTxtBox.Text[i] <= '9') number3 = true;
                                                                    if (LastNameTxtBox.Text[i] >= '_' && LastNameTxtBox.Text[i] <= '-') sumbol3 = true;
                                                                }
                                                                if (number3)
                                                                    MessageBox.Show("Числа запрещены в поле Имя");
                                                                else if (sumbol3)
                                                                    MessageBox.Show("Символы запрещены в поле Имя");
                                                                if (!number3 && !sumbol3)
                                                                {
                                                                    if (EmailTxtBox.Text.Length > 0)
                                                                    {
                                                                        string[] dataLogin = EmailTxtBox.Text.Split('@'); // делим строку на две части
                                                                        if (dataLogin.Length == 2) // проверяем если у нас две части
                                                                        {
                                                                            string[] data2Login = dataLogin[1].Split('.'); // делим вторую часть ещё на две части
                                                                            if (data2Login.Length == 2)
                                                                            {
                                                                                DataTable dt_user = mainWindow.Select($"INSERT INTO [dbo].[Client] VALUES ('{LastNameTxtBox.Text}', '{FirstNameTxtBox.Text}', '{MiddleNameTxtBox.Text}', '{NumTxtBox.Text}', '{EmailTxtBox.Text}', '{LogTxtBox.Text}', '{PasstxtBox.Password}', '{role}')");
                                                                                MessageBox.Show("Пользователь зарегистрирован");
                                                                            }
                                                                            else MessageBox.Show("Укажите email в форме х@x.x");
                                                                        }
                                                                        else MessageBox.Show("Укажите email в форме х@x.x");
                                                                    }
                                                                    else MessageBox.Show("Укажите email");
                                                                }
                                                            }
                                                            else MessageBox.Show("Введите отчество");
                                                        }
                                                    }
                                                    else MessageBox.Show("Введите фамилию");
                                                }
                                            }
                                            else MessageBox.Show("Введите имя");
                                        }
                                        else MessageBox.Show("Пароли не совподают");
                                    }
                                    else MessageBox.Show("Повторите пароль");
                                }

                            }
                            else MessageBox.Show("пароль добжен быть минимум 6 символов");
                        }
                        else MessageBox.Show("Укажиет пароль");
                    }
            }
            else MessageBox.Show("Укажите логин");
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

