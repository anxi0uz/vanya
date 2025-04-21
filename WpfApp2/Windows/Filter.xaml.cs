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
using System.Windows.Shapes;
using WpfApp2.Entity;
using WpfApp2.Service;

namespace WpfApp2.Windows
{
    /// <summary>
    /// Логика взаимодействия для Filter.xaml
    /// </summary>
    public partial class Filter : Window
    {
        private readonly Action<int> filtred;
        private PhoneService phoneService = new PhoneService(new Entity.Praktika923MVEntities());
        public Filter(Action<int> filtred)
        {
            InitializeComponent();
            var list = phoneService.GetAllGroup();
            groupComboBox.ItemsSource = list;
            this.filtred = filtred;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            GetFiltered();
            Close();
        }
        public void GetFiltered()
        {
            filtred((groupComboBox.SelectedItem as Group).id);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GetFiltered();
            Close();
        }
    }
}
