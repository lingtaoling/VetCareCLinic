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
using System.Windows.Shapes;

namespace VetClinic
{
    /// <summary>
    /// Interaction logic for PrescriptionDialog.xaml
    /// </summary>
    public partial class PrescriptionDialog : Window
    {
        public PrescriptionDialog()
        {
            InitializeComponent();
        }

        private void BtnAddOwner_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnAddDrug_Click(object sender, RoutedEventArgs e)
        {
            try
            {
               // Fixme: need add drug diaglog, here just simple add drug
              Drug newDrug = new Drug("Medicine", 20,2);
              Globals.dbContext.Drugs.Add(newDrug);
                Globals.dbContext.SaveChanges(); // SystemException
                BtnPrescription.Content = "Success";

            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(this, ex.Message, "Input error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (SystemException ex)
            {
                MessageBox.Show(this, "Error reading from database\n" + ex.Message, "Database error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
        private void MenuItem_ListDeleteItemClick(object sender, RoutedEventArgs e)
        {
            // TODO: 
        }

        private void MenuItem_ListEditItemClick(object sender, RoutedEventArgs e)
        {

        }

        private void BtnPrescription_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnAddAppointment_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Fixme: need add appointment diaglog, here just simple add appointment
                DateTime localDate = DateTime.Now;

                Appointment newAppointment = new Appointment(1,6, 6, localDate, "Need medical care");
                Globals.dbContext.Appointments.Add(newAppointment);
                Globals.dbContext.SaveChanges(); // SystemException
                BtnAppointment.Content = "Success";

            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(this, ex.Message, "Input error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (SystemException ex)
            {
                MessageBox.Show(this, "Error reading from database\n" + ex.Message, "Database error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void lvPrescriptions_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
           //Todo

        }
    }
}
