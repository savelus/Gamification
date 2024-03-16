using System;
using System.Collections.Generic;
using System.Data;
using DBUtils;

public class ProjectController
{
    public List<Project> GetAllProjects()
    {
        DataTable projectsTable = DatabaseManager.GetTable("SELECT * FROM Projects");

        List<Project> projects = new List<Project>();

        foreach (DataRow row in projectsTable.Rows)
        {
            Project project = new Project
            {
                ID = Convert.ToInt32(row["ID"]),
                Name = row["Name"].ToString(),
                ScaleId = Convert.ToInt32(row["ScaleId"]),
                TeamId = Convert.ToInt32(row["TeamId"]),
            };

            projects.Add(project);
        }

        return projects;
    }

    public void AddProject(Project project)
    {
        DatabaseManager.ExecuteQueryWithoutAnswer($"INSERT INTO Projects ('Name', 'ScaleId', 'TeamId') " +
            $"VALUES ('{project.Name}', '{project.ScaleId}', '{project.TeamId}');");
    }

    public void UpdateProject(Project project)
    { 
        DatabaseManager.ExecuteQueryWithoutAnswer($"UPDATE Projects " +
            $"SET Name = '{project.Name}' ScaleId = {project.ScaleId} TeamId = {project.TeamId} " +
            $"WHERE id = {project.ID};");
    }

    public void DeleteProject(int projectId)
    {
        DatabaseManager.ExecuteQueryWithoutAnswer($"DELETE Projects " +
            $"WHERE id = {projectId};");
    }
}