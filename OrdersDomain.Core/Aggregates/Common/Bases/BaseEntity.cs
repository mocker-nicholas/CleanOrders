using System.ComponentModel.DataAnnotations;

namespace OrdersDomain.Core.Aggregates.Entities.Bases
{
    public abstract class BaseEntity
    {
        [Key]
        public string Id { get; set; } = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
    }
}
