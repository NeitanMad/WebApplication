namespace DataBase.Repositories.DTOModels;

public abstract class BaseModelDTO
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
}