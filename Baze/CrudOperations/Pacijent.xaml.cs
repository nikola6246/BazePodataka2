using Baze.Repository.Interfaces;
using Baze.Repository.Repos;
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
        private int editId = -1;

        public BindingList<Baze.Pacijent> Pacijenti;
        public Pacijent()
        {
            _repository = new PacijentRepository();
            InitializeComponent();

            UcitajSvePacijente();
        }


        private void UcitajSvePacijente() 
        {
            Pacijenti = new BindingList<Baze.Pacijent>(_repository.GetPacijenti().ToList());
            PacijentiList.ItemsSource = Pacijenti;

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
                JmbgDoktoraCombo.SelectedItem = dev.Doktor.JmbgZap;



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
                //pacijent.Doktor. = ((Ugovor)UgovorComboBox.SelectedItem).UID;
                pacijent.Doktor.JmbgZap = ((Baze.Doktor)JmbgDoktoraCombo.SelectedItem).JmbgZap;
                pacijent.BolnicaBolnicaId = Convert.ToInt32((IdBolniceCombo.SelectedItem).ToString());
                pacijent.GradPostanskiBr = Convert.ToInt32((PostanskiBrCombo.SelectedItem).ToString());
                _repository.AddPacijent(pacijent);
            }
            else 
            {
                pacijent = _repository.GetPacijentById(this.editId);
                pacijent.JmbgPac = Convert.ToInt32(JmbgTextBox.Text);
                pacijent.ImePac = ImeTextBox.Text;
                pacijent.PrezPac = PrezimeTextBox.Text;
                //pacijent.Doktor. = ((Ugovor)UgovorComboBox.SelectedItem).UID;
                pacijent.Doktor.JmbgZap = ((Baze.Doktor)JmbgDoktoraCombo.SelectedItem).JmbgZap;
                pacijent.BolnicaBolnicaId = Convert.ToInt32((IdBolniceCombo.SelectedItem).ToString());
                pacijent.GradPostanskiBr = Convert.ToInt32((PostanskiBrCombo.SelectedItem).ToString());
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
            //UgovorComboBox.SelectedItem = null;
            PostanskiBrCombo.SelectedItem = null;
            IdBolniceCombo.SelectedItem = null;
            JmbgDoktoraCombo.SelectedItem = null;
        }
    }
}
