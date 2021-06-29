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
    /// Interaction logic for Doktor.xaml
    /// </summary>
    public partial class Doktor : Window
    {

        private int editId = -1;
        private IDoktorRepository doktorRepository;

        public BindingList<Baze.Doktor> Doktori;
        public Doktor()
        {
            InitializeComponent();
            doktorRepository = new DoktorRepository();

            UcitajSveDoktore();
        }

        private void UcitajSveDoktore()
        {
            Doktori = new BindingList<Baze.Doktor>(doktorRepository.GetDoktor().ToList());
            DoktoriList.ItemsSource = Doktori;

        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            var dev = ((FrameworkElement)sender).DataContext as Baze.Doktor;

            if (dev != null)
            {

                JmbgTextBox.Text = dev.JmbgZap.ToString();
                ImeTextBox.Text = dev.ImeZap.ToString();
                PrezimeTextBox.Text = dev.PrezZap.ToString();
                PlataTextBox.Text = dev.PlataZap.ToString();
                GodineTextBox.Text = dev.GodineZap.ToString();


                this.editId = (int)dev.JmbgZap;//??
            }
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure that you want to delete this hospital?", "Doktor", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                var dev = ((FrameworkElement)sender).DataContext as Baze.Doktor;
                if (dev != null)
                {
                    doktorRepository.DeleteDoktor(dev);
                    UcitajSveDoktore();
                }
            }
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidiranjeForme())
                return;

            int JmbgZap = Convert.ToInt32(JmbgTextBox.Text);
            string ImeZap = ImeTextBox.Text;
            string PrezZap = PrezimeTextBox.Text;
            string GodineZap = GodineTextBox.Text;
            string PlataZap = PlataTextBox.Text;

            Baze.Doktor doktor;
            if (this.editId == -1)
            {
                doktor = new Baze.Doktor();
                doktor.JmbgZap = JmbgZap;
                doktor.ImeZap = ImeZap;
                doktor.PrezZap = PrezZap;
                doktor.GodineZap = GodineZap;
                doktor.PlataZap = PlataZap;
                doktorRepository.AddDoktor(doktor);
            }
            else
            {
                doktor = doktorRepository.GetDoktorById(this.editId);
                doktor.JmbgZap = JmbgZap;
                doktor.ImeZap = ImeZap;
                doktor.PrezZap = PrezZap;
                doktor.GodineZap = GodineZap;
                doktor.PlataZap = PlataZap;
                doktorRepository.UpdateDoktor(doktor);
            }


            UcitajSveDoktore();
            ClearForm();

        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            ClearForm();
        }

        private bool ValidiranjeForme()
        {
            //int jmbg = 

            string alertText = String.Empty;
            Baze.Doktor doktor = new Baze.Doktor();

            try
            {
                doktor.JmbgZap = Convert.ToInt32(JmbgTextBox.Text);              
            }
            catch (Exception e)
            {
                alertText += "Jmbg mora biti u brojevnom formatu!";
            }

            try
            {
                doktor.PlataZap = PlataTextBox.Text;
            }
            catch (Exception e)
            {
                alertText += "Plata mora biti u brojevnom formatu!";
            }

            try
            {
                doktor.GodineZap = GodineTextBox.Text;
            }
            catch (Exception e)
            {
                alertText += "Godina mora biti u brojevnom formatu!";
            }

            doktor.ImeZap = ImeTextBox.Text;

            if (doktor.ImeZap == String.Empty)
                alertText += "Nije uneto ime zaposlenog! \n";

            doktor.PrezZap = PrezimeTextBox.Text;

            if (doktor.PrezZap == String.Empty)
                alertText += "Nije uneto ime zaposlenog! \n";

            //ubaciti za id hospitalizovanog

            if (alertText != String.Empty)
            {
                System.Windows.MessageBox.Show(alertText, "ERROR", MessageBoxButton.OK);
                return false;
            }

            return true;
        }

        public void ClearForm() 
        {
            JmbgTextBox.Text = String.Empty;
            ImeTextBox.Text = String.Empty;
            PrezimeTextBox.Text = String.Empty;
            GodineTextBox.Text = String.Empty;
            PlataTextBox.Text = String.Empty;
        }

        
    }
}
