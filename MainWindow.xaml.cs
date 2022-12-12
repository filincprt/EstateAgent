﻿using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            OpenPage(pages.SelectPage);
        }

        public enum pages
        {
            SelectPage,
            SignInPage,
            SignInPage2
        }

        public void OpenPage(pages pages)
        {
            if (pages == pages.SelectPage)
            {
                FrameAuth.Navigate(new SelectPage(this));
            }
            else if (pages == pages.SignInPage)
                FrameAuth.Navigate(new SignInPage(this));
            if (pages == pages.SignInPage2)
                FrameAuth.Navigate(new SignInPage2(this));
        }


        public DataTable Select(string selectSQL)
        {
            DataTable dataTable = new DataTable("dataBase");               
            
            SqlConnection sqlConnection = new SqlConnection("Data Source=FILINCPRT\\SQLEXPRESS;Initial Catalog=Agent_rielorsDB;Integrated Security=True");
            sqlConnection.Open();                                           // открываем базу данных
            SqlCommand sqlCommand = sqlConnection.CreateCommand();          // создаём команду
            sqlCommand.CommandText = selectSQL;                             // присваиваем команде текст
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand); // создаём обработчик
            sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close();
            return dataTable;
        }
    }
    

}
