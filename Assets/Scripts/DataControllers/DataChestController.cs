using System;
using System.Collections.Generic;
using System.Data;
using DBUtils;
using UnityEngine;

public class DataChestController 
{
    public List<DataChest> GetAllChests()
    {
        DataTable ChestsTable = DatabaseManager.GetTable("SELECT * FROM Chests");

        List<DataChest> chests = new List<DataChest>();

        foreach (DataRow row in ChestsTable.Rows)
        {
            DataChest chest = new DataChest
            {
                ID = Convert.ToInt32(row["ID"]),
                Reward = row["Reward"].ToString(),
                PointsToComplete = Convert.ToInt32(row["PointsToComplete"])
            };

            chests.Add(chest);
            Debug.Log("chest");
        }

        return chests;
    }

    public void AddChest(DataChest chest)
    {
        DatabaseManager.ExecuteQueryWithoutAnswer($"INSERT INTO Chests ('Reward', 'PointsToComplete') " +
            $"VALUES ('{chest.Reward}', '{chest.PointsToComplete}');");
    }

    public void UpdateChest(DataChest chest)
    {
        DatabaseManager.ExecuteQueryWithoutAnswer($"UPDATE Chests " +
            $"SET Reward = '{chest.Reward}' PointsToComplete = {chest.PointsToComplete} " +
            $"WHERE id = {chest.ID};");
    }

    public void DeleteChest(int chestId)
    {
        DatabaseManager.ExecuteQueryWithoutAnswer($"DELETE Chests " +
            $"WHERE id = {chestId};");
    }
}
