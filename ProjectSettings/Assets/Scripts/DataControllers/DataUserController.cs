using System.Collections.Generic;

public class DataUserController
{
    public List<User> GetAllUsers()
    {
        // ����� ����� ������������ ������ � ���� ������ ��� ������ �������� ������ ��� ��������� ���� �����
        return new List<User>();
    }

    public void AddUser(User user)
    {
        // ����� ����� �������� ����� ������ � ���� ������ ��� ������ �������� ������
    }

    public void UpdateUser(User user)
    {
        // ����� ����� �������� ���������� � ������ � ���� ������ ��� ������ ��������� ������
    }

    public void DeleteUser(int userId)
    {
        // ����� ����� ������� ������ �� ���� ������ ��� ������� ��������� ������ �� �� ID
    }
}
