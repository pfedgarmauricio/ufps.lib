namespace Library.Services.Entities.Base;

public abstract class BaseEntity
{
    public Guid ID { get; set; }
    public DateTime CreatedAtUTC { get; set; }
    public DateTime? UpdatedAtUTC { get; set; }
    public bool IsDeleted { get; set; }

    protected BaseEntity() { }

    protected BaseEntity(Guid id)
    {
        ID = id;
        CreatedAtUTC = DateTime.UtcNow;
        IsDeleted = false;
    }

    public void MarkAsUpdated()
    {
        UpdatedAtUTC = DateTime.UtcNow;
    }

    public void SoftDelete()
    {
        IsDeleted = true;
        MarkAsUpdated();
    }

    public void Restore()
    {
        IsDeleted = false;
        MarkAsUpdated();
    }
}
