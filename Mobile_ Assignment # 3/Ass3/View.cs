using Ass3.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ass3
{
    class View
    {
        public ModelView ModelView = new ModelView();
        public int GetOperationsType()
        {
            int operationType = 0;
            Console.WriteLine("\n  - This is a menu for operation that's available for you :\n");
            Console.WriteLine(" 1. enter 1 to add an new user to the collection . \n");
            Console.WriteLine(" 2. enter 2 to editing data for a specific user . \n");
            Console.WriteLine(" 3. enter 3 to delete a specific user from collection . \n");
            Console.WriteLine("4. enter 4 to add an new staff user to list of staff users in Admin collection . \n");

            Console.Write(" PLZ enter which operation you want to implement : ");
            operationType = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("____________________________________________________________________________\n");
            return operationType;
        }

        public int GetUserType()
        {
            int userType = 0;
            Console.WriteLine("\n  - This is a list of users in the system :\n");
            Console.WriteLine(" 1. enter 1 to make operations on users . \n");
            Console.WriteLine(" 2. enter 2 to make operations on staff users . \n");
            Console.WriteLine(" 3. enter 3 to make operations on Admin users . \n");

            Console.Write("PLZ enter number of user you want make operation on it 'PS : enter -1 to end the operation :)' : ");
            userType = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("____________________________________________________________________________\n");

            return userType;
        }

        public void Implementation()
        {
            int id = 0, age = 0, userID = 0, userIndex = 0, userType = 0, operationType = 0; ;
            string name = "";

            userType = GetUserType();

            while (userType != -1)
            {

                switch (userType)
                {
                    case 1:
                        ModelView.users.CollectionChanged += ConllectionAddChanged<User>;
                        ModelView.users.CollectionChanged += ConllectionRemoveChanged<User>;
                        operationType = GetOperationsType();
                        while (operationType != -1)
                        {
                            switch (operationType)
                            {
                                case 1:
                                    try
                                    {
                                        id = 0;
                                        
                                        SetID(userType, ref id); SetName(ref name); SetAge(ref age);
                                        User user = new User(id, name , age);
                                        ModelView.AddUser<User>(userType,user);
                                        Console.WriteLine("\n____________________________________________________________________________\n");
                                    }catch (InvalidDataException e)
                                    {
                                        Console.WriteLine($"\nInvalidDataException : {e.Message}");

                                    }catch (DuplicateIDException e)
                                    {
                                        Console.WriteLine($"\nDuplicateIDException : {e.Message}");
                                    }catch (Exception e)
                                    {
                                        Console.WriteLine($"\nException : {e.Message}");
                                    }
                                   


                                    break;

                                case 2:


                                    try
                                    {
                                        Console.Write(" PLZ enter ID of user you want edit his/her data : ");
                                        SetID(0,ref userID);

                                        ModelView.UserIsFound(userType, userID);
                                        userIndex = ModelView.GetUserIndex(userType, userID);
                                        
                                        Console.WriteLine("Press Enter if you wont edit name or enter 0 if you wont edit age : ");
                                        SetName(ref name); SetAge(ref age);

                                        User user_ = new User(userID, name, age);
                                        ModelView.EditUser<User>(userType, user_, userIndex);
                                    }catch (NotFoundedIDException e)
                                    {
                                        Console.WriteLine($"\nNotFoundedIDException : {e.Message}");
                                    }catch (InvalidDataException e)
                                    {
                                        Console.WriteLine($"\nInvalidDataException : {e.Message}");

                                    }catch (Exception e)
                                    {
                                        Console.WriteLine($"\nException : {e.Message}");
                                    }
                                    break;

                                case 3:

                                    try
                                    {
                                        Console.Write(" PLZ enter ID of user you want edit his/her data : ");
                                        SetID(0, ref userID);
                                        ModelView.UserIsFound(userType, userID);

                                        userIndex = ModelView.GetUserIndex(userType, userID);
                                        ModelView.RemoveUser(userType, userIndex);
                                    }catch (NotFoundedIDException e)
                                    {
                                        Console.WriteLine($"\nNotFoundedIDException : {e.Message}");
                                    }catch (InvalidDataException e)
                                    {
                                        Console.WriteLine($"\nInvalidDataException : {e.Message}");

                                    }catch (Exception e)
                                    {
                                        Console.WriteLine($"\nException : {e.Message}");
                                    }
                                    break;

                                default:
                                    Console.WriteLine("Entered  operation type not match exist values : ");
                                    break;


                            }
                  
                            operationType = GetOperationsType();

                        }

                        break;

                    case 2:

                        ModelView.staffUsers.CollectionChanged += ConllectionAddChanged<StaffUser>;
                        ModelView.staffUsers.CollectionChanged += ConllectionRemoveChanged<StaffUser>;
                        var role= Role.Role1;
                        operationType = GetOperationsType();
                        while (operationType != -1)
                        {
                            switch (operationType)
                            {
                                case 1:
                                    try
                                    {
                                        SetID(userType,ref id); SetName(ref name); SetAge(ref age);

                                        role = SetRole();
                                        StaffUser user = new StaffUser(id, name, age , role);

                                        ModelView.AddUser<StaffUser>(userType,user);
                                        Console.WriteLine("\n____________________________________________________________________________\n");

                                    } catch (DuplicateIDException e)
                                    {
                                        Console.WriteLine($"\nDuplicateIDException : {e.Message}");
                                    }
                                    catch(InvalidDataException e)
                                    {
                                        Console.WriteLine($"\nDuplicateIDException : {e.Message}");

                                    }catch (Exception e)
                                    {
                                        Console.WriteLine($"\nException : {e.Message}");
                                    }


                                    break;

                                case 2:

                                    try
                                    {
                                        Console.Write(" PLZ enter ID of user you want edit his/her data : ");
                                        SetID(0, ref userID);
                                        ModelView.UserIsFound(userType, userID);

                                        userIndex = ModelView.GetUserIndex(userType, userID);

                                        Console.WriteLine("Press Enter if you wont edit name or enter 0 if you wont edit age : ");
                                        SetName(ref name); SetAge(ref age);
                                        role = SetRole();
                                        StaffUser user_ = new StaffUser(userID, name, age , role);
                                        ModelView.EditUser<StaffUser>(userType,user_, userIndex);
                                    }catch (NotFoundedIDException e)
                                    {
                                        Console.WriteLine($"\nNotFoundedIDException : {e.Message}");
                                    }catch (InvalidDataException e)
                                    {
                                        Console.WriteLine($"\nInvalidDataException : {e.Message}");
                                    }catch (Exception e)
                                    {
                                        Console.WriteLine($"\nException : {e.Message}");
                                    }


                                    break;

                                case 3:

                                    try
                                    {
                                        Console.Write(" PLZ enter ID of user you want edit his/her data : ");
                                        SetID(0,ref userID);
                                        ModelView.UserIsFound(userType, userID);

                                        userIndex = ModelView.GetUserIndex(userType, userID);
                                        ModelView.RemoveUser(userType, userIndex);
                                    }catch (NotFoundedIDException e)
                                    {
                                        Console.WriteLine($"\nNotFoundedIDException : {e.Message}");
                                    }catch (InvalidDataException e)
                                    {
                                        Console.WriteLine($"\nInvalidDataException : {e.Message}");
                                    }catch (Exception e)
                                    {
                                        Console.WriteLine($"\nException : {e.Message}");
                                    }
                                    break;

                                default:
                                    Console.WriteLine("Entered  operation type not match exist values : ");
                                    break;


                            }

                            operationType = GetOperationsType();

                        }
                        break;

                    case 3:

                        ModelView.adminUsers.CollectionChanged   += ConllectionAddChanged<AdminUser>;
                        ModelView.adminUsers.CollectionChanged += ConllectionRemoveChanged<AdminUser>;
                        operationType = GetOperationsType();
                        while (operationType != -1)
                        {
                            switch (operationType)
                            {
                                case 1:
                                    try
                                    {
                                        SetID(userType, ref id); SetName(ref name); SetAge(ref age);

                                        AdminUser user = new AdminUser(id, name, age);

                                        ModelView.AddUser<AdminUser>(userType, user);
                                        Console.WriteLine("\n____________________________________________________________________________\n");

                                    }catch (DuplicateIDException e)
                                    {
                                        Console.WriteLine($"\nDuplicateIDException : {e.Message}");
                                    }catch (InvalidDataException e)
                                    {
                                        Console.WriteLine($"\nInvalidDataException : {e.Message}");
                                    }catch (Exception e)
                                    {
                                        Console.WriteLine($"\nException : {e.Message}");
                                    }

                                    break;

                                case 2:

                                    try
                                    {
                                         
                                        SetID(0,ref userID);
                                        ModelView.UserIsFound(userType, userID);

                                        userIndex = ModelView.GetUserIndex(userType, userID);

                                        Console.WriteLine("Press Enter if you wont edit name or enter 0 if you wont edit age : ");
                                        SetName(ref name); SetAge(ref age);

                                        AdminUser user_ = new AdminUser(userID, name, age);
                                        ModelView.EditUser<AdminUser>(userType, user_, userIndex);
                                    }catch (NotFoundedIDException e)
                                    {
                                        Console.WriteLine($"\nNotFoundedIDException : {e.Message}");
                                    }catch (InvalidDataException e)
                                    {
                                        Console.WriteLine($"\nInvalidDataException : {e.Message}");

                                    }catch (Exception e)
                                    {
                                        Console.WriteLine($"\nException : {e.Message}");
                                    }
                                    break;

                                case 3:

                                    try
                                    {

                                        SetID(0, ref userID);
                                        ModelView.UserIsFound(userType, userID);

                                        userIndex = ModelView.GetUserIndex(userType, userID);
                                        ModelView.RemoveUser(userType, userIndex);
                                    }
                                    catch (NotFoundedIDException e)
                                    {
                                        Console.WriteLine($"\nNotFoundedIDException : {e.Message}");
                                    }catch (InvalidDataException e)
                                    {
                                        Console.WriteLine($"\nInvalidDataException : {e.Message}");
                                    }catch (Exception e)
                                    {
                                        Console.WriteLine($"\nException : {e.Message}");
                                    }
                                    break;

                                case 4:

                                    try
                                    {
                                        int userIndex1 =0 , userID1 = 0;
                                        Console.Write("For staff user whos you want add to admin staff list : ");
                                        SetID(0, ref userID);
                                        ModelView.UserIsFound(2, userID);

                                        userIndex = ModelView.GetUserIndex(2, userID);

                                        Console.Write("For admin whos you want add staff to it : ");
                                        SetID(0, ref userID1);
                                        ModelView.UserIsFound(userType, userID1);

                                        userIndex1 = ModelView.GetUserIndex(userType, userID1);


                                        ModelView.adminUsers[userIndex1].staffUser.Add(ModelView.staffUsers[0]);
 
                                    }catch (NotFoundedIDException e)
                                    {
                                        Console.WriteLine($"\nNotFoundedIDException : {e.Message}");
                                    }catch (InvalidDataException e)
                                    {
                                        Console.WriteLine($"\nInvalidDataException : {e.Message}");
                                    }catch (Exception e)
                                    {
                                        Console.WriteLine($"\nException : {e.Message}");
                                    }

                                    break;

                                default:
                                    Console.WriteLine("Entered  operation type not match exist values : ");
                                    break;


                            }

                            operationType = GetOperationsType();

                        }
                        break;

                    default:
                        Console.WriteLine("Entered  user type not match exist values : ");
                        break;
                }

                userType = GetUserType();

            }
        }

        private static void ConllectionAddChanged<T>(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action.Equals(NotifyCollectionChangedAction.Add))
            {
                ObservableCollection<T> user = (ObservableCollection<T>)sender;
                Console.WriteLine($"* Total count After Add is : {user.Count}");
                Console.WriteLine("* The urrent user in the system are :\n");
                for (int i=0; i < user.Count;i++)
                {
                    Console.WriteLine(user[i].ToString());
                    Console.WriteLine(".................................................");

                }

            }

        }
        private static void ConllectionRemoveChanged<T>(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action.Equals(NotifyCollectionChangedAction.Remove))
            {
                ObservableCollection<T> user = (ObservableCollection<T>)sender;
                Console.WriteLine($"* Total count after Remove is : {user.Count}");
                Console.WriteLine("* The urrent user in the system are :\n");
                for (int i = 0; i < user.Count; i++)
                {
                    Console.WriteLine(user[i].ToString());
                    Console.WriteLine(".................................................");

                }
            }
            else if (e.Action.Equals(NotifyCollectionChangedAction.Reset))
            {
                ObservableCollection<T> user = (ObservableCollection<T>)sender;
                Console.WriteLine($"Total count after Reset is : {user.Count}");
            }

        }
 
        
        public void SetID(int userType, ref int id)
        {
            Console.Write(" PLZ enter user ID : ");

            string idText;
            idText = Console.ReadLine();
            bool isNumber = int.TryParse(idText, out int n);

            if (!isNumber)
            {
                id = 0;
                throw new InvalidDataException("User enters invald data for id");
            }
            else
            {
                id = int.Parse(idText);
            }
            if (userType == 1 && (ModelView.GetUserIndex(userType,id)>=0))
            {
                
                throw new DuplicateIDException("you are tries to add a new user with a duplicate id");

            } else if (userType == 2 && (ModelView.GetUserIndex(userType, id) >= 0))
            {
                throw new DuplicateIDException("you are tries to add a new staff user with a duplicate id");
            }else if ((userType == 3 )&& (ModelView.GetUserIndex(3, id) >= 0))
            {
                throw new DuplicateIDException("you are tries to add a new admin user with a duplicate id");
            } 
        }

        public void SetName(ref string name)
        {
            Console.Write(" PLZ enter user name : ");
            name = Console.ReadLine();
            bool isNumber = int.TryParse(name, out int n);

            if (isNumber)
            {
                throw new InvalidDataException("User enters invald data for name");
            }
        }

        public void SetAge(ref int age)
        {
            Console.Write(" PLZ enter user age : ");
            string ageText;
            ageText = Console.ReadLine();
            bool isNumber = int.TryParse(ageText, out int n);

            if (!isNumber)
            {

                throw new InvalidDataException("User enters invald data for age");
            }
            else
            {
                age = int.Parse(ageText);
            }
        }

        public Role SetRole()
        {
            int chooseRole = 0;

            Console.WriteLine("\n  - List of Roles available :\n");
            Console.WriteLine(" 1. enter 1 to set role as Role1 . \n");
            Console.WriteLine(" 2. enter 2 to set role as Role2 . \n");
            Console.WriteLine(" 3. enter 3 to set role as Role3 . \n");

            Console.Write("PLZ enter role value from the list : ");
            chooseRole = Convert.ToInt32(Console.ReadLine());
            while (chooseRole !=1 && chooseRole !=2 && chooseRole !=3)
            {
                Console.Write("Incorrect Role choice, PLZ enter role value from the list again : ");
                chooseRole = Convert.ToInt32(Console.ReadLine());
            }
     
            Console.WriteLine(chooseRole+" ____________________________________________________________________________\n");


            if (chooseRole == 1)
            {
                return Role.Role1;
            }
            if (chooseRole == 2)
            {
                return Role.Role2;
            }
            if (chooseRole == 3)
            {
                return Role.Role3;
            }

            return 0;
        }

    }
}
