using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemEntities;
using DataAccessLayer;

namespace ModelLayer{
    public class Model : IModel{
        #region Declaring Static Attributes
        private static IModel modelSingletonInstance;
        static readonly object padlock = new object();
        #endregion

        #region Instance Variables
        private IDataAccessLayer dataLayer;
        private IUser currentUser;

        public IDataAccessLayer DataLayer { get { return dataLayer; } set { dataLayer = value; } }
        public IUser CurrentUser { get { return currentUser; } set { currentUser = value; } }

        private List<IUser> userList;
        private List<IDoctor> doctorList;
        private List<IDrug> drugList;
        private List<IPrescription> prescriptionList;
        private List<IWarning> warningList;
        private List<IDirection> directionList;

        public List<IUser> UserList { get { return userList; } set { userList = value; } }
        public List<IDoctor> DoctorList { get { return doctorList; } set { doctorList = value; } }
        public List<IDrug> DrugList { get { return drugList; } set { drugList = value; } }
        public List<IPrescription> PrescriptionList { get { return prescriptionList; } set { prescriptionList = value; } }
        public List<IWarning> WarningList { get { return warningList; } set { warningList = value; } }
        public List<IDirection> DirectionList { get { return directionList; } set { directionList = value; } }
        #endregion

        #region Constructors/Destructors
        // With Singleton pattern this method is used rather than a constructor.
        public static IModel GetInstance(IDataAccessLayer _DataLayer) {
            lock (padlock) {
                if (modelSingletonInstance == null) {
                    modelSingletonInstance = new Model(_DataLayer);
                }
                return modelSingletonInstance;
            }
        }

        // The constructor is private as its a singleton.
        private Model(IDataAccessLayer _DataLayer) {
            userList = new List<IUser>();
            dataLayer = _DataLayer;
            // Populate the models userList so the user can login.
            userList = dataLayer.getAllUsers();
        }

        // Deconstructor.
        ~Model() {
            tearDown();
        }
        #endregion

        // Validating whether the login was succesful or not by returning a boolean.
        public Boolean login(String name, String password) {
            IUser matchUser = userList.FirstOrDefault(user => user.Username == name && user.Password == password);
            if (matchUser == null) {
                return false;
            }
            else {
                CurrentUser = matchUser;
                return true;
            }
        }

        /* Adding a new user to the database and returning a boolean whether it was succesful or not.
        public Boolean addNewUser(string name, string password, string userType) {
            // Checking if the username is already in the userlist and therefore a duplicate.
            IUser duplicateUser = this.UserList.FirstOrDefault(user => user.Username == name.Trim());

            // Return false if the user is a duplicate
            if (duplicateUser != null)
                return false;
            // Return false if the user or password is less than 5 characters.
            else if ((name.Length < 5) || (password.Length < 5))
                return false;
            // Else it is a valid username and password combonation. Add it to the database.
            else {
                try {
                    int maxId = 0;
                    foreach (User user in UserList) {
                        if (user.UserID > maxId)
                            maxId = user.UserID;
                    }
                    // Using a Factory to create the user entity object. ie seperating object creation from business logic.
                    IUser theUser = UserFactory.GetUser(name, password, userType, maxId + 1);
                    // Add a reference to the newly created object to the Models UserList.
                    UserList.Add(theUser);
                    //Gets the DataLayer to add the new user to the DB. 
                    DataLayer.addNewUserToDB(theUser);
                    return true;
                }
                // If there was an error in connecting to the database then show the error to the uesr and close the application.
                catch (System.Exception excep) {
                    return false;
                }
            }
        }*/
        /* Deleting a user on the database and returning a boolean whether it was succesful or not.
        public bool deleteUser(IUser user) {
            DataLayer.deleteUserFromDB(user);
            // Remove object from the user list.
            UserList.Remove(user);
            return true;

        }

        // Aditing a user on the database and returning a boolean whether it was succesful or not.
        public bool editUser(IUser user) {
            DataLayer.editUserInDB(user);
            return true;
        }*/

        // Getting the current usertype.
        public String getCurrentUserType() {
            return currentUser.UserType;
        }

        // Closing down the connection with the database.
        public void tearDown() {
            //DataLayer.closeConnection();
        }
    }
}