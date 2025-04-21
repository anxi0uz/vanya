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
using WpfApp1.Kontaks;
using WpfApp1.Models;
using WpfApp1.Servis;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CompanyServis servis;
        public MainWindow()
        {
            InitializeComponent();
            servis = new CompanyServis();
            FillCards();
        }

        public void FillCards() 
        {
            mainStackPanel.Children.Clear();
            var list = servis.GetAllKontakts();
            foreach ( var kontakt in list ) 
            {
                mainStackPanel.Children.Add(new WPF(kontakt));
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            servis.AddUser(new Kontakt()
            {
                Id = 1,
                Name = "Test",
                Phone = "1234567890",
                Favorite = true,
                Groupid = 1,
            });
        }
    }
}
