using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetClinic
{
    public partial class User
    {

        public User(string username, string name, string email, string password, int phone, int role)
        {
            
            this.username = username;
            this.name = name;
            this.email = email;
            this.password = password;
            this.phone = phone;
            this.role = role;
        }



    }

}
