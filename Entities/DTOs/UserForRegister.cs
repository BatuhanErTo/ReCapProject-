﻿using Core;

namespace Entities.DTOs
{
    public class UserForRegister : IDto
    {
        public string FirtName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
