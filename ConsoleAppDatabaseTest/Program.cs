using SharedProject;

DatabaseService databaseService = new DatabaseService();

if(await databaseService.EnsureCreatedAsync())
{
    await databaseService.InsertAsync(new Model(8000000.0, 6.0, 30));
    await databaseService.InsertAsync(new Model(4000000.0, 5.7, 20));
    await databaseService.InsertAsync(new Model(10800000.0, 5.8, 15));
}

// await databaseService.DeleteAsync(new Model() { Id = 3 });

Model? zmena = await databaseService.GetByIdAsync(2);

if (zmena is not null)
{
    zmena.LoanAmount = 4600000.0;
    zmena.InterestRate = 5.0;
    zmena.LoanTerm = 5;

    await databaseService.UpdateAsync(zmena);
}

double average = await databaseService.GetLoanAmountAverageAsync();

Console.WriteLine($"Loan Amount Average: {average:C1}");

List<Model> models = await databaseService.GetAllAsync();

foreach (Model model in models)
{
    Console.WriteLine($"{model.Id, 3} {model.LoanAmount, 16:C1} {model.InterestRate, 4:F1} {model.LoanTerm, 3}");
}


