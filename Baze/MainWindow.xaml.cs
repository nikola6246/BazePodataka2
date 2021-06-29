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

namespace Baze
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Grad_Click(object sender, RoutedEventArgs e)
        {
            CrudOperations.Grad gradWindow = new CrudOperations.Grad();
            gradWindow.Show();
        }

        private void Pacijent_Click(object sender, RoutedEventArgs e)
        {
            CrudOperations.Pacijent pacijentWindow = new CrudOperations.Pacijent();
            pacijentWindow.Show();
        }

        private void Bolnica_Click(object sender, RoutedEventArgs e)
        {
            CrudOperations.Bolnica bolnicaWindow = new CrudOperations.Bolnica();
            bolnicaWindow.Show();
        }

        private void Direktor_Click(object sender, RoutedEventArgs e)
        {
            CrudOperations.Direktor direktorWindow = new CrudOperations.Direktor();
            direktorWindow.Show();
        }

        private void Spremacica_Click(object sender, RoutedEventArgs e)
        {
            CrudOperations.Spremacica spremacicaWindow = new CrudOperations.Spremacica();
            spremacicaWindow.Show();
        }

        private void Sestra_Click(object sender, RoutedEventArgs e)
        {
            CrudOperations.Sestra sestraWindow = new CrudOperations.Sestra();
            sestraWindow.Show();
        }

        private void Specijalista_Click(object sender, RoutedEventArgs e)
        {
            CrudOperations.Specijalista specijalistaWindow = new CrudOperations.Specijalista();
            specijalistaWindow.Show();
        }

        private void Doktor_Click(object sender, RoutedEventArgs e)
        {
            CrudOperations.Doktor doktorWindow = new CrudOperations.Doktor();
            doktorWindow.Show();
        }

        private void Hospitalizovan_Click(object sender, RoutedEventArgs e)
        {
            CrudOperations.Hospitalizovan hospitalizovanWindow = new CrudOperations.Hospitalizovan();
            hospitalizovanWindow.Show();
        }
    }
}
