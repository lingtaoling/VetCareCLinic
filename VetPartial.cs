using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetClinic
{
    public partial class Vet
    {


        public Vet(int user_id, string specialization, DateTime startdate)
        {

            this.user_id = user_id;
            this.specialization = specialization;
            this.startdate = startdate;
        }
    }
}
