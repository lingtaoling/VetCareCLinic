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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
        private void BtnMain_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            
            Globals.mainWindow.Show();
        }

        private void BtnLogIn_Click(object sender, RoutedEventArgs e)
        {
            string email = EmailInput.Text;
            string password = PasswordInput.Password;
          
            try
            {
                var myUser = Globals.dbContext.Users.FirstOrDefault(u => u.email == email
                         && u.password == password);

                if (myUser != null)    //User was found
                {
                    if (myUser.role == 1) // vet login
                    {
                        Hide();
                        Globals.mainWindow.Show();
                    }
                    if (myUser.role == 0) // admin login
                    {
                        Hide();
                        Globals.adminDialog.Show();
                    }


                }
                else    //User was not found
                {
                    MessageBox.Show(this, "Invalid Login please check email and password", "Input error", MessageBoxButton.OK, MessageBoxImage.Error);
                    EmailInput.Text = "";
                    PasswordInput.Password = "";
                }
            }
            catch (SystemException ex)
            {
                MessageBox.Show(this, "Error reading from database\n" + ex.Message, "Fatal error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                Environment.Exit(1);
            }

        }

        private void BtnSignUp_Click(object sender, RoutedEventArgs e)
        {
            
         Hide();
         Globals.registerWindow.Show();

        }

        private void BtnAdmin_Click(object sender, RoutedEventArgs e)
        {
            Globals.adminDialog.Show();
        }
    }
}
