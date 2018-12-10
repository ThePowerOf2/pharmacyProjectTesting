using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemEntities {
    public static class UserFactory {
        private static IUser user = null;

        public static IUser getUser(string name, string password, string userType, string firstName, string secondName, string contactNo) {
            if (user != null)
                return user;
            else
                return new User(name, password, userType, firstName, secondName, contactNo);
        }
        public static void setUser(IUser aUser){
            user = aUser;
        }
    }
}