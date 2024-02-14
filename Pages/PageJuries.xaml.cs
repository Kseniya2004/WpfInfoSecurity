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
using WpfInfoSecurity.Classes;

namespace WpfInfoSecurity.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageJuries.xaml
    /// </summary>
    public partial class PageJuries : Page
    {
        public PageJuries()
        {
            InitializeComponent();
            DgJuries.ItemsSource = InfoSecurityEntities.GetContext().Juries.ToList();
        }
    }
}
