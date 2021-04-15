using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Domain.Responses
{
    public class PriceResponse
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
