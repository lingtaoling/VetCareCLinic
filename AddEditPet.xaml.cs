using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for AddEditPet.xaml
    /// </summary>
    public partial class AddEditPet : Window
    {
        Owner currOwner;
        public AddEditPet(Owner currOwner = null)
        {
            this.currOwner = currOwner;
            InitializeComponent();
            if (currOwner != null)
            { // load values to be edited
                OwnerIdInput.Text = currOwner.id.ToString();

            }
            else
            {
                MessageBox.Show(this, "Please select owner", "Input error", MessageBoxButton.OK, MessageBoxImage.Error);
                return ;
            }


        }
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (!AreInputsValid()) return;
            Console.WriteLine(currOwner);
            if(currOwner != null)
            {
                // Fixme: need to change gender to ENUM if having time
                int gender = 0;
                if (RbnFemale.IsChecked == true)
                {
                    gender = 0; // 0 -> female
                }
                if (RbnMale.IsChecked == true)
                {
                    gender = 1; //1 ->male
                }
                // Fixme: add time picker if having time, now just use currentdate to dob
                DateTime localDate = DateTime.Now;
                try
                {
                    // Fixme: add avatar table if having time 
                    Pet newPet = new Pet(currOwner.id, NameInput.Text, TypeInput.Text, gender, localDate);
                    Globals.dbContext.Pets.Add(newPet);
                    Globals.dbContext.SaveChanges(); // SystemException

                    //ResetFields();
                    this.DialogResult = true;

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

            
        }
        private bool AreInputsValid()
        {

            string name = NameInput.Text;
            if (name.Length < 2 || name.Length > 30)

            {
                MessageBox.Show(this, "Name must be 2 - 30 characters long", "Input error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            string type = TypeInput.Text;
            if (type.Length < 2 || type.Length > 30)

            {
                MessageBox.Show(this, "Type must be 2 - 30 characters long", "Input error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }



            if (RbnFemale.IsChecked == false && RbnMale.IsChecked == false)
            {
                MessageBox.Show(this, "Please choose female or male", "Input error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }


            return true;

        }
    }
}
