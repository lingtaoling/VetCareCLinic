using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
using System.Xml.Linq;

namespace VetClinic
{
    /// <summary>
    /// Interaction logic for AddEditOwner.xaml
    /// </summary>
    public partial class AddEditOwner : Window
    {
        Owner currOwner;
        public AddEditOwner(Owner currOwner = null)
        {
            this.currOwner = currOwner;
            InitializeComponent();
            if(currOwner != null)
            {
                // load values to be edited
                NameInput.Text = currOwner.name;
                EmailInput.Text = currOwner.email;
                PhoneInput.Text = currOwner.phone.ToString();
                AddressInput.Text = currOwner.address.ToString();

                BtnAdd.Content = "Update";
            }
            else
            {

                BtnAdd.Content = "Add";
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
            
            
            try
            {
                 int.TryParse(PhoneInput.Text, out int phone);
                if(currOwner != null)
                // update
                {
                    currOwner.name = NameInput.Text;
                    currOwner.email = EmailInput.Text;
                    currOwner.address= AddressInput.Text;
                    currOwner.phone = phone;
                }
                // add new
                else
                {
                    Owner newOwner = new Owner(NameInput.Text, EmailInput.Text, phone, AddressInput.Text);
                    Globals.dbContext.Owners.Add(newOwner);
                }
               
                Globals.dbContext.SaveChanges(); // SystemException
                //Globals.addEditOwnerDialog.Hide();
                this.DialogResult = true; // dismiss the dialog
              

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

        private bool AreInputsValid()
        {

            string name = NameInput.Text;
            if (name.Length < 2 || name.Length > 30)

            {
                MessageBox.Show(this, "Name must be 2 - 30 characters long", "Input error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            string email = EmailInput.Text;
            if (email.Length > 100 || !Regex.IsMatch(email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"))

            {
                MessageBox.Show(this, "Invalid email", "Input error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }


            string address = AddressInput.Text;
            if (address.Length < 2 || address.Length > 100)

            {
                MessageBox.Show(this, "Address must be 2 - 100 characters long", "Input error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }


            try
            {
                if ((!int.TryParse(PhoneInput.Text, out int phone)) || phone < 1000000000)

                {
                    MessageBox.Show(this, "Phone must be 10 digits", "Input error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }
            catch (SystemException ex)
            {
                Console.WriteLine("Error to parse: " + ex.Message);
                return false;
            }


            return true;

        }

        private void ResetFields()
        {
            NameInput.Text = "";           
            EmailInput.Text = "";
            PhoneInput.Text = "";


        }

    }
}
