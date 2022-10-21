using SharedProject;

DatabaseService databaseService = new DatabaseService();

if(await databaseService.EnsureCreatedAsync())
{
    await databaseService.InsertAsync(new Model(8000000.0, 6.0, 30));
    await databaseService.InsertAsync(new Model(4000000.0, 5.7, 20));
    await databaseService.InsertAsync(new Model(10800000.0, 5.8, 15));
}


await databaseService.UpdateAsync(new Model(4800000.0, 5.6, 15) { Id = 1 });

List<Model> models = await databaseService.GetAllAsync();

foreach (Model model in models)
{
    Console.WriteLine($"{model.Id, 3} {model.LoanAmount, 16:C1} {model.InterestRate, 4:F1} {model.LoanTerm, 3}");
}


