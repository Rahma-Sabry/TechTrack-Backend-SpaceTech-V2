using System;
using System.Collections.Generic;
using System.Text;

namespace TechTrack.Domain.DTOs.User
{
    public class UserCreateDto
    {
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
