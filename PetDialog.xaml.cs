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
    /// Interaction logic for PetDialog.xaml
    /// </summary>
    public partial class PetDialog : Window
    {
        public PetDialog()
        {
            InitializeComponent();
            try
            {
                lvPets.ItemsSource = Globals.dbContext.Pets.ToList();
            }
            catch (SystemException ex)
            {
                MessageBox.Show(this, "Error reading from database\n" + ex.Message, "Fatal error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                Environment.Exit(1);
            }
        }

        private void BtnEditPet_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
        private void lvPets_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
          

        }
        private void MenuItem_ListDeleteItemClick(object sender, RoutedEventArgs e)
        {
            // TODO: 
        }

        private void MenuItem_ListEditItemClick(object sender, RoutedEventArgs e)
        {

        }
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
