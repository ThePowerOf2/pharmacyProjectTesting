using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using SystemEntities;

namespace DataAccessLayer {
    public class DataAccessLayer : IDataAccessLayer {
        #region Instance Attributes
        private SqlConnection con;
        DataSet ds;
        SqlDataAdapter da;
        int amountOfUsers;
        SqlCommandBuilder cb;
        #endregion

        #region Static Attributes
        // DataLayer object is a singleton so only one instance allowed.
        public static IDataAccessLayer dataLayerSingletonInstance;

        // Need this for thread safety on the DataLayer singleton creation.
        static readonly object padlock = new object();

        #endregion

        #region Database Details
        // Connection String 
        string URL = "jsapc1.database.windows.net";
        string Database = "jsapc";
        string userID = "jsapc";
        string Password = "Munster2";

        // Table Names.
        string staffTableName { get; } = "Users";
        string doctorTableName { get; } = "Doctors";
        string drugRefundTableName { get; } = "Drug_Refund";
        string medicalCardTableName { get; } = "Medical_Card_Holder";
        string drugPaymentTableName { get; } = "Drug_Payment";
        string drugTableName { get; } = "Drugs";
        string prescriptionTableName { get; } = "Prescription";
        string directionTableName { get; } = "Directions";
        string warningTableName { get; } = "Warnings";
        #endregion

        #region Constructors
        // With Singleton pattern this method is used rather than constructor
        public static IDataAccessLayer GetInstance() {
            // Only one thread can entry this block of code
            lock (padlock) {
                if (dataLayerSingletonInstance == null) {
                    dataLayerSingletonInstance = new DataAccessLayer();
                }
                return dataLayerSingletonInstance;
            }
        }
        // The constructor is private as its a singleton and I only allow one instance which is created with the GetInstance() method.
        private DataAccessLayer() {
            openConnection();
        }
        #endregion

        public virtual void openConnection() {
            // Connection to the SQL server with the connection string and database information.
            con = new SqlConnection();
            con.ConnectionString = "Server=tcp:" + URL + ";Initial Catalog=" + Database + ";Persist Security Info=False;User ID=" + userID + ";Password=" + Password + ";MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;";

            // Try connect to the SQL server.
            try {
                con.Open();
            }
            // If the connection does not work then show the user the error and exit the application.
            catch (System.Exception excep) {
                //MessageBox.Show(excep.Message);
                Environment.Exit(0);
            }
        }

        public virtual void closeConnection() {
            con.Close();
        }

        public virtual SqlConnection getConnection() {
            return con;
        }

        // Updating a dataset with the given table from the database.
        private void updateDataSet(String TableName) {
            ds = new DataSet();
            string sql = "SELECT * From " + TableName;
            da = new SqlDataAdapter(sql, con);
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            cb = new SqlCommandBuilder(da);
            da.Fill(ds, TableName + "Data");
        }

        // Updating a dataset with the given table from the database including an extra condition.
        private void updateDataSet(String TableName, String Condition) {
            ds = new DataSet();
            string sql = "SELECT * From " + TableName + " " + Condition;
            da = new SqlDataAdapter(sql, con);
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            cb = new SqlCommandBuilder(da);
            da.Fill(ds, TableName + "Data");
        }

        // Generating a list with all of the users from the SQL [staffTableName] table.
        public virtual List<IUser> getAllUsers() {
            // Creating a empty list to add all of the uers from the database to.
            List<IUser> UserList = new List<IUser>();
            try {
                updateDataSet(staffTableName);
                amountOfUsers = ds.Tables[staffTableName + "Data"].Rows.Count;
                // Iterating through each row of the table and creating a user with the data in the row and adding it to the UserList.
                for (int i = 0; i < amountOfUsers; i++) {
                    DataRow dRow = ds.Tables[staffTableName + "Data"].Rows[i];
                    // Using a Factory to create the user entity object. ie seperating object creation from business logic.
                    IUser user = UserFactory.getUser(dRow.ItemArray.GetValue(0).ToString(), dRow.ItemArray.GetValue(1).ToString(), dRow.ItemArray.GetValue(2).ToString(), dRow.ItemArray.GetValue(3).ToString(), dRow.ItemArray.GetValue(4).ToString(), dRow.ItemArray.GetValue(5).ToString());

                    UserList.Add(user);
                }
            }
            // If there was an error in connecting to the database then show the error to the uesr and close the application.
            catch (System.Exception excep) {
                MessageBox.Show(excep.Message);
                if (con.State.ToString() == "Open")
                    con.Close();
                Application.Exit();
            }
            return UserList;
        }

