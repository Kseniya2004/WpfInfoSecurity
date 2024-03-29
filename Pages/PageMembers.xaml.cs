﻿using System;
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
    /// Логика взаимодействия для PageMembers.xaml
    /// </summary>
    public partial class PageMembers : Page
    {
        public PageMembers()
        {
            InitializeComponent();
            DgMembers.ItemsSource = InfoSecurityEntities.GetContext().Members.ToList();
        }

        private void MIList_Click(object sender, RoutedEventArgs e)
        {
            ConnectHelper.frame.Navigate(new PageMembersList());
        }
    }
}
