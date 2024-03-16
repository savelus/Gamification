using System;
using System.Collections.Generic;
using System.Data;
using DBUtils;

public class DataUserController
{
    public List<User> GetAllUsers()
    {
        DataTable chestInScalesTable = DatabaseManager.GetTable("SELECT * FROM User");

        List<User> users = new List<User>();

        foreach (DataRow row in chestInScalesTable.Rows)
        {
            User user = new User
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

    public void AddUser(User user)
    {
        DatabaseManager.ExecuteQueryWithoutAnswer($"INSERT INTO User ('Name', 'TeamId', 'Position', 'WorkLoad') " +
            $"VALUES ('{user.Name}', '{user.TeamId}', '{user.Position}', '{user.WorkLoad}');");
    }

    public void UpdateUser(User user)
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
