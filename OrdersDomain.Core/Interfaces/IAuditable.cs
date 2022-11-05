namespace OrdersDomain.Core.Interfaces
{
    public interface IAuditable
    {
        DateTime DateModified { get; set; }
    }
}
