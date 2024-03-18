using System;
using System.Collections.Generic;
using System.Data;

public class ProjectController
{
    public List<Project> GetAllProjects()
    {
        DataTable projectsTable = DatabaseManager.GetTable("SELECT * FROM Project");

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
    }

    public void UpdateProject(Project project)
    {
    }

    public void DeleteProject(int projectId)
    {
    }
}
