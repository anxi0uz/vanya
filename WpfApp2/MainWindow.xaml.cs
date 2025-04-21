using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
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
using WpfApp2.Controls;
using WpfApp2.Entity;
using WpfApp2.Service;
using WpfApp2.Windows;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml               ,=/
    /// </summary>
    public partial class MainWindow : Window
    {
        private PhoneService service;

        public MainWindow()
        {
            InitializeComponent();
            service = new PhoneService(new Entity.Praktika923MVEntities());
            FillCards();

            var list = service.GetAllGroup();
            groupComboBox.ItemsSource = list;
        }

        private void FillCards()
        {
            var contacts = service.GetAllKontakt();
            RedrawCards(contacts);
        }
        public void RedrawCards(List<Kontakt> list)
        {
            cardsStackPanel.Children.Clear();
            foreach (var item in list)
            {
                var card = new PhoneCard(item,service);
                card.MouseDown += (o, e) =>
                {

                    var wdn = new CardChange(item,true, service);
                    wdn.Closed += wdn_closed;
                    wdn.Show();
                };
                cardsStackPanel.Children.Add(card);
            }
        }

        private void wdn_closed(object sender, EventArgs e)
        {
           FillCards();
        }

        private void addPhoneButton_Click(object sender, RoutedEventArgs e)
        {
            var window = new CardChange(new Kontakt(),true,service);
            window.Closed += Window_Closed;
            window.Show();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            var list = service.GetAllKontakt();
            RedrawCards(list);
        }

        private void filterButton_Click(object sender, RoutedEventArgs e)
        {
            var wnd2 = new Filter(Filter);
            wnd2.ShowDialog();

        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void groupComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var list = service.Filtered(groupComboBox.SelectedIndex + 1);
            RedrawCards(list);
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            groupComboBox.SelectedItem = null;
            cardsStackPanel.Children.Clear();
            FillCards();
        }

        public void Filter(int num)
        {
            var list = service.Filtered(num);
            RedrawCards(list);
        }
    }
}
