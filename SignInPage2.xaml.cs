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
    /// Логика взаимодействия для SignInPage2.xaml
    /// </summary>
    public partial class SignInPage2 : Page
    {
        public MainWindow mainWindow;
        public SignInPage2(MainWindow _mainWindow)
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
            if (LogTxtBox.Text.Length > 0) // проверяем логин
            {
                DataTable dt_loginq = mainWindow.Select("SELECT * FROM [dbo].[Agent] WHERE [Login] = '" + LogTxtBox.Text + "'");
                if (dt_loginq.Rows.Count > 0) // проверяем логин ба базе
                {
                    MessageBox.Show("Риэлтор уже зарегестрирован");
                }
                else if (PasstxtBox.Password.Length > 0) // проверяем пароль
                        {
                            if (PasstxtBox_Check.Password.Length > 0) // проверяем второй пароль
                            {
                                if (LogTxtBox.Text.Length >= 5) // Проверка на длину логина
                                {
                                    bool en2 = true; // английская раскладка
                                    bool symbol2 = false; // символ

                                    for (int b = 0; b < LogTxtBox.Text.Length; b++) // Перебираем символы
                                    {
                                        if (LogTxtBox.Text[b] >= 'А' && LogTxtBox.Text[b] <= 'Я') en2 = false; // если русская раскладка)
                                        if (LogTxtBox.Text[b] == '_' || LogTxtBox.Text[b] == '-' || LogTxtBox.Text[b] == '!') symbol2 = true; // если символ
                                    }
                                    if (!en2)
                                        MessageBox.Show("Доступна только английская раскладка"); // выводим сообщение
                                    else if (symbol2)
                                        MessageBox.Show("Логин не может содержать следующие символы: _ - !"); // выводим сообщение
                                    if (en2 && !symbol2) // проверяем соответствие
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
                                            if (LastNameTxtBox.Text.Length > 0)
                                            {
                                                bool number5 = false;
                                                bool sumbol5 = false;
                                                bool ru1 = true;
                                                for (int i = 0; i < LastNameTxtBox.Text.Length; i++)
                                                {
                                                    if (LastNameTxtBox.Text[i] >= '0' && LastNameTxtBox.Text[i] <= '9') number5 = true; // если цифры
                                                    if (LastNameTxtBox.Text[i] == '_' || LastNameTxtBox.Text[i] == '-' || LastNameTxtBox.Text[i] == '!') sumbol5 = true;
                                                    if (LastNameTxtBox.Text[i] >= 'A' && LastNameTxtBox.Text[i] <= 'Z') ru1 = false;
                                                }
                                                if (!ru1)
                                                    MessageBox.Show("Только кириллица");
                                                else if (number5)
                                                    MessageBox.Show("Цифры запрещены в поле Имя");
                                                else if (sumbol5)
                                                    MessageBox.Show("Символы запрещены в поле Имя");
                                                if (!number5 && !sumbol5 && ru1)
                                                {
                                                    if (FirstNameTxtBox.Text.Length > 0)
                                                    {
                                                        bool number6 = false;
                                                        bool sumbol6 = false;
                                                        bool ru2 = true;
                                                        for (int i = 0; i < FirstNameTxtBox.Text.Length; i++)
                                                        {
                                                            if (FirstNameTxtBox.Text[i] >= '0' && FirstNameTxtBox.Text[i] <= '9') number6 = true; // если цифры
                                                            if (FirstNameTxtBox.Text[i] == '_' || FirstNameTxtBox.Text[i] == '-' || FirstNameTxtBox.Text[i] == '!') sumbol6 = true;
                                                            if (FirstNameTxtBox.Text[i] >= 'A' && FirstNameTxtBox.Text[i] <= 'Z') ru2 = false;
                                                        }
                                                        if (!ru2)
                                                            MessageBox.Show("Только кириллица");
                                                        else if (number6)
                                                            MessageBox.Show("Цифры запрещены в поле Фамилия");
                                                        else if (sumbol6)
                                                            MessageBox.Show("Символы запрещены в поле Фамилия");
                                                        if (!number6 && !sumbol6 && ru2)
                                                        {
                                                            if (MiddleNameTxtBox.Text.Length > 0)
                                                            {
                                                                bool number7 = false;
                                                                bool sumbol7 = false;
                                                                bool ru3 = true;
                                                                for (int i = 0; i < MiddleNameTxtBox.Text.Length; i++)
                                                                {
                                                                    if (MiddleNameTxtBox.Text[i] >= '0' && MiddleNameTxtBox.Text[i] <= '9') number7 = true; // если цифры
                                                                    if (MiddleNameTxtBox.Text[i] == '_' || MiddleNameTxtBox.Text[i] == '-' || MiddleNameTxtBox.Text[i] == '!') sumbol7 = true;
                                                                    if (MiddleNameTxtBox.Text[i] >= 'A' && MiddleNameTxtBox.Text[i] <= 'Z') ru3 = false;
                                                                }
                                                                if (!ru3)
                                                                    MessageBox.Show("Только кириллица");
                                                                else if (number7)
                                                                    MessageBox.Show("Цифры запрещены в поле Отчество");
                                                                else if (sumbol7)
                                                                    MessageBox.Show("Символы запрещены в поле Отчество");
                                                                if (ru3 && !number7 && !sumbol7)
                                                                {
                                                                    Random rnd = new Random();
                                                                    int value = rnd.Next(0, 100);
                                                                    DataTable dt_user = mainWindow.Select($"INSERT INTO [dbo].[Agent] VALUES ('{LastNameTxtBox.Text}', '{FirstNameTxtBox.Text}', '{MiddleNameTxtBox.Text}', '{value}', '{LogTxtBox.Text}', '{PasstxtBox.Password}')");
                                                                    MessageBox.Show("Риэлтор зарегистрирован");
                                                                }

                                                            }
                                                            else MessageBox.Show("Поле Отчество обязательно к заполнению");
                                                        }
                                                    }
                                                    else MessageBox.Show("Поле Фамилия обязательно к заполнению");
                                                }
                                            }
                                            else MessageBox.Show("Поле Имя обязательно к заполнению");
                                        }
                                                else MessageBox.Show("Пароли не совподают");
                                            }
                                        }
                                        else MessageBox.Show("пароль слишком короткий, минимум 6 символов");
                                    }
                                }
                                else MessageBox.Show("Логин должен быть минимум 5 символов");
                            }
                            else MessageBox.Show("Повторите пароль");
                        }
                        else MessageBox.Show("Укажите пароль");
            }
            else MessageBox.Show("Укажите логин");

        }

 
    }
}
