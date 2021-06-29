using Baze.Repository.Interfaces;
using Baze.Repository.Repos;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Baze.CrudOperations
{
    /// <summary>
    /// Interaction logic for Bolnica.xaml
    /// </summary>
    public partial class Bolnica : Window
    {
        private IBolnicaRepository _repository;
        private IGradRepository gradRepository;
        private int editId = -1;

        public BindingList<Baze.Bolnica> Bolnice;
        public BindableCollection<Baze.Grad> Gradovi;
        public Bolnica()
        {
            InitializeComponent();
            _repository = new BolnicaRepository();
            gradRepository = new GradRepository();
            Gradovi = new BindableCollection<Baze.Grad>(gradRepository.GetGradovi());
            UcitajSveBolnice();
        }

        public void UcitajSveBolnice() 
        {
            Bolnice = new BindingList<Baze.Bolnica>(_repository.GetBolnice().ToList());
            BolniceList.ItemsSource = Bolnice;
            PostanskiBrComboBox.ItemsSource = Gradovi;
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure that you want to delete this hospital?", "Hospital", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                var dev = ((FrameworkElement)sender).DataContext as Baze.Bolnica;
                if (dev != null)
                {
                    _repository.DeleteBolnica(dev);
                    UcitajSveBolnice();
                }
            }
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            var dev = ((FrameworkElement)sender).DataContext as Baze.Bolnica;

            if (dev != null)
            {

                PostanskiBrComboBox.Text = dev.GradPostanskiBr.ToString();
                NazivTextBox.Text = dev.NazivBolnice;

                this.editId = (int)dev.BolnicaId;//??
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            ClearForm();
        }

        public void ClearForm()
        {
            IdTextBox.Text = String.Empty;
            PostanskiBrComboBox.Text = String.Empty;
            NazivTextBox.Text = String.Empty;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidiranjeForme())
                return;

            int id = Convert.ToInt32(IdTextBox.Text);
            string naziv = NazivTextBox.Text;
            int postanskiBr = Convert.ToInt32(((Baze.Grad)PostanskiBrComboBox.SelectedItem).PostanskiBr);

            Baze.Bolnica bolnica;
            if (this.editId == -1)
            {
                bolnica = new Baze.Bolnica();
                bolnica.BolnicaId = id;
                bolnica.NazivBolnice = naziv;
                bolnica.GradPostanskiBr = postanskiBr;
                _repository.AddBolnica(bolnica);
            }
            else
            {
                bolnica = _repository.GetBolnicaById(this.editId);
                bolnica.BolnicaId = id;
                bolnica.NazivBolnice = naziv;
                bolnica.GradPostanskiBr = postanskiBr;
                _repository.UpdateBolnica(bolnica);
            }


            UcitajSveBolnice();
            ClearForm();
        }

        private bool ValidiranjeForme()
        {
            string alertText = String.Empty;
            Baze.Bolnica bolnica = new Baze.Bolnica();

            try
            {
                bolnica.BolnicaId = Convert.ToInt32(IdTextBox.Text);
            }
            catch (Exception e)
            {
                alertText += "Id mora biti u brojevnom formatu!";
            }

            try
            {
                bolnica.GradPostanskiBr = ((Baze.Grad)PostanskiBrComboBox.SelectedItem).PostanskiBr;
            }
            catch (Exception e)
            {
                alertText += "Id mora biti u brojevnom formatu!";
            }

            bolnica.NazivBolnice = NazivTextBox.Text;

            if (bolnica.NazivBolnice == String.Empty)
                alertText += "Nije unet naziv bolnice! \n";

            if (alertText != String.Empty)
            {
                System.Windows.MessageBox.Show(alertText, "ERROR", MessageBoxButton.OK);
                return false;
            }

            return true;
        }


    }
}
