namespace OrdersDomain.Core.Aggregates.Entities.Bases
{
    public abstract class BaseEntity
    {
        string Id { get; set; } = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
    }
}
