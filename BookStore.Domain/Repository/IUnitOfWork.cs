using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookStore.Domain.Repository
{
    /// <summary>
    /// Interface of Unit of Work pattern that is used for effective save of changes in data sources.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Effectively saves changed from memory collection to data base.
        /// </summary>
        /// <param name="cancellationToken">Allows to stop pending async operations</param>
        /// <returns></returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Interface for the DbContext SaveEntitiesAsync method.
        /// </summary>
        /// <param name="cancellationToken">Allows to stop pending async operations</param>
        /// <returns></returns>
        Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
