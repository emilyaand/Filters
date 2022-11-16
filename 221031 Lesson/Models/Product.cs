namespace _221031_Lesson.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public string PhotoName { get; set; }
        public int Quantity { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public string Description { get; set; }
        public int Weight { get; set; }
        public int Dimension { get; set; }
        public List<ProductPhoto> ProductPhoto { get; set; }

        public PurchaseStatus Status {get; set; }
    }
    public enum PurchaseStatus
    {
        Sold, 
        New, 
        Sale,
    }
}
