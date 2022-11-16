namespace _221031_Lesson.Models
{
    public class ProductPhoto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }

    }
}
