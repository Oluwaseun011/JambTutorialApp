using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class UserDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string UserName { get; set; } = default!;
        public string HashPassword { get; set; } = default!;
        public string Salt { get; set; } = default!;
        public string Role { get; set; } = default!;
    }

    public class LoginRequestModel
    {
        public string UserName { get; set; } = default!;
        public string Password { get; set; } = default!;
    }

    public class LoginResponseModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string UserName { get; set; } = default!;
        public string Role { get; set; } = default!;
    }
}
