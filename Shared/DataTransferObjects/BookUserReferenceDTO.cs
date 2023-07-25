using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record BookUserReferenceDTO
    {
        public Guid Id { get; init; }
        public Guid BookId { get; init; }
        public Guid UserId { get; init; }
        public DateTime? OrderDate { get; init; }
    }
}
