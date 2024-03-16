using System;
using System.Collections.Generic;
using System.Data;
using DBUtils;
using UnityEngine;

public class DataChestController 
{
    public List<ChestM> GetAllChests()
    {
        DataTable ChestsTable = DatabaseManager.GetTable("SELECT * FROM Chests");

        List<ChestM> chests = new List<ChestM>();

        foreach (DataRow row in ChestsTable.Rows)
        {
            ChestM chest = new ChestM
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

    public void AddChest(ChestM chest)
    {
        DatabaseManager.ExecuteQueryWithoutAnswer($"INSERT INTO Chests ('Reward', 'PointsToComplete') " +
            $"VALUES ('{chest.Reward}', '{chest.PointsToComplete}');");
    }

    public void UpdateChest(ChestM chest)
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
