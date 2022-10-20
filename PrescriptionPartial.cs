using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetClinic
{
    public partial class Prescription
    {

        public Prescription()
        {

        }
        public Prescription(int appointment_id, int drug_id, int quantity_sold, int price_sold)
        {

            this.appointment_id = appointment_id;
            this.drug_id = drug_id;
            this.quantity_sold = quantity_sold;
            this.price_sold = price_sold;
        }
    }
}
