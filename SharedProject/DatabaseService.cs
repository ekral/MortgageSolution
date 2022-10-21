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
        private const string fileName = "database.db";
        private readonly string path;
        private readonly string connectionString;
        
        public DatabaseService()
        {
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            path = Path.Join(folder, fileName);
            
            SqliteConnectionStringBuilder builder = new SqliteConnectionStringBuilder();
            builder.DataSource = path;

            connectionString = builder.ConnectionString;
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

            await command.ExecuteNonQueryAsync();

            return true;
        }

        public async Task<List<Model>> GetAllAsync()
        {
            await using SqliteConnection connection = new SqliteConnection(connectionString);
            await connection.OpenAsync();

            SqliteCommand command = connection.CreateCommand();

            // Dodelat SQL prikaz, ktery vrati Id, LoanAmount, InterestRate, LoanTerm
            // bez pouziti *

            command.CommandText =
            @$"
                SELECT Id, LoanAmount, InterestRate, LoanTerm FROM Mortgage
            ";

            List<Model> models = new List<Model>();

            SqliteDataReader reader = await command.ExecuteReaderAsync();

            if(reader.HasRows)
            {
                while(await reader.ReadAsync())
                {
                    Model model = new Model();

                    model.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                    model.LoanAmount = reader.GetDouble(reader.GetOrdinal("LoanAmount"));
                    model.InterestRate = reader.GetDouble(reader.GetOrdinal("InterestRate"));
                    model.LoanTerm = reader.GetInt32(reader.GetOrdinal("LoanTerm"));
                }
            }
            return models;

        }

        public async Task<Model> GetByIdAsync(int id)
        {
            throw  new NotImplementedException();
        }

        public async Task InsertAsync(Model model)
        {
            await using SqliteConnection connection = new SqliteConnection(connectionString);
            await connection.OpenAsync();

            SqliteCommand command = connection.CreateCommand();

            command.CommandText =
            @$"
                INSERT INTO Mortgage (LoanAmount, InterestRate, LoanTerm)
                VALUES (@LoanAmount, @InterestRate, @LoanTerm)
            ";

            command.Parameters.Add("@LoanAmount", SqliteType.Real).Value = model.LoanAmount;
            command.Parameters.Add("@InterestRate", SqliteType.Real).Value = model.InterestRate;
            command.Parameters.Add("@LoanTerm", SqliteType.Integer).Value = model.LoanTerm;
       
            int count = await command.ExecuteNonQueryAsync();
        }

        public async Task UpdateAsync(Model model) 
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(Model model) 
        {
            throw new NotImplementedException();
        }
    }
}
