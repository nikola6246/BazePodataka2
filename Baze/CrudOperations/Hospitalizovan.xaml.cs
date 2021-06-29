using Baze.Repository.Interfaces;
using Baze.Repository.Repos;
using Caliburn.Micro;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;

namespace Baze.CrudOperations
{
    /// <summary>
    /// Interaction logic for Hospitalizovan.xaml
    /// </summary>
    public partial class Hospitalizovan : Window
    {
        private IHospitalizovan _repository;
        private IPacijent pacijentRepository;
        private ISestraRepository sestraRepository;
        private int editId = -1;

        public BindingList<Baze.Hospitalizovani> Hospitalizovani;
        public BindableCollection<Baze.Pacijent> Pacijenti;
        public BindableCollection<Baze.Sestra> Sestre;

        public Hospitalizovan()
        {
            InitializeComponent();
            _repository = new HospitalizovanRepository();
            pacijentRepository = new PacijentRepository();
            sestraRepository = new SestraRepository();

            Pacijenti = new BindableCollection<Baze.Pacijent>(pacijentRepository.GetPacijenti());
            Sestre = new BindableCollection<Baze.Sestra>(sestraRepository.GetSestre());

            UcitajSveHospitalizovane();
        }

        public void UcitajSveHospitalizovane()
        {

            Hospitalizovani = new BindingList<Baze.Hospitalizovani>(_repository.GetHospitalizovani().ToList());
            HospitalizovaniList.ItemsSource = Hospitalizovani;
            JmbgPacTextBox.ItemsSource = Pacijenti;
            JmbgSestreextBox.ItemsSource = Sestre;

        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure that you want to delete this developer?", "Hospitalizovan", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                var dev = ((FrameworkElement)sender).DataContext as Baze.Hospitalizovani;
                if (dev != null)
                {
                    _repository.DeleteHospitalizovan(dev);
                    UcitajSveHospitalizovane();
                }
            }
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            var dev = ((FrameworkElement)sender).DataContext as Baze.Hospitalizovani;

            if (dev != null)
            {

                DijagnozaTextBox.Text = dev.Dijagnoza.ToString();
                JmbgPacTextBox.SelectedItem = dev.PacijentJmbgPac;
                JmbgSestreextBox.SelectedItem = dev.SestraJmbgZap;

                this.editId = (int)dev.Id;//??
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Baze.Hospitalizovani hospitalizovani;

            if (this.editId == -1)
            {
                hospitalizovani = new Baze.Hospitalizovani();
                hospitalizovani.Dijagnoza = DijagnozaTextBox.Text;
                hospitalizovani.PacijentJmbgPac = Convert.ToInt32(((Baze.Pacijent)JmbgPacTextBox.SelectedItem).JmbgPac);
                hospitalizovani.SestraJmbgZap = Convert.ToInt32(((Baze.Zaposleni)JmbgSestreextBox.SelectedItem).JmbgZap);
                _repository.AddHospitalizovan(hospitalizovani);
            }
            else
            {
                hospitalizovani = _repository.GetHospitalizovanById(this.editId);
                hospitalizovani.Dijagnoza = DijagnozaTextBox.Text;
                hospitalizovani.PacijentJmbgPac = Convert.ToInt32(((Baze.Pacijent)JmbgPacTextBox.SelectedItem).JmbgPac);
                hospitalizovani.SestraJmbgZap = Convert.ToInt32(((Baze.Zaposleni)JmbgSestreextBox.SelectedItem).JmbgZap);
                _repository.UpdateHospitalizovan(hospitalizovani);

            }


            UcitajSveHospitalizovane();
            ClearForm();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            ClearForm();
        }

        public void ClearForm()
        {
            DijagnozaTextBox.Text = String.Empty;
            JmbgPacTextBox.Text = String.Empty;
            JmbgSestreextBox.Text = String.Empty;

        }

        private void ButtonEdit_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonEdit_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonDelete_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
