using System;
using System.Collections.Generic;
using System.Data;
using DBUtils;

public class DataTaskInScaleController
{
    public List<TaskInScale> GetAllTaskInScales()
    {
        DataTable chestInScalesTable = DatabaseManager.GetTable("SELECT * FROM TaskInScales");

        List<TaskInScale> taskInScales = new List<TaskInScale>();

        foreach (DataRow row in chestInScalesTable.Rows)
        {
            TaskInScale taskInScale = new TaskInScale
            {
                ID = Convert.ToInt32(row["ID"]),
                TaskId = Convert.ToInt32(row["TaskId"]),
            };

            taskInScales.Add(taskInScale);
        }

        return taskInScales;
    }

    public void AddTaskInScale(TaskInScale taskInScale)
    {
        DatabaseManager.ExecuteQueryWithoutAnswer($"INSERT INTO TaskInScales ('TaskId') " +
            $"VALUES ('{taskInScale.TaskId}');");
    }

    public void UpdateTaskInScale(TaskInScale taskInScale)
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
