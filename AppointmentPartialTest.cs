using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetClinic
{
    public partial class Appointment
    {
       
        public Appointment(int vet_id, int owner_id, int pet_id, DateTime when, string note)
        {
            this.vet_id = vet_id;
            this.owner_id = owner_id;
            this.pet_id = pet_id;
            this.when = when;
            this.note = note;
        }

        
        
    }
}
