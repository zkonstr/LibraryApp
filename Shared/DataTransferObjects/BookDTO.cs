﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record BookDTO
    {
        public Guid Id { get; set; }
        public string? ISBN { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Author { get; set; }
        public string? Genre { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? ExpiredDate { get; set; }
        public Guid OwnerId { get; set; }
    }
}
