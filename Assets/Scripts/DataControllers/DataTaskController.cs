using System;
using System.Collections.Generic;
using System.Data;
using DBUtils;

public class DataTaskController
{
    public List<Task> GetAllTasks()
    {
        DataTable tasksTable = DatabaseManager.GetTable("SELECT * FROM Tasks");

        List<Task> tasks = new List<Task>();

        foreach (DataRow row in tasksTable.Rows)
        {
            Task task = new Task
            {
                ID = Convert.ToInt32(row["ID"]),
                Name = row["Name"].ToString(),
                AssignedUser = row["AssignedUser"].ToString(),
                Estimate = Convert.ToInt32(row["Estimate"]),
                Logged = Convert.ToInt32(row["Logged"]),
                Status = row["Status"].ToString(),
                Reward = row["Reward"].ToString(),
            };

            tasks.Add(task);
        }

        return tasks;
    }

    public void AddTask(Task task)
    {

        DatabaseManager.ExecuteQueryWithoutAnswer($"INSERT INTO Tasks ('Name', 'AssignedUser', 'Estimate', 'Logged', 'Status', 'Reward') " +
            $"VALUES ('{task.Name}', '{task.AssignedUser}', '{task.Estimate}', '{task.Logged}', '{task.Status}', '{task.Reward}');");
    }

    public void UpdateTask(Task task)
    {

        DatabaseManager.ExecuteQueryWithoutAnswer($"UPDATE Tasks " +
            $"SET Name = '{task.Name}' AssignedUser = '{task.AssignedUser}' Estimate = '{task.Estimate}' Logged = '{task.Logged}' Status = '{task.Status}' Reward = '{task.Reward}'" +
            $"WHERE id = {task.ID};");
    }

    public void DeleteTask(int taskId)
    {

        DatabaseManager.ExecuteQueryWithoutAnswer($"DELETE Tasks " +
            $"WHERE id = {taskId};");
    }
}
