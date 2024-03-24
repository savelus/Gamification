using System;
using System.Collections.Generic;
using System.Data;
using DBUtils;

public class DataChestInScaleController
{
    public List<DataChestInScale> GetAllChestInScales()
    {
        DataTable chestInScalesTable = DatabaseManager.GetTable("SELECT * FROM ChestInScale");

        List<DataChestInScale> chestInScales = new List<DataChestInScale>();

        foreach (DataRow row in chestInScalesTable.Rows)
        {
            DataChestInScale chestInScale = new DataChestInScale
            {
                ID = Convert.ToInt32(row["ID"]),
                ChestId = Convert.ToInt32(row["ChestId"]),
            };

            chestInScales.Add(chestInScale);
        }

        return chestInScales;
    }

    public void AddChestInScale(DataChestInScale chestInScale)
    {
        DatabaseManager.ExecuteQueryWithoutAnswer($"INSERT INTO ChestInScale ('ChestId') " +
            $"VALUES ('{chestInScale.ChestId}');");
    }

    public void UpdateChestInScale(DataChestInScale chestInScale)
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
