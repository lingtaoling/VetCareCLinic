using System;
using System.Collections.Generic;
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
    /// Interaction logic for AdminUsers.xaml
    /// </summary>
    public partial class AdminUsers : Window
    {
        public AdminUsers()
        {
            InitializeComponent();
            try
            {
                lvVets.ItemsSource = Globals.dbContext.Users.ToList();
            }
            catch (SystemException ex)
            {
                MessageBox.Show(this, "Error reading from database\n" + ex.Message, "Fatal error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                Environment.Exit(1);
            }

        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Globals.mainWindow.Show();
        }

  

    private void BtnPets_Click(object sender, RoutedEventArgs e)
        {
          
           Globals.petDialog.Owner = this;
            if (Globals.petDialog.ShowDialog() == true)
            {
                
           }
        }

        private void BtnOwners_Click(object sender, RoutedEventArgs e)
        {

            
            //Globals.ownerDialog.Show();
             Globals.ownerDialog.Owner=this;
            if (Globals.ownerDialog.ShowDialog() == true)
            {

            }
        }

        private void BtnVets_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnAppointments_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnPres_Click(object sender, RoutedEventArgs e)
        {
            Globals.prescriptionDialog.Owner = this;
            if (Globals.prescriptionDialog.ShowDialog() == true)
            {
              
             }
        }

        private void BtnMain_Click(object sender, RoutedEventArgs e)
        {
            Globals.adminDialog.Close();
            Globals.mainWindow.Show();
        }

        private void BtnAddVet_Click(object sender, RoutedEventArgs e)
        {
            Globals.addEditVetDialog.Owner = this;
            if (Globals.addEditVetDialog.ShowDialog() == true)
            {
                lvVets.ItemsSource = Globals.dbContext.Users.ToList(); // equivalent of SELECT * FROM people
               
            }
        }
        private void lvVets_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void MenuItem_ListDeleteItemClick(object sender, RoutedEventArgs e)
        {
            // TODO: 
        }

        private void MenuItem_ListEditItemClick(object sender, RoutedEventArgs e)
        {

        }

        private void lvVets_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
