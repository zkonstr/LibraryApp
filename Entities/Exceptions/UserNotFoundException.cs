﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class UserNotFoundException : NotFoundException
    {
        public UserNotFoundException(Guid Id)
        : base($"The user with id: {Id} doesn't exist in the database.")
        {
        }
    }
}
