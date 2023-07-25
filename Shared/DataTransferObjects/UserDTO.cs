using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record UserDTO()
    {
        public Guid Id { get; init; }
        public string? Username { get; init; }
        public string? Password { get; init; }
        public string? Email { get; init; }
        public string? Name { get; init; }
        public string? Surname { get; init; }
    }
}
