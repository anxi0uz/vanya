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
using WpfApp1.Models;

namespace WpfApp1.Kontaks
{
    /// <summary>
    /// Логика взаимодействия для WPF.xaml
    /// </summary>
    public partial class WPF : UserControl
    {
        public WPF(Kontakt contact)
        {
            InitializeComponent();
            idLabel.Content = contact.Id;
            nameLabel.Content = contact.Name;
            phoneLabel.Content = contact.Phone;
            favoriteLabel.Content = contact.Favorite;
            groupidLabel.Content = contact.Groupid;

        }
    }
}
