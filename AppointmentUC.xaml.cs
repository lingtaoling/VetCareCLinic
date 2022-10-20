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
                DateTime when = DpAppointment.SelectedDate.Value.Date.Add(TpAppointments.SelectedTime.Value.TimeOfDay);

            string vetIdStr = ComboVet.SelectedValue.ToString();
            int vet_id = Convert.ToInt32(vetIdStr);
            string ownerIdStr = ComboOwner.SelectedValue.ToString();
            int owner_id = Convert.ToInt32(ownerIdStr);

            string petIdStr = ComboPet.SelectedValue.ToString();
            int pet_id = Convert.ToInt32(petIdStr);

            string note = TbxNotes.Text;

            Appointment newAppointment = new Appointment(vet_id, owner_id, pet_id, when, note);

            LvAppointment.ItemsSource = Globals.dbContext.Appointments.ToList();
                Globals.dbContext.Appointments.Add(newAppointment);


                Globals.dbContext.SaveChanges();

            }
           

        public bool Vet()
        { User user = new User();
            if (user.role == 1)
            {
                ComboVet.ItemsSource = Globals.dbContext.Users.ToList();
                return true;
            }
            
            return false;
            
        }
        

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ComboOwner.ItemsSource = Globals.dbContext.Owners.ToList();
            ComboVet.ItemsSource = Globals.dbContext.Vets.ToList();
        }

        private void ComboOwner_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //ComboVet.SelectedValue = ComboPet.ItemsSource.ToString();
            
           /* var cbo = sender as ComboBox;
            var selItem = cbo.SelectedItem as Appointment;
            
                    foreach (var item in selItem.owner_id.ToString())
                    {
                        ComboPet.Items.Add(item);
                    }*/
                    ComboPet.ItemsSource = Globals.dbContext.Pets.ToList();
        }
    }

}
