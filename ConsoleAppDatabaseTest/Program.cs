using SharedProject;

DatabaseService databaseService = new DatabaseService();

if(await databaseService.EnsureCreatedAsync())
{
    await databaseService.InsertAsync(new Model(8000000.0, 6.0, 30));
    await databaseService.InsertAsync(new Model(4000000.0, 5.7, 20));
    await databaseService.InsertAsync(new Model(10800000.0, 5.8, 15));
}


