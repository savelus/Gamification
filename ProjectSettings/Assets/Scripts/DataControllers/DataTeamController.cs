using System.Collections.Generic;

public class DataTeamController 
{
    public List<Team> GetAllTeams()
    {
        // ����� ����� ������������ ������ � ���� ������ ��� ������ �������� ������ ��� ��������� ���� ������
        return new List<Team>();
    }

    public void AddTeam(Team team)
    {
        // ����� ����� �������� ����� ������� � ���� ������ ��� ������ �������� ������
    }

    public void UpdateTeam(Team team)
    {
        // ����� ����� �������� ���������� � ������� � ���� ������ ��� ������ ��������� ������
    }

    public void DeleteTeam(int teamId)
    {
        // ����� ����� ������� ������� �� ���� ������ ��� ������� ��������� ������ �� �� ID
    }
}
