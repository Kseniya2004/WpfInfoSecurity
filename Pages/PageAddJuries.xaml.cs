using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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
    /// Логика взаимодействия для PageAddJuries.xaml
    /// </summary>
    public partial class PageAddJuries : Page
    {

        public PageAddJuries()
        {
            InitializeComponent();
            CmbDirections.ItemsSource = InfoSecurityEntities.GetContext().Directions.ToList();
            CmbDirections.SelectedValuePath = "Id";
            CmbDirections.DisplayMemberPath = "Name";

            CmbEvent.ItemsSource = InfoSecurityEntities.GetContext().Events.ToList();
            CmbEvent.SelectedValuePath = "Id";
            CmbEvent.DisplayMemberPath = "EventName";

            CmbGender.ItemsSource = InfoSecurityEntities.GetContext().Gender.ToList();
            CmbGender.SelectedValuePath = "Id";
            CmbGender.DisplayMemberPath = "Name";

            CmbCountry.ItemsSource = InfoSecurityEntities.GetContext().Country.ToList();
            CmbCountry.SelectedValuePath = "Id";
            CmbCountry.DisplayMemberPath = "Name";
        }      

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            if (CmbDirections.SelectedValue != null && CmbEvent.SelectedValue != null && CmbGender.SelectedValue != null &&
                CmbCountry.SelectedValue != null && TxbFio != null && TxbEmail != null &&
                CmbRole.SelectedValue != null && TxbPhone != null && DpBirthday.SelectedDate != null)
            {
                if (TxbPhone.Text.Length == 11)
                {
                    if (TxbPassword.Password.Length > 0) // проверяем пароль
                    {
                        if (TxbPasswordRepeat.Password.Length > 0) // проверяем второй пароль
                        {
                            if (TxbPassword.Password.Length >= 6)
                            {
                                bool en = true; // английская раскладка
                                bool symbol = false; // символ
                                bool number = false; // цифра

                                for (int i = 0; i < TxbPassword.Password.Length; i++) // перебираем символы
                                {
                                    if (TxbPassword.Password[i] >= 'А' && TxbPassword.Password[i] <= 'Я') en = false; // если русская раскладка
                                    if (TxbPassword.Password[i] >= '0' && TxbPassword.Password[i] <= '9') number = true; // если цифры
                                    if (TxbPassword.Password[i] == '_' || TxbPassword.Password[i] == '-' || TxbPassword.Password[i] == '!') symbol = true; // если символ
                                }

                                if (!en)
                                    MessageBox.Show("Доступна только английская раскладка"); // выводим сообщение
                                else if (!symbol)
                                    MessageBox.Show("Добавьте один из следующих символов: _ - !"); // выводим сообщение
                                else if (!number)
                                    MessageBox.Show("Добавьте хотя бы одну цифру"); // выводим сообщение
                                if (en && symbol && number) // проверяем соответствие
                                {
                                    if (TxbPassword.Password == TxbPasswordRepeat.Password) // проверка на совпадение паролей
                                    {
                                        if (CmbRole.SelectedIndex == 0)
                                        {
                                            try
                                            {
                                                Juries jury = new Juries()
                                                {
                                                    Fio = TxbFio.Text,
                                                    GenderId = CmbGender.SelectedIndex + 1,
                                                    Email = TxbEmail.Text,
                                                    Birthday = DpBirthday.SelectedDate,
                                                    CountryId = CmbCountry.SelectedIndex + 1,
                                                    Phone = TxbPhone.Text,
                                                    DirectionId = CmbDirections.SelectedIndex + 1,
                                                    EventId = CmbEvent.SelectedIndex + 1,
                                                    Password = TxbPassword.Password,
                                                };
                                                InfoSecurityEntities.GetContext().Juries.Add(jury);
                                                InfoSecurityEntities.GetContext().SaveChanges();
                                                MessageBox.Show("Данные успешно добавлены!", "Уведомление",
                                                    MessageBoxButton.OK, MessageBoxImage.Information);
                                                ConnectHelper.frame.GoBack();
                                            }
                                            catch (Exception ex)
                                            {
                                                MessageBox.Show(ex.ToString(), "Произошла ошибка!");
                                            }
                                        }
                                        else
                                        {
                                            try
                                            {
                                                Moderators moderator = new Moderators()
                                                {
                                                    Fio = TxbFio.Text,
                                                    GenderId = CmbGender.SelectedIndex + 1,
                                                    Email = TxbEmail.Text,
                                                    Birthday = DpBirthday.SelectedDate,
                                                    CountryId = CmbCountry.SelectedIndex + 1,
                                                    Phone = TxbPhone.Text,
                                                    DirectionId = CmbDirections.SelectedIndex + 1,
                                                    EventId = CmbEvent.SelectedIndex + 1,
                                                    Password = TxbPassword.Password,
                                                };
                                                InfoSecurityEntities.GetContext().Moderators.Add(moderator);
                                                InfoSecurityEntities.GetContext().SaveChanges();
                                                MessageBox.Show("Данные успешно добавлены!", "Уведомление",
                                                    MessageBoxButton.OK, MessageBoxImage.Information);
                                                ConnectHelper.frame.GoBack();
                                            }
                                            catch (Exception ex)
                                            {
                                                MessageBox.Show(ex.ToString(), "Произошла ошибка!");
                                            }
                                        }

                                    }
                                    else MessageBox.Show("Пароли не совподают!");
                                }
                            }
                            else MessageBox.Show("пароль слишком короткий, минимум 6 символов!");
                        }
                        else MessageBox.Show("Повторите пароль!");
                    }
                    else MessageBox.Show("Укажите пароль!");
                }
                else MessageBox.Show("Номер телефона должен содержать 11 цифр!");
            }
            else MessageBox.Show("Заполните все данные!");

        }


        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            ConnectHelper.frame.GoBack();
        }
    }
}
