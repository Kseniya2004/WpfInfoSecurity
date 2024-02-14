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
using WpfInfoSecurity.Classes;
using WpfInfoSecurity.Pages;

namespace WpfInfoSecurity.Windows
{
    /// <summary>
    /// Логика взаимодействия для WindowOranizer.xaml
    /// </summary>
    public partial class WindowOranizer : Window
    {
        public WindowOranizer(int id)
        {
            InitializeComponent();
            ConnectHelper.frame = frmOrganizer;
            frmOrganizer.Navigate(new PageOrganizer(id));

        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            frmOrganizer.GoBack();
        }

        private void frmOrganizer_ContentRendered(object sender, EventArgs e)
        {
            if (frmOrganizer.CanGoBack)
                BtnBack.Visibility = Visibility.Visible;
            else
                BtnBack.Visibility = Visibility.Hidden;
        }
    }
}
