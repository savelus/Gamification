using System;
using System.Collections.Generic;
using System.Data;
using DBUtils;

public class DataTaskInScaleController
{
    public List<DataTaskInScale> GetAllTaskInScales()
    {
        DataTable chestInScalesTable = DatabaseManager.GetTable("SELECT * FROM TaskInScales");

        List<DataTaskInScale> taskInScales = new List<DataTaskInScale>();

        foreach (DataRow row in chestInScalesTable.Rows)
        {
            DataTaskInScale taskInScale = new DataTaskInScale
            {
                ID = Convert.ToInt32(row["ID"]),
                TaskId = Convert.ToInt32(row["TaskId"]),
            };

            taskInScales.Add(taskInScale);
        }

        return taskInScales;
    }

    public void AddTaskInScale(DataTaskInScale taskInScale)
    {
        DatabaseManager.ExecuteQueryWithoutAnswer($"INSERT INTO TaskInScales ('TaskId') " +
            $"VALUES ('{taskInScale.TaskId}');");
    }

    public void UpdateTaskInScale(DataTaskInScale taskInScale)
    {
        DatabaseManager.ExecuteQueryWithoutAnswer($"UPDATE TaskInScales " +
            $"SET TaskId = '{taskInScale.TaskId}'" +
            $"WHERE id = {taskInScale.ID};");
    }

    public void DeleteTaskInScale(int taskInScaleId)
    {
        DatabaseManager.ExecuteQueryWithoutAnswer($"DELETE TaskInScales " +
            $"WHERE id = {taskInScaleId};");
    }
}
