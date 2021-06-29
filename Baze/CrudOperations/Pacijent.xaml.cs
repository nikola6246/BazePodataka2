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
    /// Interaction logic for Pacijent.xaml
    /// </summary>
    public partial class Pacijent : Window
    {
        private IPacijent _repository;
        private IGradRepository gradRepository;
        private IBolnicaRepository bolnicaRepository;
        private IDoktorRepository doktorRepository;
        private IZaposleniRepository zaposleniRepository;
        private int editId = -1;

        public BindingList<Baze.Pacijent> Pacijenti;
        public BindableCollection<Baze.Grad> Gradovi;
        public BindableCollection<Baze.Bolnica> Bolnice;
        public BindableCollection<Baze.Doktor> Doktori;
        public BindableCollection<Baze.Zaposleni> Zaposlenovi;
        public Pacijent()
        {
            InitializeComponent();
            _repository = new PacijentRepository();
            gradRepository = new GradRepository();
            bolnicaRepository = new BolnicaRepository();
            zaposleniRepository = new ZaposleniRepository();
            doktorRepository = new DoktorRepository();
           
            Gradovi = new BindableCollection<Baze.Grad>(gradRepository.GetGradovi());
            Bolnice = new BindableCollection<Baze.Bolnica>(bolnicaRepository.GetBolnice());
            //Doktori = new BindableCollection<Baze.Doktor>(doktorRepository.GetDoktor());
            Zaposlenovi = new BindableCollection<Baze.Zaposleni>(zaposleniRepository.GetZaposleni());

            UcitajSvePacijente();
        }


        private void UcitajSvePacijente() 
        {
            Pacijenti = new BindingList<Baze.Pacijent>(_repository.GetPacijenti().ToList());
            PacijentiList.ItemsSource = Pacijenti;
            PostanskiBrCombo.ItemsSource = Gradovi;
            IdBolniceCombo.ItemsSource = Bolnice;
            JmbgDoktoraCombo.ItemsSource = Zaposlenovi;

        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            var dev = ((FrameworkElement)sender).DataContext as Baze.Pacijent;

            if (dev != null)
            {

                JmbgTextBox.Text = dev.JmbgPac.ToString();
                //pacijent.JmbgPac = Convert.ToInt32(JmbgTextBox.Text);
                ImeTextBox.Text = dev.ImePac;
                PrezimeTextBox.Text = dev.PrezPac;
                PostanskiBrCombo.SelectedItem = dev.GradPostanskiBr;
                IdBolniceCombo.SelectedItem = dev.BolnicaBolnicaId;
                //JmbgDoktoraCombo.SelectedItem = dev.Doktor.JmbgZap;
                //JmbgDoktoraCombo.SelectedItem = dev.DoktorId;



                this.editId = (int)dev.JmbgPac;//??
            }
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure that you want to delete this developer?", "Developer", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                var dev = ((FrameworkElement)sender).DataContext as Baze.Pacijent;
                if (dev != null)
                {
                    _repository.DeletePacijent(dev);
                    UcitajSvePacijente();
                }
            }
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {

            Baze.Pacijent pacijent;

            if (this.editId == -1)
            {
                pacijent = new Baze.Pacijent();
                pacijent.JmbgPac = Convert.ToInt32(JmbgTextBox.Text);
                pacijent.ImePac = ImeTextBox.Text;
                pacijent.PrezPac = PrezimeTextBox.Text;

                //pacijent.DoktorId = ((Baze.Zaposleni)JmbgDoktoraCombo.SelectedItem).JmbgZap;
                pacijent.DoktorJmbgZap = ((Baze.Zaposleni)JmbgDoktoraCombo.SelectedItem).JmbgZap;
                //Baze.Doktor doktor = new Baze.Doktor();
                //doktor = doktorRepository.GetDoktorById(pacijent.DoktorId);
                //pacijent.Doktor = doktor;
                //pacijent.Doktor = doktorRepository.GetDoktorById(pacijent.DoktorId);
                //pacijent.Doktor = (Baze.Doktor)zaposleniRepository.GetZaposlenById(pacijent.DoktorId);
                //pacijent.Doktor = new Baze.Doktor();
                pacijent.BolnicaBolnicaId = Convert.ToInt32(((Baze.Bolnica)IdBolniceCombo.SelectedItem).BolnicaId);
                pacijent.GradPostanskiBr = Convert.ToInt32(((Baze.Grad)PostanskiBrCombo.SelectedItem).PostanskiBr);
                _repository.AddPacijent(pacijent);
            }
            else 
            {
                pacijent = _repository.GetPacijentById(this.editId);
                pacijent.JmbgPac = Convert.ToInt32(JmbgTextBox.Text);
                pacijent.ImePac = ImeTextBox.Text;
                pacijent.PrezPac = PrezimeTextBox.Text;
                //pacijent.Doktor.JmbgZap = Convert.ToInt32((JmbgDoktoraCombo.SelectedItem).ToString());
                //pacijent.DoktorId = ((Baze.Zaposleni)JmbgDoktoraCombo.SelectedItem).JmbgZap;
                pacijent.DoktorJmbgZap = ((Baze.Zaposleni)JmbgDoktoraCombo.SelectedItem).JmbgZap;
                pacijent.BolnicaBolnicaId = Convert.ToInt32(((Baze.Bolnica)IdBolniceCombo.SelectedItem).BolnicaId);
                pacijent.GradPostanskiBr = Convert.ToInt32(((Baze.Grad)PostanskiBrCombo.SelectedItem).PostanskiBr);
                _repository.UpdatePacijent(pacijent);

            }


            UcitajSvePacijente();
            ClearForm();

        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            ClearForm();
        }

        private void ClearForm() 
        {
            ImeTextBox.Text = String.Empty;
            PrezimeTextBox.Text = String.Empty;
            JmbgTextBox.Text = String.Empty;
            PostanskiBrCombo.SelectedItem = null;
            IdBolniceCombo.SelectedItem = null;
            JmbgDoktoraCombo.SelectedItem = null;
        }
    }
}
