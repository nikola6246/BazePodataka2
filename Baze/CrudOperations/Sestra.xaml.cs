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
    /// Interaction logic for Sestra.xaml
    /// </summary>
    public partial class Sestra : Window
    {
        private ISestraRepository sestraRepository;

        private int editId = -1;

        public BindingList<Baze.Sestra> Sestre;
        public Sestra()
        {
            InitializeComponent();
            sestraRepository = new SestraRepository();


            UcitajSveSestre();
        }

        public void UcitajSveSestre()
        {
            Sestre = new BindingList<Baze.Sestra>(sestraRepository.GetSestre().ToList());
            SestreList.ItemsSource = Sestre;
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            var dev = ((FrameworkElement)sender).DataContext as Baze.Sestra;

            if (dev != null)
            {

                JmbgTextBox.Text = dev.JmbgZap.ToString();
                ImeTextBox.Text = dev.ImeZap.ToString();
                PrezimeTextBox.Text = dev.PrezZap.ToString();
                PlataTextBox.Text = dev.PlataZap.ToString();
                GodineTextBox.Text = dev.GodineZap.ToString();
                BrojDezurstavaTextBox.Text = dev.brojDezurstava.ToString();


                this.editId = (int)dev.JmbgZap;//??
            }
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure that you want to delete this hospital?", "Doktor", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                var dev = ((FrameworkElement)sender).DataContext as Baze.Sestra;
                if (dev != null)
                {
                    sestraRepository.DeleteSestra(dev);
                    UcitajSveSestre();
                }
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidiranjeForme())
                return;

            int JmbgZap = Convert.ToInt32(JmbgTextBox.Text);
            string ImeZap = ImeTextBox.Text;
            string PrezZap = PrezimeTextBox.Text;
            string GodineZap = GodineTextBox.Text;
            string PlataZap = PlataTextBox.Text;
            string BrojDezurstava = BrojDezurstavaTextBox.Text;

            Baze.Sestra sestra;
            if (this.editId == -1)
            {
                sestra = new Baze.Sestra();
                sestra.JmbgZap = JmbgZap;
                sestra.ImeZap = ImeZap;
                sestra.PrezZap = PrezZap;
                sestra.GodineZap = GodineZap;
                sestra.PlataZap = PlataZap;
                sestra.brojDezurstava = BrojDezurstava;
                sestraRepository.AddSestra(sestra);
            }
            else
            {
                sestra = sestraRepository.GetSestraById(this.editId);
                sestra.JmbgZap = JmbgZap;
                sestra.ImeZap = ImeZap;
                sestra.PrezZap = PrezZap;
                sestra.GodineZap = GodineZap;
                sestra.PlataZap = PlataZap;
                sestra.brojDezurstava = BrojDezurstava;
                sestraRepository.UpdateSestra(sestra);
            }


            UcitajSveSestre();
            ClearForm();

        }

        public void ClearForm()
        {
            JmbgTextBox.Text = String.Empty;
            ImeTextBox.Text = String.Empty;
            PrezimeTextBox.Text = String.Empty;
            GodineTextBox.Text = String.Empty;
            PlataTextBox.Text = String.Empty;
            BrojDezurstavaTextBox.Text = String.Empty;

        }

        public bool ValidiranjeForme()
        {
            string alertText = String.Empty;
            Baze.Sestra sestra = new Baze.Sestra();

            try
            {
                sestra.JmbgZap = Convert.ToInt32(JmbgTextBox.Text);
            }
            catch (Exception e)
            {
                alertText += "Jmbg mora biti u brojevnom formatu!";
            }

            try
            {
                sestra.PlataZap = PlataTextBox.Text;
            }
            catch (Exception e)
            {
                alertText += "Plata mora biti u brojevnom formatu!";
            }

            try
            {
                sestra.GodineZap = GodineTextBox.Text;
            }
            catch (Exception e)
            {
                alertText += "Godina mora biti u brojevnom formatu!";
            }

            sestra.ImeZap = ImeTextBox.Text;

            if (sestra.ImeZap == String.Empty)
                alertText += "Nije uneto ime zaposlenog! \n";

            sestra.PrezZap = PrezimeTextBox.Text;

            if (sestra.PrezZap == String.Empty)
                alertText += "Nije uneto ime zaposlenog! \n";

            //ubaciti za id hospitalizovanog

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
