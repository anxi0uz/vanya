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
using System.Windows.Shapes;
using WpfApp2.Entity;
using WpfApp2.Service;

namespace WpfApp2.Windows
{
    /// <summary>
    /// Логика взаимодействия для GroupAdd.xaml
    /// </summary>
    public partial class GroupAdd : Window
    {
        private PhoneService service = new PhoneService(new Praktika923MVEntities());
        public GroupAdd()
        {
            InitializeComponent();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var group = new Group()
            {
                name = groupTextBox.Text,
            };
            service.AddGroup(group);

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var group = new Group()
            {
                name = groupTextBox.Text,
            };
            service.RemoveGroup(group);
        }
    }
}
