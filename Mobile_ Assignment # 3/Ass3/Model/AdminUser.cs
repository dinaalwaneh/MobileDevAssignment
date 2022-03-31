using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ass3.Model
{
    class AdminUser : User
    {
        public List<StaffUser> staffUser = null;

        public AdminUser(int id, String name, int age) : base(id, name, age)
        {
            this.staffUser = new List<StaffUser>();
        }

        public override string ToString()
        {
           string admin =  base.ToString()+"\n - Staff User :\n";

           string staffUser_ = "";

           for(int i = 0; i < staffUser.Count; i++)
           {
                staffUser_ += staffUser[i].ToString() + "\n";
                
           }

            return admin + staffUser_ ;
             
        }
        public override bool Equals(object value)
        {

            if ((ReferenceEquals(null, value)) || (value.GetType() != this.GetType())) return false;
            if (ReferenceEquals(this, value)) return true;

            AdminUser user = value as AdminUser;

            return (user != null)
                && (id == user.id)
                && (name == user.name)
                && (age == user.age)
                && (staffUser == user.staffUser);

        }
        
         public override int GetHashCode()
        {
            return base.GetHashCode();
        }
 
    }
}
