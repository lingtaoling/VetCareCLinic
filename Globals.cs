using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using VetDbContext;

namespace VetClinic
{
    internal class Globals
    {
       // public static PetClinicdbConnection dbContext;
        private static PetClinicdbConnection _dbContextInternal;
        public static PetClinicdbConnection dbContext
        {
            get
            {
            if(_dbContextInternal == null)
                {
                    _dbContextInternal = new PetClinicdbConnection(); // Exceptions
                }
                    
                    return _dbContextInternal;
            }
        }

       public static Register registerWindow = new Register();
       public static MainWindow mainWindow = new MainWindow();
       public static Login loginWindow = new Login();
       public static AddEditVet addEditVetDialog = new AddEditVet();
       public static AdminUsers adminDialog = new AdminUsers();
       public static AddEditOwner addEditOwnerDialog = new AddEditOwner();
       public static OwnerDialog ownerDialog = new OwnerDialog();
       public static PetDialog petDialog = new PetDialog();
       public static PrescriptionDialog prescriptionDialog = new PrescriptionDialog();

       





    }
}
