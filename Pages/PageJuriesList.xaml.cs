using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using WpfInfoSecurity.Classes;

namespace WpfInfoSecurity.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageJuriesList.xaml
    /// </summary>
    public partial class PageJuriesList : Page
    {
        public PageJuriesList()
        {
            InitializeComponent();
            LViewJuries.ItemsSource = InfoSecurityEntities.GetContext().Juries.ToList();

            
            
        }

        private void MIGrid_Click(object sender, RoutedEventArgs e)
        {
            ConnectHelper.frame.Navigate(new PageJuries());
        }
    }
}
