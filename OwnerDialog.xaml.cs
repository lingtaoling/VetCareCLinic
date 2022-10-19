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
    /// Interaction logic for OwnerDialog.xaml
    /// </summary>
    public partial class OwnerDialog : Window
    {
        public OwnerDialog()
        {
            InitializeComponent();
            try
            {
                lvOwners.ItemsSource = Globals.dbContext.Owners.ToList();
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
            Globals.addEditOwnerDialog.Owner = this;
            if (Globals.addEditOwnerDialog.ShowDialog() == true)
            {
                lvOwners.ItemsSource = Globals.dbContext.Owners.ToList(); // equivalent of SELECT * FROM people

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
        private void MenuItem_ListAddPetItemClick(object sender, RoutedEventArgs e)
        {

            Owner currSelectedOwner = lvOwners.SelectedItem as Owner;
            if (currSelectedOwner == null) return; // nothing selected
            AddEditPet dialog = new AddEditPet(currSelectedOwner);
            dialog.Owner = this;
            if (dialog.ShowDialog() == true)
            {
                lvOwners.ItemsSource = Globals.dbContext.Owners.ToList(); // equivalent of SELECT * FROM people
                tbStatus.Text = "Pet added";
            }


        }
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void lvOwners_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Owner currSelectedOwner = lvOwners.SelectedItem as Owner;
            if (currSelectedOwner == null) return; // nothing selected
            // we could also instantiate one and reuse it every time

            AddEditOwner dialog = new AddEditOwner(currSelectedOwner);
            dialog.Owner = this;
            // modal = parent is not accessible for input while dialog is shown
            if (dialog.ShowDialog() == true)
            {
                lvOwners.ItemsSource = Globals.dbContext.Owners.ToList(); // equivalent of SELECT * FROM people
                tbStatus.Text = "Owner updated";
            }

        }
    }
}
