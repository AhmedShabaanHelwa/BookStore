using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Domain.Repository
{
    /// <summary>
    /// Interface for repository pattern
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// UnitOfWork property
        /// </summary>
        public IUnitOfWork UnitOfWork { get; }
    }
}
