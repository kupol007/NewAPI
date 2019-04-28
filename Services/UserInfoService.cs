using Npgsql;
using System;
using System.Threading.Tasks;
using Dapper;
using NewAPI.Models;
using NewAPI.Services.Interfaces;

namespace NewAPI.Services
{
    public class UserInfoService : IUserInfoService
    {
        private const string ConnectionString =
            "host=89.208.199.118; port=5432; database=PostgreSQL-2564; username=student; password=password";
        public async Task<User> GetById(Guid id)
        {
            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                return await connection.QuerySingleAsync<User>(
                    "SELECT * FROM \"vakhramoff\".\"Contacts\" WHERE id = @id", new { id });
            }
        }/*
        public async Task<User> GetById(Guid id)
        {
            User user = new User
            {
                Email = "test@test.ru",
                Id = id,
                NickName = "test",
                Phone = "+7 987 654 32 10"
            };

            return await Task.FromResult<User>(user);
        } */
        public async void AppendUser(User user)
        {
            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                string query = "INSERT INTO \"vakhramoff\".\"Contacts\" (id, email, nickname, phone, position) VALUES (@id, @email, @nickname, @phone, @position)";

                await connection.ExecuteAsync(query, user);
            }
        }
    }

}