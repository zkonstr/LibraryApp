using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record UserForUpdateDTO
        (string Username, string Password, string Email, string Name, string SurName,
        IEnumerable<BookUserReferenceForCreationDTO>? BookUserReferences);
}
