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
    /// Логика взаимодействия для PageOrganizer.xaml
    /// </summary>
    public partial class PageOrganizer : Page
    {
        public PageOrganizer(int id)
        {
            InitializeComponent();
            Organizers organizers = null;
            organizers = InfoSecurityEntities.GetContext().Organizers.Where(x => x.Id.ToString() == id.ToString()).FirstOrDefault();
            var gender = "";
            var time = "";
            if (organizers.GenderId == 1)
                gender = "Ms";
            else
                gender = "Mrs";

            DateTime currentTime = DateTime.Now;
            TimeSpan timeOfDay = currentTime.TimeOfDay;
            if (timeOfDay.Hours < 11)
                time = "Доброе утро";
            else if (timeOfDay.Hours < 18)
                time = "Добрый день";
            else
                time = "Добрый вечер";

            TxtOrganizer.Text = gender + " " + organizers.Fio.Split(' ')[1];
            TxtGetting.Text = time;
        }

        private void BtnProfile_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Profile");
        }

        private void BtnEvents_Click(object sender, RoutedEventArgs e)
        {
            ConnectHelper.frame.Navigate(new PageEvents());
        }

        private void BtnMembers_Click(object sender, RoutedEventArgs e)
        {
            ConnectHelper.frame.Navigate(new PageMembers());
        }

        private void BtnJuries_Click(object sender, RoutedEventArgs e)
        {
            ConnectHelper.frame.Navigate(new PageJuries());
        }
    }
}
