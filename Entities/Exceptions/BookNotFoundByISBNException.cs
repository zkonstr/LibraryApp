using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class BookNotFoundByISBNException : NotFoundException
    {
        public BookNotFoundByISBNException(string ISBN)
        : base($"The book with ISBN: {ISBN} doesn't exist in the database.")
        {
        }
    }
}
