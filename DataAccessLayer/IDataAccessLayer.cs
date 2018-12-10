using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemEntities;

namespace DataAccessLayer {
    public interface IDataAccessLayer {
        // Adding to the database.
        bool addToDataBase(IUser user);
        bool addToDataBase(IDoctor doctor);
        bool addToDataBase(IDrug drug);
        bool addToDataBase(IPrescription prescription);
        bool addToDataBase(IWarning warning);
        bool addToDataBase(IDirection direction);
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
        // Connection.
        System.Data.SqlClient.SqlConnection getConnection();
        void closeConnection();
        void openConnection();
        // Getting all users for login.
        List<IUser> getAllUsers();
    }
}