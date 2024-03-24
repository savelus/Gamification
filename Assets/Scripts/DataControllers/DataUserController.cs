using System;
using System.Collections.Generic;
using System.Data;
using DBUtils;

public class DataUserController
{
    public List<DataUser> GetAllUsers()
    {
        DataTable chestInScalesTable = DatabaseManager.GetTable("SELECT * FROM User");

        List<DataUser> users = new List<DataUser>();

        foreach (DataRow row in chestInScalesTable.Rows)
        {
            DataUser user = new DataUser
            {
                Name =row["Name"].ToString(),
                TeamId = Convert.ToInt32(row["TeamId"]),
                Position =row["Position"].ToString(),
                WorkLoad = Convert.ToInt32(row["WorkLoad"]),
            };

            users.Add(user);
        }

        return users;
    }

    public void AddUser(DataUser user)
    {
        DatabaseManager.ExecuteQueryWithoutAnswer($"INSERT INTO User ('Name', 'TeamId', 'Position', 'WorkLoad') " +
            $"VALUES ('{user.Name}', '{user.TeamId}', '{user.Position}', '{user.WorkLoad}');");
    }

    public void UpdateUser(DataUser user)
    {
        DatabaseManager.ExecuteQueryWithoutAnswer($"UPDATE User " +
            $"SET Name = '{user.Name}' TeamId = '{user.TeamId}' Position = '{user.Position}' WorkLoad = '{user.WorkLoad}'" +
            $"WHERE Name = {user.Name};");
    }

    public void DeleteUser(string userName)
    {
        DatabaseManager.ExecuteQueryWithoutAnswer($"DELETE User " +
            $"WHERE Name = {userName};");
    }
}
