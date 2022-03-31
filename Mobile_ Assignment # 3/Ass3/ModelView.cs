using Ass3.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ass3
{
    class ModelView
    {

        public ObservableCollection<User> users = null;
        public ObservableCollection<StaffUser> staffUsers = null;
        public ObservableCollection<AdminUser> adminUsers = null;
        public delegate void OnReciveEvent(object sender, EventArgs args);
        public OnReciveEvent onReciveEvent;
        public ModelView()
        {
            users = new ObservableCollection<User>();
            staffUsers = new ObservableCollection<StaffUser>();
            adminUsers = new ObservableCollection<AdminUser>();
        }
         

        public string AddUser<T>(int userType,T user)
        { 

            if (userType == 1)
            {
                 
                users.Add(user as User);

            }else if (userType == 2)
            {
              
                staffUsers.Add(user as StaffUser);

            }else if(userType == 3)
            {
                adminUsers.Add(user as AdminUser);
            }

            if (onReciveEvent != null)
            {
                onReciveEvent(this,EventArgs.Empty);
            }

            return "User has add successfully : ";
        }


        public string EditUser<T>(int userType, T user, int userIndex)
        {

            if (userType == 1)
            {

                User user_ = user as User;
                
                if (String.IsNullOrEmpty(user_.name))
                {
                    users[userIndex].name = users[userIndex].name;
                } else
                {
                    users[userIndex].name = user_.name;
                }

                if (user_.age ==0)
                {
                    users[userIndex].age = users[userIndex].age;
                }else
                {
                    users[userIndex].age = user_.age;
                }
               
                

            }
            else if (userType == 2)
            {
                StaffUser user_ = user as StaffUser;

                if (String.IsNullOrEmpty(user_.name))
                {
                    staffUsers[userIndex].name = staffUsers[userIndex].name;
                }
                else
                {
                    staffUsers[userIndex].name = user_.name;
                }

                if (user_.age == 0)
                {
                    staffUsers[userIndex].age = staffUsers[userIndex].age;
                }
                else
                {
                    staffUsers[userIndex].age = user_.age;
                }

                if (String.IsNullOrEmpty(user_.role.ToString()))
                {
                    staffUsers[userIndex].role = user_.role;
                }
                else
                {
                    staffUsers[userIndex].role = user_.role;
                }
                
               
               

            }
            else if (userType == 3)
            {
                AdminUser user_ = user as AdminUser;
                if (String.IsNullOrEmpty(user_.name))
                {
                    adminUsers[userIndex].name = adminUsers[userIndex].name;
                }
                else
                {
                    adminUsers[userIndex].name = user_.name;
                }

                if (String.IsNullOrEmpty(user_.age.ToString()))
                {
                    adminUsers[userIndex].age = adminUsers[userIndex].age;
                }
                else
                {
                    adminUsers[userIndex].age = user_.age;
                }
                
               
            }

            return "User has edited successfully : ";
        }


        public string RemoveUser(int userType, int userIndex)
        {
            if (userType ==1)
            {

                 users.Remove(users[userIndex]);

            }
            else if (userType == 2)
            {
                
                staffUsers.Remove(staffUsers[userIndex]);

            }
            else if (userType == 3)
            {
              
                adminUsers.Remove(adminUsers[userIndex]);
            }

            return "User has deleted successfully : ";
        }



        public int GetUserIndex(int userType, int userID)
        {
            int indexOfUser = -1;
            if (userType == 1)
            {
                for (int i = 0; i < users.Count; i++)
                {

                    if (users[i].id == userID)
                    {
                         
                        indexOfUser = i;
                     }
                }
              
            }
            if (userType == 2)
            {
                 
                for (int i = 0; i < staffUsers.Count; i++)
                {

                    if (staffUsers[i].id == userID)
                    {

                        indexOfUser = i;
                        return indexOfUser;
                    }
                }
 
            }
            if (userType == 3)
            {

                for (int i = 0; i < adminUsers.Count; i++)
                {

                    if (adminUsers[i].id == userID)
                    {
                         
                        indexOfUser = i;
                        return indexOfUser;
                    }
                    
                }
 
            }

           
            return indexOfUser;
        }

        public bool UserIsFound(int userType, int userID)
        {

            if (GetUserIndex(userType, userID) < 0)
                throw new NotFoundedIDException("User tries to update/delete/add a user that is not found.");
            else
                return true;

        }
    }
}
