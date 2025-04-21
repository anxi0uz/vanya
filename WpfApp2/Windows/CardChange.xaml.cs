using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp2.Controls;
using WpfApp2.Entity;
using WpfApp2.Service;

namespace WpfApp2.Windows
{
    /// <summary>
    /// Логика взаимодействия для CardChange.xaml
    /// </summary>
    public partial class CardChange : Window
    {
        private PhoneService service;
        private bool IsChange;
        private Kontakt Contacts;

        public CardChange(Kontakt contacts, bool isChange, PhoneService service)
        {
            InitializeComponent();
            this.DataContext = contacts;

            var list = service.GetAllGroup();
            groupComboBox.ItemsSource = list;
            IsChange = isChange;
            Contacts = contacts;
            this.service = service;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (IsChange)
                service.SaveChanges();
            else
                service.AddContact(Contacts);
            this.Close();
        }

        private void groupComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var kontakt = new Kontakt()
            {
                name = nameTextBox.Text,
            };
            service.RemoveContact(kontakt);
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var okno = new GroupAdd();
            okno.Show();
        }
    }
}
