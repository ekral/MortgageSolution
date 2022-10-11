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
        public void EnsureCreated()
        {
            throw new NotImplementedException();
        }

        public Model GetById(int id)
        {
            throw  new NotImplementedException();
        }

        public void Insert(Model model)
        {
            throw new NotImplementedException();
        }

        public void Update(Model model) 
        {
            throw new NotImplementedException();
        }

        public void Delete(Model model) 
        {
            throw new NotImplementedException();
        }
    }
}
