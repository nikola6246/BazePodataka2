using Baze.Repository.Interfaces;
using Baze.Repository.Repos;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
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
    /// Interaction logic for Grad.xaml
    /// </summary>
    public partial class Grad : Window
    {
        private IGradRepository _repository;
        private int editId = -1;

        public BindingList<Baze.Grad> Gradovi;
        public Grad()
        {
            InitializeComponent();
            _repository = new GradRepository();
            //Gradovi = new BindableCollection<Baze.Grad>(_repository.GetGradovi());
            UcitajSveGradove();
        }

        private void UcitajSveGradove()
        {
            Gradovi = new BindingList<Baze.Grad>(_repository.GetGradovi().ToList());
            GradoviList.ItemsSource = Gradovi;
            //DeveloperiList.ItemsSource = Developeri;
            //UgovorComboBox.ItemsSource = Ugovori;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            var dev = ((FrameworkElement)sender).DataContext as Baze.Grad;

            if (dev != null)
            {
                PostanskiBrojTextBox.Text = dev.PostanskiBr.ToString();
                NazivGradaTextBox.Text = dev.Naziv;

                this.editId = (int)dev.PostanskiBr;//??
            }
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure that you want to delete this developer?", "Developer", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                var dev = ((FrameworkElement)sender).DataContext as Baze.Grad;
                if (dev != null)
                {
                    _repository.DeleteGrad(dev);
                    UcitajSveGradove();
                }
            }
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            ClearForm();
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {

            if (!ValidiranjeForme())
                return;

            int id = Convert.ToInt32(PostanskiBrojTextBox.Text);
            string naziv = NazivGradaTextBox.Text;

            Baze.Grad grad;
            if (this.editId == -1)
            {
                grad = new Baze.Grad();
                grad.PostanskiBr = id;
                grad.Naziv = naziv;
                _repository.AddGrad(grad);
            }
            else
            {
                grad = _repository.GetGradById(this.editId);
                grad.PostanskiBr = id;
                grad.Naziv = naziv;
                _repository.UpdateGrad(grad);
            }


            UcitajSveGradove();
            ClearForm();
        }

        private void ClearForm()
        {
            PostanskiBrojTextBox.Text = String.Empty;
            NazivGradaTextBox.Text = String.Empty;
        }



        private bool ValidiranjeForme()
        {
            string alertText = String.Empty;
            Baze.Grad grad = new Baze.Grad();

            try
            {
                grad.PostanskiBr = Convert.ToInt32(PostanskiBrojTextBox.Text);
            }
            catch (Exception e)
            {
                alertText += "Postanski broj mora biti u brojevnom formatu!";
            }

            grad.Naziv = NazivGradaTextBox.Text;

            if (grad.Naziv == String.Empty)
                alertText += "Nije unet naziv grada! \n";

            if (alertText != String.Empty)
            {
                System.Windows.MessageBox.Show(alertText, "ERROR", MessageBoxButton.OK);
                return false;
            }

            return true;
        }

        private void BolniceUGradu_Click(object sender, RoutedEventArgs e)
        {
            Baze.Grad g = ((FrameworkElement)sender).DataContext as Baze.Grad;
            if (g != null)
            {

                var conString = ConfigurationManager.ConnectionStrings["Model1Container"].ConnectionString;
                if (conString.ToLower().StartsWith("metadata="))
                {
                    System.Data.Entity.Core.EntityClient.EntityConnectionStringBuilder efBuilder = new System.Data.Entity.Core.EntityClient.EntityConnectionStringBuilder(conString);
                    conString = efBuilder.ProviderConnectionString;
                }

                int ukupnoBolnica = 0;

                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlCommand com = new SqlCommand("BolniceUGradu", con))
                    {
                        com.CommandType = System.Data.CommandType.StoredProcedure;
                        com.Parameters.Add("@pb", System.Data.SqlDbType.Int).Value = g.PostanskiBr;
                        com.Parameters.Add("@UkupnoBolnica", System.Data.SqlDbType.Int);
                        com.Parameters["@UkupnoBolnica"].Direction = System.Data.ParameterDirection.Output;

                        try
                        {
                            con.Open();
                            com.ExecuteNonQuery();

                            ukupnoBolnica = (Int32)com.Parameters["@UkupnoBolnica"].Value;
                            MessageBox.Show(String.Format("Ukupno bolnica: {0} .", ukupnoBolnica), "Uspesno", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        catch
                        {
                            MessageBox.Show("Neka greska se desila", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                        }

                    }
                }
            }
        }

        private void PacijentiUGradu_Click(object sender, RoutedEventArgs e)
        {
            Baze.Grad g = ((FrameworkElement)sender).DataContext as Baze.Grad;
            if (g != null)
            {

                var conString = ConfigurationManager.ConnectionStrings["Model1Container"].ConnectionString;
                if (conString.ToLower().StartsWith("metadata="))
                {
                    System.Data.Entity.Core.EntityClient.EntityConnectionStringBuilder efBuilder = new System.Data.Entity.Core.EntityClient.EntityConnectionStringBuilder(conString);
                    conString = efBuilder.ProviderConnectionString;
                }

                int ukupnoPacijenata = 0;

                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlCommand com = new SqlCommand("PacijentiUGradu", con))
                    {
                        com.CommandType = System.Data.CommandType.StoredProcedure;
                        com.Parameters.Add("@pb", System.Data.SqlDbType.Int).Value = g.PostanskiBr;
                        com.Parameters.Add("@ukupnoPacijenata", System.Data.SqlDbType.Int);
                        com.Parameters["@ukupnoPacijenata"].Direction = System.Data.ParameterDirection.Output;

                        try
                        {
                            con.Open();
                            com.ExecuteNonQuery();

                            ukupnoPacijenata = (Int32)com.Parameters["@ukupnoPacijenata"].Value;
                            MessageBox.Show(String.Format("Ukupno pacijenata: {0} .", ukupnoPacijenata), "Uspesno", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        catch
                        {
                            MessageBox.Show("Neka greska se desila", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                        }

                    }
                }
            }
        }
    }
}
