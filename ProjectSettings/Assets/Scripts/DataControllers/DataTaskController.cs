using System.Collections.Generic;

public class DataTaskController
{
    public List<Task> GetAllTasks()
    {
        // Здесь можно использовать запрос к базе данных или другой источник данных для получения всех задач
        return new List<Task>();
    }

    public void AddTask(Task task)
    {
        // Здесь можно добавить новую задачу в базу данных или другой источник данных
    }

    public void UpdateTask(Task task)
    {
        // Здесь можно обновить информацию о задаче в базе данных или другом источнике данных
    }

    public void DeleteTask(int taskId)
    {
        // Здесь можно удалить задачу из базы данных или другого источника данных по ее ID
    }
}
