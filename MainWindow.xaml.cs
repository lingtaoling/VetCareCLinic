using MaterialDesignThemes.Wpf;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VetClinic
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void BtnAppoinment_Click(object sender, RoutedEventArgs e)
        {
           

            CC.Content = new AppointmentUC();
        }

        private void BtnAdmin_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MessageBox.Show(this, "Please Login Using Admin Account", "Login First", MessageBoxButton.OK, MessageBoxImage.Error);

            Globals.loginWindow.Show();
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(1);
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
            Environment.Exit(1);
        }


    }
}
