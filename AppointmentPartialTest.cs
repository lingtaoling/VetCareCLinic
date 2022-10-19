using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetClinic
{
    public partial class Appointment
    {
        private object selectedItem1;
        private object selectedItem2;
        private object selectedItem3;
        private string text;
        private object text1;

        public Appointment(int vet_id, int owner_id, int pet_id, DateTime when, string note)
        {
            this.vet_id = vet_id;
            this.owner_id = owner_id;
            this.pet_id = pet_id;
            this.when = when;
            this.note = note;
        }

        public Appointment(object selectedItem1, object selectedItem2, object selectedItem3, string text, DateTime when)
        {
            this.selectedItem1 = selectedItem1;
            this.selectedItem2 = selectedItem2;
            this.selectedItem3 = selectedItem3;
            this.text = text;
            this.when = when;
        }

        public Appointment(object selectedItem1, object selectedItem2, object selectedItem3, object text1, DateTime when)
        {
            this.selectedItem1 = selectedItem1;
            this.selectedItem2 = selectedItem2;
            this.selectedItem3 = selectedItem3;
            this.text1 = text1;
            this.when = when;
        }
    }
}
