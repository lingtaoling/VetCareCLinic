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
    /// Interaction logic for AddEditVet.xaml
    /// </summary>
    public partial class AddEditVet : Window
    {
        User currUser;
        public AddEditVet(User currUser = null)
        {
            this.currUser = currUser;
            InitializeComponent();
            // if (currUser != null)
            // {
            // load values to be edited

            // }
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

        }

       
    }
}