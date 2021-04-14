namespace BookStore.Domain.Entities
{
    public class Price : BaseEntity
    {
        /// <summary>
        /// Price amount
        /// </summary>
        public decimal Amount { get; set; }
        /// <summary>
        /// Price currency
        /// </summary>
        public string Currency { get; set; }
    }
}