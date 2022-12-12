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

namespace EstateAgent
{
    /// <summary>
    /// Логика взаимодействия для CabinetAgent.xaml
    /// </summary>
    public partial class CabinetAgent : Page
    {

        public MainWindow mainWindow;
        public CabinetAgent(MainWindow _mainWindow)
        {
            InitializeComponent();
            mainWindow = _mainWindow;
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
