namespace SharedProject
{
    public interface IDatabaseService
    {
        Task DeleteAsync(Model model);
        Task<List<Model>> GetAllAsync();
        Task<Model?> GetByIdAsync(int id);
        Task<double> GetLoanAmountAverageAsync();
        Task InsertAsync(Model model);
        Task UpdateAsync(Model model);
    }
}