using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using Sber.Fitness.DTOs;

namespace Sber.Fitness.Controllers
{
    /// <summary>
    /// TODO - � �� ���� ������ �� �������� Swagger, �������� ����������!
    /// </summary>
    /// 
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        // ������ ����������� � ���� ������
        string connectionString = "Host=baasu.db.elephantsql.com;Username=aksntwgd;Password=LXyur9Gkj8BnVAJOuoWsNGhOSMR9V86f;Database=aksntwgd";

        /// <summary>
        /// �������� ������ �������������
        /// </summary>
        public IEnumerable<User> Get(string filter)
        {
            try
            {
                // �������� ������� �����������
                var connection = new NpgsqlConnection(connectionString);

                // �������� �����������
                connection.Open();

                // ������� ��� ������� ������
                string sql = "SELECT * FROM users";
                if (filter != null)
                {
                    sql += $" WHERE firstname LIKE '%{filter}%'";
                }
                var command = new NpgsqlCommand(sql, connection);

                // ���������� ������� � ��������� ������
                var reader = command.ExecuteReader();

                var users = new List<User>();
                while (reader.Read())
                {
                    users.Add(new User { Id = reader.GetInt32(0), Name = reader.GetString(1) });
                }

                connection.Close();
                return users;
            }
            catch (Exception ex)
            {
                // ���-�� ����� �� ��� 
                System.IO.File.AppendAllText("c:\\temp\\errors.log", "������ ��� ������ ������ �� ��: " + ex.Message);
                throw ex;
            }
        }
    }
}
