using System;
using System.Collections.Generic;
using System.Data;
using DBUtils;

public class DataScaleController
{
    public List<Scale> GetAllScales()
    {
        DataTable scalesTable = DatabaseManager.GetTable("SELECT * FROM Scales");

        List<Scale> scales = new List<Scale>();

        foreach (DataRow row in scalesTable.Rows)
        {
            Scale chestInScale = new Scale
            {
                ID = Convert.ToInt32(row["ID"]),
                ChestInScaleId = Convert.ToInt32(row["ChestInScaleId"]),
                TaskInScale = Convert.ToInt32(row["TaskInScale"]),
                AllPoints = Convert.ToInt32(row["AllPoints"]),
                CompletePoints = Convert.ToInt32(row["CompletePoints"]),
            };

            scales.Add(chestInScale);
        }

        return scales;
    }

    public void AddChestInScale(Scale scale)
    {
        DatabaseManager.ExecuteQueryWithoutAnswer($"INSERT INTO Scales ('ChestInScaleId', 'TaskInScale', 'AllPoints', 'CompletePoints') " +
            $"VALUES ('{scale.ChestInScaleId}', '{scale.TaskInScale}', '{scale.AllPoints}', '{scale.CompletePoints}');");
    }

    public void UpdateChestInScale(Scale scale)
    {
        DatabaseManager.ExecuteQueryWithoutAnswer($"UPDATE Scales " +
            $"SET ChestInScaleId = '{scale.ChestInScaleId}' TaskInScale = '{scale.TaskInScale}' AllPoints = '{scale.AllPoints}' CompletePoints = '{scale.CompletePoints}'" +
            $"WHERE id = {scale.ID};");
    }

    public void DeleteChestInScale(int scaleId)
    {
        DatabaseManager.ExecuteQueryWithoutAnswer($"DELETE Scales " +
            $"WHERE id = {scaleId};");
    }
}
