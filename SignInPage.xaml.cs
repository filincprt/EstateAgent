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

            if (FirstNameTxtBox.Text.Length > 0 || LastNameTxtBox.Text.Length > 0 || MiddleNameTxtBox.Text.Length > 0 || LogTxtBox.Text.Length > 0 || PasstxtBox.Password.Length > 0 || PasstxtBox_Check.Password.Length > 0)
            {


                if (FirstNameTxtBox.Text.Length > 0) // проверяем имя
                {
                    bool ru = true; // английская раскладка
                    for (int i = 0; i < FirstNameTxtBox.Text.Length; i++)
                    {
                        if (FirstNameTxtBox.Text[i] >= 'A' && FirstNameTxtBox.Text[i] <= 'Z') ru = false;
                    }
                    if (!ru)
                        MessageBox.Show("Доступна только русская раскладка");

                    string sText = FirstNameTxtBox.Text[0].ToString();
                    if (char.IsUpper(sText[0]))
                    {
                    }
                    else MessageBox.Show("Имя с заглавной буквы");

                    if (FirstNameTxtBox.Text.Length >= 1)
                    {
                    }
                    else MessageBox.Show("Поле слишком короткое");

                    if (LastNameTxtBox.Text.Length > 0) // проверяем фамилию
                    {
                        bool ru1 = true; // английская раскладка
                        for (int i = 0; i < LastNameTxtBox.Text.Length; i++)
                        {
                            if (LastNameTxtBox.Text[i] >= 'A' && LastNameTxtBox.Text[i] <= 'Z') ru1 = false;
                        }
                        if (!ru1)
                            MessageBox.Show("Доступна только русская раскладка");

                        string sText1 = LastNameTxtBox.Text[0].ToString();
                        if (char.IsUpper(sText1[0]))
                        {
                        }
                        else MessageBox.Show("Отчество с заглавной буквы");

                        if (LastNameTxtBox.Text.Length >= 1)
                        {
                        }
                        else MessageBox.Show("Поле слишком короткое");

                        if (MiddleNameTxtBox.Text.Length > 0) // проверяем отчество
                        {
                            bool ru2 = true; // английская раскладка
                            for (int i = 0; i < MiddleNameTxtBox.Text.Length; i++)
                            {
                                if (MiddleNameTxtBox.Text[i] >= 'A' && MiddleNameTxtBox.Text[i] <= 'Z') ru2 = false;
                            }
                            if (!ru2)
                                MessageBox.Show("Доступна только русская раскладка");

                            string sText2 = MiddleNameTxtBox.Text[0].ToString();
                            if (char.IsUpper(sText2[0]))
                            {
                            }
                            else MessageBox.Show("Отчество с заглавной буквы");

                            if (MiddleNameTxtBox.Text.Length >= 1)
                            {
                            }
                            else MessageBox.Show("Поле слишком короткое");

                            if (MiddleNameTxtBox.Text.Length > 0) // проверяем номер
                            {
                                bool ru3 = false;
                                bool en = false;
                                bool symbol = false; // символ
                                for (int i = 0; i < PasstxtBox.Password.Length; i++) // перебираем символы
                                {
                                    if (PasstxtBox.Password[i] >= 'А' && PasstxtBox.Password[i] <= 'Я') ru3 = true; // если русская раскладка
                                    if (PasstxtBox.Password[i] >= 'A' && PasstxtBox.Password[i] <= 'Z') en = true; // если Англ раскладка
                                    if (PasstxtBox.Password[i] == '_' || PasstxtBox.Password[i] == '-' || PasstxtBox.Password[i] == '!') symbol = true; // если символ
                                }

                                if (!en)
                                    MessageBox.Show("Вводить разрешено только цифры"); // выводим сообщение
                                if (!ru3)
                                    MessageBox.Show("Вводить разрешено только цифры"); // выводим сообщение
                                if (en && symbol && ru3) // проверяем соответствие
                                {
                                }

                                if (LogTxtBox.Text.Length > 0) // проверяем логин
                                {
                                    string[] dataLogin = LogTxtBox.Text.Split('@'); // делим строку на две части
                                    if (dataLogin.Length == 2) // проверяем если у нас две части
                                    {
                                        string[] data2Login = dataLogin[1].Split('.'); // делим вторую часть ещё на две части
                                        if (data2Login.Length == 2)
                                        {
                                        }
                                        else MessageBox.Show("Укажите логин в форме х@x.x");
                                    }
                                    else MessageBox.Show("Укажите логин в форме х@x.x");
                                }
                                else MessageBox.Show("Укажите логин");


                                if (PasstxtBox.Password.Length > 0) // проверяем пароль
                                {
                                    if (PasstxtBox.Password.Length >= 8)
                                    {
                                        bool en4 = true; // английская раскладка
                                        bool symbol4 = false; // символ
                                        bool number4 = false; // цифра

                                        for (int i = 0; i < PasstxtBox.Password.Length; i++) // перебираем символы
                                        {
                                            if (PasstxtBox.Password[i] >= 'А' && PasstxtBox.Password[i] <= 'Я') en4 = false; // если русская раскладка
                                            if (PasstxtBox.Password[i] >= '0' && PasstxtBox.Password[i] <= '9') number4 = true; // если цифры
                                            if (PasstxtBox.Password[i] == '_' || PasstxtBox.Password[i] == '-' || PasstxtBox.Password[i] == '!') symbol4 = true; // если символ
                                        }

                                        if (!en4)
                                            MessageBox.Show("Доступна только английская раскладка"); // выводим сообщение
                                        else if (!symbol4)
                                            MessageBox.Show("Добавьте один из следующих символов: _ - !"); // выводим сообщение
                                        else if (!number4)
                                            MessageBox.Show("Добавьте хотя бы одну цифру"); // выводим сообщение
                                        if (en4 && symbol4 && number4) // проверяем соответствие
                                        {
                                        }
                                    }
                                    else MessageBox.Show("пароль слишком короткий, минимум 8 символов");
                                }
                                else MessageBox.Show("Укажите пароль");

                                if (PasstxtBox.Password == PasstxtBox_Check.Password) // проверка на совпадение паролей
                                {
                                    MessageBox.Show("Пользователь зарегистрирован"); 
                                }
                                else MessageBox.Show("Пароли не совподают");
                            }
                            else MessageBox.Show("Введите номер");

                        }
                        else MessageBox.Show("Укажите Отчество");
                    }
                    else MessageBox.Show("Укажите Фамилию");

                }
                else MessageBox.Show("Укажите Имя");

                //--------------------------Начало----------------------------------

                if (LastNameTxtBox.Text.Length > 0) // проверяем фамилию
                {
                    bool ru = true; // английская раскладка
                    for (int i = 0; i < LastNameTxtBox.Text.Length; i++)
                    {
                        if (LastNameTxtBox.Text[i] >= 'A' && LastNameTxtBox.Text[i] <= 'Z') ru = false;
                    }
                    if (!ru)
                        MessageBox.Show("Доступна только русская раскладка");

                    string sText = LastNameTxtBox.Text[0].ToString();
                    if (char.IsUpper(sText[0]))
                    {
                    }
                    else MessageBox.Show("Отчество с заглавной буквы");

                    if (LastNameTxtBox.Text.Length >= 1)
                    {
                    }
                    else MessageBox.Show("Поле слишком короткое");

                }
                else MessageBox.Show("Укажите Фамилию");

                //------------------------------------------------------------

                if (MiddleNameTxtBox.Text.Length > 0) // проверяем отчество
                {
                    bool ru = true; // английская раскладка
                    for (int i = 0; i < MiddleNameTxtBox.Text.Length; i++)
                    {
                        if (MiddleNameTxtBox.Text[i] >= 'A' && MiddleNameTxtBox.Text[i] <= 'Z') ru = false;
                    }
                    if (!ru)
                        MessageBox.Show("Доступна только русская раскладка");

                    string sText = MiddleNameTxtBox.Text[0].ToString();
                    if (char.IsUpper(sText[0]))
                    {
                    }
                    else MessageBox.Show("Отчество с заглавной буквы");

                    if (MiddleNameTxtBox.Text.Length >= 1)
                    {
                    }
                    else MessageBox.Show("Поле слишком короткое");

                }
                else MessageBox.Show("Укажите Отчество");

                //------------------------------------------------------------

                if (MiddleNameTxtBox.Text.Length > 0) // проверяем номер
                {
                    bool ru = false;
                    bool en = false;
                    bool symbol = false; // символ
                    for (int i = 0; i < PasstxtBox.Password.Length; i++) // перебираем символы
                    {
                        if (PasstxtBox.Password[i] >= 'А' && PasstxtBox.Password[i] <= 'Я') ru = true; // если русская раскладка
                        if (PasstxtBox.Password[i] >= 'A' && PasstxtBox.Password[i] <= 'Z') en = true; // если Англ раскладка
                        if (PasstxtBox.Password[i] == '_' || PasstxtBox.Password[i] == '-' || PasstxtBox.Password[i] == '!') symbol = true; // если символ
                    }

                    if (!en)
                        MessageBox.Show("Вводить разрешено только цифры"); // выводим сообщение
                    if (!ru)
                        MessageBox.Show("Вводить разрешено только цифры"); // выводим сообщение
                    if (en && symbol && ru) // проверяем соответствие
                    {
                    }

                }
                else MessageBox.Show("Введите номер");


                //------------------------------------------------------------

                if (LogTxtBox.Text.Length > 0) // проверяем логин
                {
                    string[] dataLogin = LogTxtBox.Text.Split('@'); // делим строку на две части
                    if (dataLogin.Length == 2) // проверяем если у нас две части
                    {
                        string[] data2Login = dataLogin[1].Split('.'); // делим вторую часть ещё на две части
                        if (data2Login.Length == 2)
                        {

                        }
                        else MessageBox.Show("Укажите логин в форме х@x.x");
                    }
                    else MessageBox.Show("Укажите логин в форме х@x.x");
                }
                else MessageBox.Show("Укажите логин");

                //------------------------------------------------------------

                if (PasstxtBox.Password.Length > 0) // проверяем пароль
                {
                    if (PasstxtBox.Password.Length >= 8)
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
                        }
                    }
                    else MessageBox.Show("пароль слишком короткий, минимум 8 символов");
                }
                else MessageBox.Show("Укажите пароль");

                //------------------------------------------------------------


                if (PasstxtBox.Password == PasstxtBox_Check.Password) // проверка на совпадение паролей
                {
                    MessageBox.Show("Пользователь зарегистрирован");
                }
                else MessageBox.Show("Пароли не совподают");

            }
            else MessageBox.Show("Заполните поля"); 
            

                /*
                if (LogTxtBox.Text.Length > 0) // проверяем логин
                {
                    string[] dataLogin = LogTxtBox.Text.Split('@'); // делим строку на две части
                    if (dataLogin.Length == 2) // проверяем если у нас две части
                    {
                        string[] data2Login = dataLogin[1].Split('.'); // делим вторую часть ещё на две части
                        if (data2Login.Length == 2)
                        {

                        }
                        else MessageBox.Show("Укажите логин в форме х@x.x");
                    }
                    else MessageBox.Show("Укажите логин в форме х@x.x");

                    if (PasstxtBox.Password.Length > 0) // проверяем пароль
                    {

                        if (PasstxtBox.Password.Length >= 8)
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
                                 }
                         }
                        else MessageBox.Show("пароль слишком короткий, минимум 6 символов");

                        if (PasstxtBox_Check.Password.Length > 0) // проверяем второй пароль
                        {
                        }
                        else MessageBox.Show("Повторите пароль");

                        if (PasstxtBox.Password == PasstxtBox_Check.Password) // проверка на совпадение паролей
                        {
                            DataTable dt_user = mainWindow.Select("INSERT INTO [dbo].[logins_User] VALUES ('{TBoxLogin.Text}', '{PasswordBox.Password}')");
                        }
                        else MessageBox.Show("Пароли не совподают");

                    }
                    else MessageBox.Show("Укажите пароль");
                          }
                         else MessageBox.Show("Укажите логин"); */
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
