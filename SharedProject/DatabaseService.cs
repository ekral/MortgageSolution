using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedProject
{
    public class DatabaseService
    {
        private const string Path = "database.db";

        /// <summary>
        /// Verifies that the database exists. And if it does not exist, it creates a new database.
        /// </summary>
        public async Task EnsureCreatedAsync()
        {
            throw new NotImplementedException();
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
