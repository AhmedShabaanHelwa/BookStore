using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookStore.Domain.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
    }
}
