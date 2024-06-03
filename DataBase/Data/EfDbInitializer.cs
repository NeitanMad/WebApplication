namespace DataBase.Data;

public class EfDbInitializer : IDbInitializer
{
    private readonly DataContext _dataContext;

    public EfDbInitializer(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public void InitializeDb()
    {
        _dataContext.Database.EnsureDeleted();
        _dataContext.Database.EnsureCreated();

        _dataContext.AddRange(InitializeDatabaseSeeder.Categories);
        _dataContext.SaveChanges();

        _dataContext.AddRange(InitializeDatabaseSeeder.Storages);
        _dataContext.SaveChanges();

        _dataContext.AddRange(InitializeDatabaseSeeder.Products);
        _dataContext.SaveChanges();

        _dataContext.AddRange(InitializeDatabaseSeeder.ProductsStorages);
        _dataContext.SaveChanges();
    }
}