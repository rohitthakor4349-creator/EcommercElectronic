namespace Ecommerce.Model
{
    public class CartDTO
    {
        public int CartId { get; set; }
        public int UniqId { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Qty { get; set; }
        public DateTime EntryDate { get; set; }

    }
}
