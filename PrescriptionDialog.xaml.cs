using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.NetworkInformation;
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
            try
            {
                lvAppointments.ItemsSource = Globals.dbContext.Appointments.ToList();
            }
            catch (SystemException ex)
            {
                MessageBox.Show(this, "Error reading from database\n" + ex.Message, "Fatal error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                Environment.Exit(1);
            }
            try
            {
                lvPrescriptions.ItemsSource = Globals.dbContext.Prescriptions.ToList();
            }
            catch (SystemException ex)
            {
                MessageBox.Show(this, "Error reading from database\n" + ex.Message, "Fatal error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                Environment.Exit(1);
            }
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
                BtnDrug.Content = "Success";

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
        private void MenuItem_ListAddPresClick(object sender, RoutedEventArgs e)
        {
            Appointment currSelectedAppointment = lvAppointments.SelectedItem as Appointment;
            if (currSelectedAppointment == null) return; // nothing selected

               //DockerAll.Opacity = 0.3;
               AddPrescriptionDialog dialog = new AddPrescriptionDialog(currSelectedAppointment);
               dialog.Owner = this;
            if (dialog.ShowDialog() == true)
            {
                DockerAll.Opacity = 1;
                lvPrescriptions.ItemsSource = Globals.dbContext.Prescriptions.ToList(); // equivalent of SELECT * FROM people
                Status.Content = "Precription added";
            }
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void MenuItem_ListDeleteItemAppointmentClick(object sender, RoutedEventArgs e)
        {
            // TODO: 

        }

       
        private void MenuItem_ListDeleteItemClick(object sender, RoutedEventArgs e)
        {
            Prescription currSelectedPrescription = lvPrescriptions.SelectedItem as Prescription;
            if (currSelectedPrescription == null) return;
            var result = MessageBox.Show(this, "Are you sure you want to delete this item?", "Confirm deletion", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result != MessageBoxResult.Yes) return;
            try
            {
               Globals.dbContext.Prescriptions.Remove(currSelectedPrescription);
                Globals.dbContext.SaveChanges(); // ex
                lvPrescriptions.ItemsSource = Globals.dbContext.Prescriptions.ToList(); // ex, equivalent of SELECT * FROM People
                
            }
            catch (SystemException ex)
            {
                MessageBox.Show(this, "Error reading from database:\n" + ex.Message, "Database error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void MenuItem_ListEditItemClick(object sender, RoutedEventArgs e)
        {
            //Todo
        }

        private void BtnEditPrescription_Click(object sender, RoutedEventArgs e)
        {
            //Todo
        }

        private void BtnAddAppointment_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Fixme: need add appointment diaglog, here just Hard code to continue coding prescriptions!!!
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

        private void lvAppointments_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //Todo

        }
    }
}