        // Adding a new user to the SQL [staffTableName] table.
        public virtual void addToDataBase(IUser theUser) {
            try {
                string tableName = staffTableName;
                updateDataSet(tableName);

                // Creating a new datarow with the information from the IUser object given.
                DataRow dRow = ds.Tables[tableName + "Data"].NewRow();
                dRow[0] = theUser.Username;
                dRow[1] = theUser.Password;
                dRow[2] = theUser.UserType;
                dRow[3] = theUser.FirstName;
                dRow[4] = theUser.SecondName;
                dRow[5] = theUser.ContactNo;

                // Adding the new datarow to the dataset and then updating the [User] table to what the DataSet now contains.
                ds.Tables[tableName + "Data"].Rows.Add(dRow);
                da.Update(ds, tableName + "Data");
            }
            // If there was an error in connecting to the database then show the error to the uesr and close the application.
            catch (System.Exception excep) {
                MessageBox.Show(excep.Message);
                if (con.State.ToString() == "Open")
                    con.Close();
                Application.Exit();
            }
        }

        public virtual void addToDataBase(IDoctor theDoctor) {
            try {
                string tableName = doctorTableName;
                updateDataSet(tableName);
                DataRow dRow = ds.Tables[tableName + "Data"].NewRow();
                dRow[0] = theDoctor.DoctorGMS;
                dRow[1] = theDoctor.FirstName;
                dRow[2] = theDoctor.SecondName;
                dRow[3] = theDoctor.Address;
                dRow[4] = theDoctor.ContactNo;
                ds.Tables[tableName + "Data"].Rows.Add(dRow);
                da.Update(ds, tableName + "Data");
            }
            catch (System.Exception excep) {
                MessageBox.Show(excep.Message);
                if (con.State.ToString() == "Open")
                    con.Close();
                Application.Exit();
            }
        }

        public virtual void addToDataBase(IDrug theDrug) {
            try {
                string tableName = drugTableName;
                updateDataSet(tableName);
                DataRow dRow = ds.Tables[tableName + "Data"].NewRow();
                dRow[0] = theDrug.DrugGMS;
                dRow[1] = theDrug.PropietaryName;
                dRow[2] = theDrug.GenericName;
                dRow[3] = theDrug.Cost;
                dRow[4] = theDrug.Manufacturer;
                dRow[5] = theDrug.Agent;
                ds.Tables[tableName + "Data"].Rows.Add(dRow);
                da.Update(ds, tableName + "Data");
            }
            catch (System.Exception excep) {
                MessageBox.Show(excep.Message);
                if (con.State.ToString() == "Open")
                    con.Close();
                Application.Exit();
            }
        }

        public virtual void addToDataBase(IPrescription thePrescription) {
            try {
                string tableName = prescriptionTableName;
                updateDataSet(tableName);
                DataRow dRow = ds.Tables[tableName + "Data"].NewRow();
                dRow[0] = thePrescription.PrescriptionID;
                dRow[1] = thePrescription.Date;
                dRow[2] = thePrescription.StaffUserName;
                dRow[3] = thePrescription.DoctorGMS;
                dRow[4] = thePrescription.DrugGMS;
                dRow[5] = thePrescription.RepeatPrescription;
                dRow[6] = thePrescription.PrescriptionEndDate;
                ds.Tables[tableName + "Data"].Rows.Add(dRow);
                da.Update(ds, tableName + "Data");
            }
            catch (System.Exception excep) {
                MessageBox.Show(excep.Message);
                if (con.State.ToString() == "Open")
                    con.Close();
                Application.Exit();
            }
        }

        public virtual void addToDataBase(IWarning theWarning) {
            try {
                string tableName = warningTableName;
                updateDataSet(tableName);
                DataRow dRow = ds.Tables[tableName + "Data"].NewRow();
                dRow[0] = theWarning.WarningNo;
                dRow[1] = theWarning.theWarning;
                ds.Tables[tableName + "Data"].Rows.Add(dRow);
                da.Update(ds, tableName + "Data");
            }
            catch (System.Exception excep) {
                MessageBox.Show(excep.Message);
                if (con.State.ToString() == "Open")
                    con.Close();
                Application.Exit();
            }
        }

        public virtual void addToDataBase(IDirection theDirection) {
            try {
                string tableName = directionTableName;
                updateDataSet(tableName);
                DataRow dRow = ds.Tables[tableName + "Data"].NewRow();
                dRow[0] = theDirection.Directions;
                dRow[1] = theDirection.DrugGMS;
                dRow[2] = theDirection.PrescriptionID;
                ds.Tables[tableName + "Data"].Rows.Add(dRow);
                da.Update(ds, tableName + "Data");
            }
            catch (System.Exception excep) {
                MessageBox.Show(excep.Message);
                if (con.State.ToString() == "Open")
                    con.Close();
                Application.Exit();
            }
        }
    }
}

//Convert.ToInt16((dRow.ItemArray.GetValue(3)))