using System;
using System.Collections.Generic;
using System.Data;
using DBUtils;

public class DataChestInScaleController
{
    public List<ChestInScale> GetAllChestInScales()
    {
        DataTable chestInScalesTable = DatabaseManager.GetTable("SELECT * FROM ChestInScale");

        List<ChestInScale> chestInScales = new List<ChestInScale>();

        foreach (DataRow row in chestInScalesTable.Rows)
        {
            ChestInScale chestInScale = new ChestInScale
            {
                ID = Convert.ToInt32(row["ID"]),
                ChestId = Convert.ToInt32(row["ChestId"]),
            };

            chestInScales.Add(chestInScale);
        }

        return chestInScales;
    }

    public void AddChestInScale(ChestInScale chestInScale)
    {
        DatabaseManager.ExecuteQueryWithoutAnswer($"INSERT INTO ChestInScale ('ChestId') " +
            $"VALUES ('{chestInScale.ChestId}');");
    }

    public void UpdateChestInScale(ChestInScale chestInScale)
    {
        DatabaseManager.ExecuteQueryWithoutAnswer($"UPDATE ChestInScale " +
            $"SET ChestId = '{chestInScale.ChestId}'" +
            $"WHERE id = {chestInScale.ID};");
    }

    public void DeleteChestInScale(int chestInScaleId)
    {
        DatabaseManager.ExecuteQueryWithoutAnswer($"DELETE ChestInScale " +
            $"WHERE id = {chestInScaleId};");
    }
}
