using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
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
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        private readonly Timer timer = new Timer();
        private static int failCount = 0;
        public Authorization()
        {
            InitializeComponent();
            timer.Interval = 10_000;
            timer.Elapsed += (e, s) => failCount = 0;
            FillContent();
        }      

        private void BtnEnter_Click(object sender, RoutedEventArgs e)
        {
            string login = TxbLogin.Text.Trim();
            string pass = PsbPassword.Password.Trim();

                      
            if (login.Length == 0)
            {
                TxbLogin.ToolTip = "Поле введено не корректно!";
                TxbLogin.BorderBrush = Brushes.Red;
                failCount++;
            }
            else if (pass.Length < 6)
            {
                PsbPassword.ToolTip = "Поле введено не корректно!";
                PsbPassword.BorderBrush = Brushes.Red;
                failCount++;
            }
            else
            {
                TxbLogin.ToolTip = "";
                TxbLogin.BorderBrush = Brushes.Transparent;
                PsbPassword.ToolTip = "";
                PsbPassword.BorderBrush = Brushes.Transparent;

                Organizers organizers = null;
                Members members = null;
                Moderators moderators = null;
                Juries juries = null;
                using (InfoSecurityEntities db = new InfoSecurityEntities())
                {
                    organizers = InfoSecurityEntities.GetContext().Organizers.Where(x => x.Id.ToString() == login && x.Password == pass).FirstOrDefault();
                    members = InfoSecurityEntities.GetContext().Members.Where(x => x.Id.ToString() == login && x.Password == pass).FirstOrDefault();
                    moderators = InfoSecurityEntities.GetContext().Moderators.Where(x => x.Id.ToString() == login && x.Password == pass).FirstOrDefault();
                    juries = InfoSecurityEntities.GetContext().Juries.Where(x => x.Id.ToString() == login && x.Password == pass).FirstOrDefault();
                }

                if (TxtCaptcha.Text == TxbCaptcha.Text)
                {
                    if (organizers != null)
                    {
                        MessageBox.Show("Добро пожаловать организатор");                       
                        WindowOranizer windowOranizer = new WindowOranizer(organizers.Id);
                        windowOranizer.Show();
                        Close();
                       
                    }
                    else if (members != null)
                    {
                        MessageBox.Show("Добро пожаловать участник");
                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Show();
                        Hide();
                    }
                    else if (moderators != null)
                    {
                        MessageBox.Show("Добро пожаловать модератор");
                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Show();
                        Hide();
                    }
                    else if (juries != null)
                    {
                        MessageBox.Show("Добро пожаловать жюри" + juries);
                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Show();
                        Hide();
                    }
                    else
                    {
                        MessageBox.Show("Пользователь не авторизован");
                        failCount++;
                        FillContent();
                    }
                                             
                }
                else
                {
                    MessageBox.Show("Captcha не пройдена");                 
                    failCount++;
                    FillContent();
                }


                if (failCount >= 3)
                {
                    timer.Start();
                    MessageBox.Show("Превышен лимит поыток");
                    BtnEnter.IsEnabled = true;
                    BtnEnter.Background = new SolidColorBrush(Colors.Gray);
                }
                

            }
        }

        public void FillContent()
        {            
            Random random = new Random();
            int num = random.Next(4,5);
            string captcha = "";
            int totl = 0;
            do
            {
                int chr = random.Next(48, 123);
                if ((chr >= 48 && chr <= 57) || (chr >= 65 && chr <= 90) || (chr >= 97 && chr <= 122))
                {
                    captcha = captcha + (char)chr;
                    totl++;
                    if (totl == num)
                    {
                        break;
                    }
                }
            }
            while (true);
            TxtCaptcha.Text = captcha;
            TxbCaptcha.Text = "";
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
    }
}
