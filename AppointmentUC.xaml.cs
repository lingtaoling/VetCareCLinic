using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        }



        private void BtnAppointment_Click(object sender, RoutedEventArgs e)
        {

            DateTime when = DpAppointment.SelectedDate.Value.Date.Add(TpAppointments.SelectedTime.Value.TimeOfDay);

           
            Appointment newAppointment = new Appointment(ComboName.SelectedItem, ComboPet.SelectedItem, ComboVet.SelectedItem, TbxNotes.Text, when);


            LvAppointment.ItemsSource = Globals.dbContext.Appointments.ToList();
            Globals.dbContext.Appointments.Add(newAppointment);
            Globals.dbContext.SaveChanges();


        }
        

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ComboName.ItemsSource = Globals.dbContext.Owners.ToList();
            ComboVet.ItemsSource = Globals.dbContext.Users.ToList();
        }

        private void ComboName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
                ComboPet.ItemsSource = Globals.dbContext.Pets.ToList();
        }
    }
}
