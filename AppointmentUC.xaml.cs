using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations.Model;
using System.Data.Entity.Validation;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VetClinic
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class AppointmentUC : UserControl
    {
        public AppointmentUC()
        {
            InitializeComponent();
            try
            {
                LvAppointment.ItemsSource = Globals.dbContext.Appointments.ToList();
            }
            catch (SystemException ex)
            {
                MessageBox.Show("Error reading from database\n" + ex.Message, "Fatal error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                Environment.Exit(1);
            }
        }


        private void BtnAppointment_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime when = DpAppointment.SelectedDate.Value.Date.Add(TpAppointments.SelectedTime.Value.TimeOfDay);

                string vetIdStr = ComboVet.SelectedValue.ToString();
                int vet_id = Convert.ToInt32(vetIdStr);
                string ownerIdStr = ComboOwner.SelectedValue.ToString();
                int owner_id = Convert.ToInt32(ownerIdStr);

                string petIdStr = ComboPet.SelectedValue.ToString();
                int pet_id = Convert.ToInt32(petIdStr);

                string note = TbxNotes.Text;

                Appointment newAppointment = new Appointment(vet_id, owner_id, pet_id, when, note);
                    Globals.dbContext.Appointments.Add(newAppointment);
                try
                {
                     Globals.dbContext.SaveChanges();
                }
                catch(SystemException ex)
                {
                        MessageBox.Show("Error adding to database\n" + ex.Message, "Database error",
                            MessageBoxButton.OK, MessageBoxImage.Error);
                 }
               
                LvAppointment.ItemsSource = Globals.dbContext.Appointments.ToList();
                ResetFields();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Input error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (SystemException ex)
            {
                MessageBox.Show("Error reading from database\n" + ex.Message, "Database error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
           try
            { 
                ComboOwner.ItemsSource = Globals.dbContext.Owners.ToList();
                ComboVet.ItemsSource = Globals.dbContext.Vets.ToList();
            }
            catch (SystemException ex)
            {
                MessageBox.Show( "Error reading from database for ComboOwner/ComboPet\n" + ex.Message, "Database error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
           
        }

        private void ComboOwner_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try {  //ComboVet.SelectedValue = ComboPet.ItemsSource.ToString();
            
           /* var cbo = sender as ComboBox;
            var selItem = cbo.SelectedItem as Appointment;
            
                    foreach (var item in selItem.owner_id.ToString())
                    {
                        ComboPet.Items.Add(item);
                    }*/
                    ComboPet.ItemsSource = Globals.dbContext.Pets.ToList();
            }
            
            catch (SystemException ex)
            {
                MessageBox.Show("Error reading from database ComboPets\n" + ex.Message, "Database error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void ResetFields()
        {
            ComboVet.SelectedIndex = -1;
            ComboOwner.SelectedIndex = -1;
            ComboPet.SelectedIndex = -1;
            TbxNotes.Text = "";
            DpAppointment.SelectedDate = null;
            TpAppointments.SelectedTime = null;


        }
    }

}
