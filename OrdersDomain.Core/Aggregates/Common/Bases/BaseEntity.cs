using System.ComponentModel.DataAnnotations;

namespace OrdersDomain.Core.Aggregates.Entities.Bases
{
    public abstract class BaseEntity
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString("N");
    }
}
