namespace SharedProject
{
    public class DatabaseServiceEntityFramework : IDatabaseService
    {
        public Task DeleteAsync(Model model)
        {
            throw new NotImplementedException();
        }

        public Task<List<Model>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Model?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<double> GetLoanAmountAverageAsync()
        {
            throw new NotImplementedException();
        }

        public Task InsertAsync(Model model)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Model model)
        {
            throw new NotImplementedException();
        }
    }
}
