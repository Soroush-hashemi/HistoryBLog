using System;

namespace TestBlog.Services.DTOs.Users
{
    public class LoginUserDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string UserEmail { get; set; }
    }
}
