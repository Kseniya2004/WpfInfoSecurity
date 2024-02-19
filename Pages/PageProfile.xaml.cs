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
using WpfInfoSecurity.Windows;

namespace WpfInfoSecurity.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageProfile.xaml
    /// </summary>
    public partial class PageProfile : Page
    {
        int NumberId;
        public PageProfile(int id)
        {
            InitializeComponent();
            NumberId = id;
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}
