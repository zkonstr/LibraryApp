using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Repository.Configuration
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasData
            (
            new Book
            {
                Id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                ISBN = "some ISBN here",
                Title = "DB test adventure book",
                Description = "Book for DB testing",
                Author = "John Doe",
                Genre = "Adventure"

            }
            );
        }

    }
}
