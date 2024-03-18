using System.Collections.Generic;

public class DataUserController
{
    public List<User> GetAllUsers()
    {
        // Здесь можно использовать запрос к базе данных или другой источник данных для получения всех задач
        return new List<User>();
    }

    public void AddUser(User user)
    {
        // Здесь можно добавить новую задачу в базу данных или другой источник данных
    }

    public void UpdateUser(User user)
    {
        // Здесь можно обновить информацию о задаче в базе данных или другом источнике данных
    }

    public void DeleteUser(int userId)
    {
        // Здесь можно удалить задачу из базы данных или другого источника данных по ее ID
    }
}
