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
using WpfApp2.Entity;
using WpfApp2.Service;

namespace WpfApp2.Controls
{
    /// <summary>
    /// Логика взаимодействия для PhoneCard.xaml
    /// </summary>
    public partial class PhoneCard : UserControl
    {
        private readonly PhoneService service;

        public PhoneCard(Kontakt kontakt, PhoneService service)
        {
            InitializeComponent();
            this.DataContext = kontakt;
            this.service = service;
        }

        private void favoriteCheckBox_Click(object sender, RoutedEventArgs e)
        {
            service.SaveChanges();
        }
    }
}
