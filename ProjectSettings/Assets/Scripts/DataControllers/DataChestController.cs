using System;
using System.Collections.Generic;
using System.Data;

public class DataChestController 
{
    public List<Chest> GetAllChests()
    {
        DataTable ChestsTable = DatabaseManager.GetTable("SELECT * FROM Chest");

        List<Chest> chests = new List<Chest>();

        foreach (DataRow row in ChestsTable.Rows)
        {
            Chest chest = new Chest
            {
                ID = Convert.ToInt32(row["ID"]),
                Reward = row["Reward"].ToString(),
                PointsToComplete = Convert.ToInt32(row["PointsToComplete"])

            };

            chests.Add(chest);
        }

        return chests;
    }

    public void AddChest(Chest chest)
    {
        DatabaseManager.ExecuteQueryWithoutAnswer($"INSERT INTO Chest ('Reward', 'PointsToComplete') " +
            $"VALUES ('{chest.Reward}', '{chest.PointsToComplete}');");
    }

    public void UpdateChest(Chest chest)
    {
        DatabaseManager.ExecuteQueryWithoutAnswer($"UPDATE Chest " +
            $"SET Reward = '{chest.Reward}' PointsToComplete = {chest.PointsToComplete} " +
            $"WHERE id = {chest.ID};");
    }

    public void DeleteChest(int chestId)
    {
        DatabaseManager.ExecuteQueryWithoutAnswer($"DELETE Chest " +
            $"WHERE id = {chestId};");
    }
}
