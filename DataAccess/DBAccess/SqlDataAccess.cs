using DataAccess.DBAccess.Utils;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

namespace DataAccess.DBAccess
{
    public class SqlDataAccess : ISqlDataAccess
    {
        private readonly IConfiguration config;

        public SqlDataAccess(IConfiguration config)
        {
            this.config = config;
        }

        public async Task DeleteSingle<P>(string sql, P parameters, string connectionId = "Default")
        {
            using MySqlConnection mySqlConnection = new MySqlConnection(config.GetConnectionString(connectionId));
            mySqlConnection.Open();
            var cmd = new MySqlCommand();
            cmd.Connection = mySqlConnection;
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.StoredProcedure;
            var props = typeof(P).GetProperties().ToList();
            var p = typeof(P);
            foreach (var property in props)
            {
                var propName = property.Name;
                var propValue = property.GetValue(parameters);
                cmd.Parameters.AddWithValue(propName, propValue);
            }

            await cmd.ExecuteNonQueryAsync();
        }

        public async Task<List<T>> LoadData<T, P>(string sql, P parameters, string connectionId = "Default") where T : class, new()
        {
            using MySqlConnection mySqlConnection = new MySqlConnection(config.GetConnectionString(connectionId));
            mySqlConnection.Open();
            var cmd = new MySqlCommand();
            cmd.Connection = mySqlConnection;
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.StoredProcedure;
            var props = typeof(P).GetProperties().ToList();
            foreach (var property in props)
            {
                var propName = property.Name;
                var propValue = property.GetValue(parameters);
                cmd.Parameters.AddWithValue(propName, propValue);
            }

            var reader = await cmd.ExecuteReaderAsync();

            var list = new List<T>();

            while (reader.Read())
            {
                var item = reader.MapDataToObject<T>();
                list.Add(item);
            }

            return list;


        }

        public async Task<int> SaveData<T>(string sql, T data, string connectionId = "Default")
        {
            using MySqlConnection mySqlConnection = new MySqlConnection(config.GetConnectionString(connectionId));
            mySqlConnection.Open();
            var cmd = new MySqlCommand();
            cmd.Connection = mySqlConnection;
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.StoredProcedure;
            var props = typeof(T).GetProperties().ToList();
            foreach (var property in props)
            {
                var propName = property.Name;
                var propValue = property.GetValue(data);
                cmd.Parameters.AddWithValue(propName, propValue);
            }

            int result = 0;
            var reader = await cmd.ExecuteReaderAsync();

            while (reader.Read())
            {
                result = Convert.ToInt32(reader[0]);
            }

            return result;
            //return (int)cmd.LastInsertedId;

        }

        public async Task<T> Single<T, P>(string sql, P parameters, string connectionId = "Default") where T : class, new()
        {
            using MySqlConnection mySqlConnection = new MySqlConnection(config.GetConnectionString(connectionId));
            mySqlConnection.Open();
            var cmd = new MySqlCommand();
            cmd.Connection = mySqlConnection;
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.StoredProcedure;
            var props = typeof(P).GetProperties().ToList();
            foreach (var property in props)
            {
                var propName = property.Name;
                var propValue = property.GetValue(parameters);
                cmd.Parameters.AddWithValue(propName, propValue);
            }

            var reader = await cmd.ExecuteReaderAsync();

            var item = new T();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    item = reader.MapDataToObject<T>();
                }
            } else
            {
                return null;
            }
            return item;

        }

        public async Task<int> UpdateData<T>(string sql, T data, string connectionId = "Default")
        {
            using MySqlConnection mySqlConnection = new MySqlConnection(config.GetConnectionString(connectionId));
            mySqlConnection.Open();
            var cmd = new MySqlCommand();
            cmd.Connection = mySqlConnection;
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.StoredProcedure;
            var props = typeof(T).GetProperties().ToList();
            foreach (var property in props)
            {
                var propName = property.Name;
                var propValue = property.GetValue(data);
                cmd.Parameters.AddWithValue(propName, propValue);
            }

            var result = await cmd.ExecuteNonQueryAsync();
            return result;
        }
    }
}
