using System.Collections.Generic;

public class DataTeamController 
{
    public List<Team> GetAllTeams()
    {
        // Здесь можно использовать запрос к базе данных или другой источник данных для получения всех команд
        return new List<Team>();
    }

    public void AddTeam(Team team)
    {
        // Здесь можно добавить новую команду в базу данных или другой источник данных
    }

    public void UpdateTeam(Team team)
    {
        // Здесь можно обновить информацию о команде в базе данных или другом источнике данных
    }

    public void DeleteTeam(int teamId)
    {
        // Здесь можно удалить команду из базы данных или другого источника данных по ее ID
    }
}
