namespace SmartCRM.Models {
    public class FollowUp {
        public int Id { get; set; }
        public int LeadId { get; set; }
        public Lead Lead { get; set; }
        public DateTime FollowUpDate { get; set; }
        public string Notes { get; set; }
        public string Status { get; set; } = "Pending"; // Pending, Completed
    }
}