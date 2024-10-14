namespace Store.Data.Entites.OrderEntityies
{
    public class OrderItem : BaseEntity<Guid>

    {
        public decimal Price { get; set; }
        public int Quntity { get; set; }
        public Guid OrderId { get; set; }
        public string ProductName { get; set; }
        public int ProductId { get; set; }
        public string PictureUrl { get; set; }
    }
}