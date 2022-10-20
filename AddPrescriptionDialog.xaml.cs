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
    /// Interaction logic for AddPrescriptionDialog.xaml
    /// </summary>
    public partial class AddPrescriptionDialog : Window
    {
        public List<Drug> drugList { get; set; }
        Appointment currAppointment;
        public AddPrescriptionDialog(Appointment currAppointment = null)
        {
            this.currAppointment = currAppointment;
            InitializeComponent();
            if (currAppointment != null)
            { // load values to be edited
               int currAppointmentId = currAppointment.id;
               int currPetId = currAppointment.pet_id;

                try
                {
                    var currPet = Globals.dbContext.Pets.FirstOrDefault(u => u.id == currPetId );

                    if (currPet != null)    //Pet was found
                    {

                        PetNameInput.Content = currPet.name;
                        PetIdInput.Content = currPet.id;

                    }
                    else    //Pet was not found
                    {
                        MessageBox.Show(this, "Invalid ", "Input error", MessageBoxButton.OK, MessageBoxImage.Error);
                        this.Close();
                    }
                }
                catch (SystemException ex)
                {
                    MessageBox.Show(this, "Error reading from database\n" + ex.Message, "Fatal error",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                    Environment.Exit(1);
                }

            }
            else
            {

                
            }
            try
            {
                drugList = Globals.dbContext.Drugs.ToList();
                DataContext = drugList;
                
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

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
          
            try
            {
                // Fixme: input validation

                 ComboBoxItem cbi = (ComboBoxItem)QuantityComboBox.SelectedItem;
                String quantitystr = cbi.Content.ToString();
                int quantity = Convert.ToInt32(quantitystr);
                
                if (ComboBoxDrug.SelectedItem != null)
                {
                    string drugIdStr = ComboBoxDrug.SelectedValue.ToString();
                    int drugId = Convert.ToInt32(drugIdStr);
               
               
                int.TryParse(ComboBoxDrug.SelectedValuePath, out int drug_id);
                
                int price = 20;

                
                 Prescription newPrescription = new Prescription(currAppointment.id, drugId, quantity, price);
                Globals.dbContext.Prescriptions.Add(newPrescription);
                Globals.dbContext.SaveChanges(); // SystemException

                //ResetFields();
                this.DialogResult = true;
                }
                else
                {
                    MessageBox.Show(this, "Please select a drug", "Input error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;

                }

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
}
