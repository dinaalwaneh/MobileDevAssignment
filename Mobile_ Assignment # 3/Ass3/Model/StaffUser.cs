using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ass3.Model
{
    public class StaffUser : User
    {

        internal Role role;

   
        public StaffUser(int id, String name, int age, Role role) : base(id, name, age)
        {
            this.role = role;
            
        }

        public override string ToString()
        {
            return base.ToString() + $"\n - Role: {role}";
        }

        public override bool Equals(object value)
        {

            if ((ReferenceEquals(null, value)) || (value.GetType() != this.GetType())) return false;
            if (ReferenceEquals(this, value)) return true;

            StaffUser user = value as StaffUser;

            return (user != null)
                && (id == user.id)
                && (name == user.name)
                && (age == user.age)
                && (role == user.role);

        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    public enum Role
    {
        Role1 ,
        Role2,
        Role3 
    }
 

}
