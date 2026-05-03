namespace SmartCRM.Models {
    public class Sale {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public decimal Amount { get; set; }
        public DateTime SaleDate { get; set; } = DateTime.Now;
    }
}