using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemEntities;
using DataAccessLayer;

namespace ModelLayer {
    public interface IModel {
        #region Lists
        List<IUser> UserList { get; }
        List<IDoctor> DoctorList { get; }
        List<IDrug> DrugList { get; }
        List<IPrescription> PrescriptionList { get; }
        List<IWarning> WarningList { get; }
        List<IDirection> DirectionList { get; }
        #endregion

        #region Variables
        IUser CurrentUser { get; set; }
        IDataAccessLayer DataLayer { get; set; }
        #endregion

        #region Functions
        // Adding to the database.
        bool addNewUser(string username, string password, string userType, string firstName, string secondName, string contactNo);
        bool addNewDoctor(string doctorGMS, string firstName, string secondName, string address, string contactNo);
        bool addNewDrug(string drugGMS, string propietaryName, string genericName, double cost, string manufacturer, string agent);
        bool addNewPrescription(string prescriptionID, DateTime date, string staffUserName, string doctorGMS, string[] drugGMS, bool repeatPrescription, DateTime prescriptionEndDate);
        bool addNewWarning(string warningNo, string warning);
        bool addNewDirection(string directions, string drugGMS, string prescriptionID);
        // Deleting from the database.
        bool deleteFromDatabase(IUser user);
        bool deleteFromDatabase(IDoctor drug);
        bool deleteFromDatabase(IDrug drug);
        bool deleteFromDatabase(IPrescription prescription);
        bool deleteFromDatabase(IWarning warning);
        bool deleteFromDatabase(IDirection direction);
        //Editing the database.
        bool editInDataBase(IUser user);
        bool editInDataBase(IDoctor drug);
        bool editInDataBase(IDrug drug);
        bool editInDataBase(IPrescription prescription);
        bool editInDataBase(IWarning warning);
        bool editInDataBase(IDirection direction);
        // Login.
        bool login(string name, string password);
        string getCurrentUserType();
        // Deconstruction.
        void tearDown();
        #endregion
    }
}