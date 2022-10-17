using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedProject
{
    public class DatabaseService
    {
        private const string path = "database.db";
        private readonly string connectionString;

        public DatabaseService()
        {
            SqliteConnectionStringBuilder builder = new SqliteConnectionStringBuilder();
            builder.DataSource = path;

            connectionString = builder.ToString();
        }

        /// <summary>
        /// Verifies that the database exists. And if it does not exist, it creates a new database.
        /// </summary>
        public async Task<bool> EnsureCreatedAsync()
        {
            if (File.Exists(path)) return false;

            await using SqliteConnection connection = new SqliteConnection(connectionString);
            await connection.OpenAsync();

            SqliteCommand command = connection.CreateCommand();
            command.CommandText =
            @"
                CREATE TABLE Mortgage 
                (
                    Id INTEGER PRIMARY KEY, 
                    LoanAmount DOUBLE,
                    InterestRate DOUBLE,
                    LoanTerm INTEGER
                )
            ";

            command.ExecuteNonQuery();

            return true;
        }

        public async Task<List<Model>> GetAll()
        {
            throw new NotImplementedException();

        }

        public async Task<Model> GetByIdAsync(int id)
        {
            throw  new NotImplementedException();
        }

        public async Task InsertAsync(Model model)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Model model) 
        {
            throw new NotImplementedException();
        }

        public void DeleteAsync(Model model) 
        {
            throw new NotImplementedException();
        }
    }
}
