using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using Sber.Fitness.DTOs;

namespace Sber.Fitness.Controllers
{
    /// <summary>
    /// TODO - Я не знаю почему не работает Swagger, почините пожалуйста!
    /// </summary>
    /// 
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        // Строка подключения к базе данных
        string connectionString = "Host=baasu.db.elephantsql.com;Username=aksntwgd;Password=LXyur9Gkj8BnVAJOuoWsNGhOSMR9V86f;Database=aksntwgd";

        /// <summary>
        /// Получить список пользователей
        /// </summary>
        public IEnumerable<User> Get(string filter)
        {
            try
            {
                // Создание объекта подключения
                var connection = new NpgsqlConnection(connectionString);

                // Открытие подключения
                connection.Open();

                // Команда для выборки данных
                string sql = "SELECT * FROM users";
                if (filter != null)
                {
                    sql += $" WHERE firstname LIKE '%{filter}%'";
                }
                var command = new NpgsqlCommand(sql, connection);

                // Выполнение команды и получение данных
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
                // Что-то пошло не так 
                System.IO.File.AppendAllText("c:\\temp\\errors.log", "Ошибка при чтении данных из БД: " + ex.Message);
                throw ex;
            }
        }
    }
}
