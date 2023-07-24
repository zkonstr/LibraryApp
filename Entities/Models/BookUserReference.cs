using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class BookUserReference
    {
        [Column("BookUserReferenceId")]
        public Guid Id { get; set; }

        [ForeignKey(nameof(Book))]
        public Guid BookId { get; set; }
        public Book? Book { get; set; }

        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }
        public User? User { get; set; }
        public DateTime? OrderDate { get; set; }
    }
}
