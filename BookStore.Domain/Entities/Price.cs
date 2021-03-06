using System;

namespace BookStore.Domain.Entities
{
    public class Price
    {
        /// <summary>
        /// Price amount
        /// </summary>
        public decimal Amount { get; set; }
        /// <summary>
        /// Price currency
        /// </summary>
        public string Currency { get; set; }

        public static Price operator +(Price a, Price b)
        {
            if (a.Currency != b.Currency)
                throw new InvalidOperationException("Cannot perform arithmetic on Money of two different types.");

            return new Price { Amount = a.Amount + b.Amount, Currency = a.Currency };
        }

        public static Price operator *(Price a, int b)
        {
            return new Price { Amount = a.Amount * b, Currency = a.Currency };
        }
    }
}