using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class BookNotFoundException : NotFoundException
    {
        public BookNotFoundException(Guid Id)
        : base($"The book with id: {Id} doesn't exist in the database.")
        {
        }
    }
}
