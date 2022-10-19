using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetClinic
{
    public partial class Drug
    {
        public Drug(string name,int price, int quantity)
        {

            this.name = name;
            this.price = price;
            this.quantity = quantity;
            
        }
    }
}
