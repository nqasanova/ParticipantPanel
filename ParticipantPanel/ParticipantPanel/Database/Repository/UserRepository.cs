using AuthenticationWithClie.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationWithClie.Database.Repository
{
    class UserRepository
    {
        private static int _idCounter;

        public static int IdCounter
        {
            get
            {
                _idCounter++;
                return _idCounter;
            }
        }


        private static List<User> Users { get; set; } = new List<User>()
        {
            new Admin("Natavan", "Hasanova", "natavanhasanova@gmail.com", "123321"),
            new User("Leyla", "İslamova", "leyla@gmail.com", "123321"),
            new User("Saray", "Quliyeva", "saray@gmail.com", "123321"),
        };

        public static User AddUser(string firstName, string lastName, string email, string password)
        {
            User user = new User(firstName, lastName, email, password, IdCounter);
            Users.Add(user);
            return user;
        }

        public static User AddUser(string firstName, string lastName, string email, string password, int id)
        {
            User user = new User(firstName, lastName, email, password, id);
            Users.Add(user);
            return user;
        }

        public static User AddUser(User user)
        {
            Users.Add(user);
            return user;
        }

        public static User AddUser(Admin user)
        {
            Users.Add(user);
            return user;
        }

        public static List<User> GetAll()
        {
            return Users;
        }

        public static int GetUserCount()
        {
            return Users.Count;
        }

        public static bool IsUserExistsByEmail(string email)
        {
            foreach (User user in Users)
            {
                if (user.Email == email)
                {
                    return true;
                }
            }

            return false;
        }

        public static User GetUserByEmailAndPassword(string email, string password)
        {
            foreach (User user in Users)
            {
                if (user.Email == email && user.Password == password)
                {
                    return user;
                }
            }

            return null;
        }

        public static bool IsUserExistByEmailAndPassword(string email, string password)
        {
            foreach (User user in Users)
            {
                if (user.Email == email && user.Password == password)
                {
                    return true;
                }
            }

            return false; ;
        }

        public static User GetUserByEmail(string email)
        {
            foreach (User user in Users)
            {
                if (user.Email == email)
                {
                    return user;
                }
            }

            return null;
        }

        public static void Delete(User user)
        {
            Users.Remove(user);
        }
    }
}