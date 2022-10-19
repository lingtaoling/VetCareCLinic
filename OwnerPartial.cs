using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetClinic
{
    public partial class Owner
    {

        public Owner(string name, string email,  int phone, string address)
        {         
            this.name = name;
            this.email = email;   
            this.phone = phone;
            this.address = address;
        }
    }
}
