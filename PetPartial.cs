using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetClinic
{
    public partial class Pet
    {
        public Pet(int owner_id, string name, string type, int gender, DateTime dob)
        {
            this.owner_id = owner_id;
            this.name = name;
            this.name = name;
            this.type = type;
            this.gender = gender;
            this.dob = dob;
        }
    }
}
