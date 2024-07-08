namespace Core.Persistence.Repositories;

public class Entity
{
    public int Id { get; set; }
    public bool IsDeleted { get; set; }
    public bool IsActive => !IsDeleted;
    public DateTime CreatedTime { get; set; }
    public DateTime UpdatedTime { get; set; }

    public Entity()
    {
        CreatedTime = DateTime.UtcNow;
        UpdatedTime = DateTime.UtcNow;
    }

    public Entity(int id) : this()
    {
        Id = id;
    }
}