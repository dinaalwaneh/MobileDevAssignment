using com.sun.org.apache.bcel.@internal.generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ass3.Model
{
    public class User
    {
        public int id { set; get; }
        public String name { set; get; }
        public int age { set; get; }

       
        public User(int id , String name , int age)
        {
            this.id = id;
            this.name = name;
            this.age = age;
        }

        public override string ToString()
        {
            return $" - Id: {this.id}\n - Name: {this.name}\n - Age: {this.age}";
        }

        public override bool Equals(object value)
        {

            if ((ReferenceEquals(null, value)) || (value.GetType() != this.GetType())) return false;
            if (ReferenceEquals(this, value)) return true;

            User user = value as User;

            return (user != null)
                && (id == user.id)
                && (name == user.name)
                && (age == user.age);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
