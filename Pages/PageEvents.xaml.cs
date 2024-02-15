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
    /// Логика взаимодействия для PageEvents.xaml
    /// </summary>
    public partial class PageEvents : Page
    {
        public PageEvents()
        {
            InitializeComponent();
            //привязка таблицы            
            DgEvents.ItemsSource = InfoSecurityEntities.GetContext().Events.ToList();

            var allDirections = InfoSecurityEntities.GetContext().Directions.ToList();
            allDirections.Insert(0, new Directions
            {
                Name = "Все проекты"
            });
            CmbDirections.ItemsSource = allDirections;
            CmbDirections.SelectedIndex = 0;
            CmbDirections.DisplayMemberPath = "Name";   
        }

        private void CmbDirections_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int id = CmbDirections.SelectedIndex;
            if (CmbDirections.SelectedIndex == 0)
                DgEvents.ItemsSource = InfoSecurityEntities.GetContext().Events.ToList();
            else
                DgEvents.ItemsSource = InfoSecurityEntities.GetContext().Events.Where(x => x.DirectionId == id).ToList();

        }
    }
}
