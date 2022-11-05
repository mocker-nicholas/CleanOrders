using OrdersDomain.Core.Aggregates.Entities.Bases;
using OrdersDomain.Core.Interfaces;

namespace OrdersDomain.Core.Aggregates.Entities.Accounts
{
    public class Account : BaseEntity, IDateCreateable, IAuditable
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime DateCreated { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime DateModified { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
