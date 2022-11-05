namespace OrdersDomain.Core.Aggregates.Entities.Orders
{
    public class LineItem
    {
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public int Quantity { get; set; }
        public int BaseAmount { get; set; }

        public decimal TaxAmount { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
