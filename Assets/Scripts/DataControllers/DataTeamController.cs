using System;
using System.Collections.Generic;
using System.Data;
using DBUtils;

public class DataTeamController 
{
    public List<Team> GetAllTeams()
    {
        DataTable teamTable = DatabaseManager.GetTable("SELECT * FROM Teams");

        List<Team> teams = new List<Team>();

        foreach (DataRow row in teamTable.Rows)
        {
            Team team = new Team
            {
                ID = Convert.ToInt32(row["ID"]),
                Name = row["Name"].ToString(),
            };

            teams.Add(team);
        }

        return teams;
    }

    public void AddTeam(Team team)
    {
        DatabaseManager.ExecuteQueryWithoutAnswer($"INSERT INTO Teams ('Name') " +
            $"VALUES ('{team.Name}');");

    }

    public void UpdateTeam(Team team)
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
