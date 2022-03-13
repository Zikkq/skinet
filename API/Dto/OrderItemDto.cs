namespace API.Dto
{
    public sealed class OrderItemDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string PcitureUrl { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}