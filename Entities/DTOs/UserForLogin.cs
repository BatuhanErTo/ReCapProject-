﻿using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class UserForLogin : IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
