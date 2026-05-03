namespace SmartCRM.Models {
    public class Lead {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public string Status { get; set; } = "New"; // New, InProgress, Converted, Lost
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}