using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemEntities{
    public class User : IUser{
        #region User Variables
        private string username;
        private string password;
        private string userType;
        private string firstName;
        private string secondName;
        private string contactNo;
        #endregion

        #region IUser Variables
        public string Username { get{return username;} set{username = value;} }
        public string Password { get{return password;} set{password = value;} }
        public string UserType { get{return userType;} set{userType = value;} }
        public string FirstName { get{return firstName;} set{firstName = value;} }
        public string SecondName { get{return secondName;} set{secondName = value;} }
        public string ContactNo { get{return contactNo;} set{contactNo = value;} }
        #endregion

        #region Constructors
        public User() {
            throw new System.NotImplementedException();
        }

        public User(string name, string password, string userType, string firstName, string secondName, string contactNo) {
            this.username = name;
            this.password = password;
            this.userType = userType;
            this.firstName = firstName;
            this.secondName = secondName;
            this.contactNo = contactNo;
        }
        #endregion
    }
}