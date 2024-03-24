using System;
using System.Collections.Generic;
using System.Data;
using DBUtils;

public class DataTeamController 
{
    public List<DataTeam> GetAllTeams()
    {
        DataTable teamTable = DatabaseManager.GetTable("SELECT * FROM Teams");

        List<DataTeam> teams = new List<DataTeam>();

        foreach (DataRow row in teamTable.Rows)
        {
            DataTeam team = new DataTeam
            {
                ID = Convert.ToInt32(row["ID"]),
                Name = row["Name"].ToString(),
            };

            teams.Add(team);
        }

        return teams;
    }

    public void AddTeam(DataTeam team)
    {
        DatabaseManager.ExecuteQueryWithoutAnswer($"INSERT INTO Teams ('Name') " +
            $"VALUES ('{team.Name}');");

    }

    public void UpdateTeam(DataTeam team)
    {
        DatabaseManager.ExecuteQueryWithoutAnswer($"UPDATE Teams " +
            $"SET Name = '{team.Name}'" +
            $"WHERE id = {team.ID};");
    }

    public void DeleteTeam(int teamId)
    {
        DatabaseManager.ExecuteQueryWithoutAnswer($"DELETE Teams " +
            $"WHERE id = {teamId};");
    }
}
