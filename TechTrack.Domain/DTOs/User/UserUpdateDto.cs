using System;
using System.Collections.Generic;
using System.Text;

namespace TechTrack.Domain.DTOs.User
{
    public class UserUpdateDto
    {
        // Required fields for update
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;

        // Optional: only update if provided
        public string? Password { get; set; }
    }
}
