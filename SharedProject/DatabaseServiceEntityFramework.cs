using Microsoft.EntityFrameworkCore;

namespace SharedProject;

public class DatabaseServiceEntityFramework : IDatabaseService
{
    public Task<bool> EnsureCreatedAsync()
    {
        using MortgagesContext db = new();
        return db.Database.EnsureCreatedAsync();
    }

    public Task<double> GetLoanAmountAverageAsync()
    {
        using MortgagesContext db = new();
        return db.Mortgages.AverageAsync(m => m.LoanAmount);
    }

    public Task<Model?> GetByIdAsync(int id)
    {
        using MortgagesContext db = new();
        return db.Mortgages.Where(m => m.Id == id).FirstOrDefaultAsync();
    }

    public Task<List<Model>> GetAllAsync()
    {
        using MortgagesContext db = new();
        return db.Mortgages.ToListAsync();
    }

    public async Task InsertAsync(Model model)
    {
        await using MortgagesContext db = new();
        db.Mortgages.Add(model);
        await db.SaveChangesAsync();
    }

    public async Task UpdateAsync(Model model)
    {
        await using MortgagesContext db = new();
        db.Mortgages.Update(model);
        await db.SaveChangesAsync();
    }

    public async Task DeleteAsync(Model model)
    {
        await using MortgagesContext db = new();
        db.Mortgages.Remove(model);
        await db.SaveChangesAsync();
    }
}