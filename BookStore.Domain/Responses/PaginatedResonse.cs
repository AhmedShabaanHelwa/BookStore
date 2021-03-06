using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Domain.Responses
{
    public class PaginatedResonse<TEntity> where TEntity : class
    {
        public PaginatedResonse(int pageIndex, int pageSize, long total, IEnumerable<TEntity> data)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            Total = total;
            Data = data;
        }

        public int PageIndex { get; }

        public int PageSize { get; }

        public long Total { get; }

        public IEnumerable<TEntity> Data { get; }
    }
}
