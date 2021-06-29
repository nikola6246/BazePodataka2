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
    /// Interaction logic for Direktor.xaml
    /// </summary>
    public partial class Direktor : Window
    {
        private IBolnicaRepository bolnicaRepository;
        private IDirektorRepository direktorRepository;
        private int editId = -1;

        public BindingList<Baze.Direktor> Direktori;
        public BindableCollection<Baze.Bolnica> Bolnice;
        public Direktor()
        {
            InitializeComponent();
            bolnicaRepository = new BolnicaRepository();
            direktorRepository = new DirektorRepository();
            Bolnice = new BindableCollection<Baze.Bolnica>(bolnicaRepository.GetBolnice());
            UcitajSveDirektore();
        }

        public void UcitajSveDirektore() 
        {
            Direktori = new BindingList<Baze.Direktor>(direktorRepository.GetDirektori().ToList());
            DirektoriList.ItemsSource = Direktori;
            IdBolniceCombo.ItemsSource = Bolnice;

        }



        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            var dev = ((FrameworkElement)sender).DataContext as Baze.Direktor;

            if (dev != null)
            {

                ImeTextBox.Text = dev.ImeDir.ToString();
                PrezimeTextBox.Text = dev.PrezDir.ToString();
                //IdBolniceCombo.SelectedItem = dev.BolnicaId.ToString();


                this.editId = (int)dev.JmbgDir;//??
            }
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure that you want to delete this hospital?", "Hospital", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                var dev = ((FrameworkElement)sender).DataContext as Baze.Direktor;
                if (dev != null)
                {
                    direktorRepository.DeleteDirektor(dev);
                    UcitajSveDirektore();
                }
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidiranjeForme())
                return;

            int Jmbg = Convert.ToInt32(JmbgTextBox.Text);
            string ImeDir = ImeTextBox.Text;
            string PrezDir = PrezimeTextBox.Text;
            int BolnicaId = Convert.ToInt32(((Baze.Bolnica)IdBolniceCombo.SelectedItem).BolnicaId);

            Baze.Direktor direktor;
            if (this.editId == -1)
            {
                direktor = new Baze.Direktor();
                direktor.JmbgDir = Jmbg;
                direktor.ImeDir = ImeDir;
                direktor.PrezDir = PrezDir;
                direktor.BolnicaBolnicaId = BolnicaId;
                direktorRepository.AddDirektor(direktor);
            }
            else
            {
                direktor = direktorRepository.GetDirektorById(this.editId);
                direktor.JmbgDir = Jmbg;
                direktor.ImeDir = ImeDir;
                direktor.PrezDir = PrezDir;
                //direktor.BolnicaId = BolnicaId;
                direktorRepository.UpdateDirektor(direktor);
            }


            UcitajSveDirektore();
            ClearForm();
        }

        public void ClearForm() 
        {
            JmbgTextBox.Text = String.Empty;
            ImeTextBox.Text = String.Empty;
            PrezimeTextBox.Text = String.Empty;
            IdBolniceCombo.Text = String.Empty;
        }

        private bool ValidiranjeForme()
        {
            string alertText = String.Empty;
            Baze.Direktor direktor = new Baze.Direktor();

            try
            {
                direktor.JmbgDir = Convert.ToInt32(JmbgTextBox.Text);
            }
            catch (Exception e)
            {
                alertText += "Jmbg mora biti u brojevnom formatu!";
            }

            direktor.ImeDir = ImeTextBox.Text;

            if (direktor.ImeDir == String.Empty)
                alertText += "Nije uneto ime direktora! \n";

            direktor.PrezDir = PrezimeTextBox.Text;

            if (direktor.PrezDir == String.Empty)
                alertText += "Nije uneto prezime direktora! \n";

            if (alertText != String.Empty)
            {
                System.Windows.MessageBox.Show(alertText, "ERROR", MessageBoxButton.OK);
                return false;
            }

            return true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            ClearForm();
        }
    }
}
