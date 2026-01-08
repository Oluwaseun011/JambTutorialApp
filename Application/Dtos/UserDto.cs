using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class LoginRequestModel
    {
        public string UserName { get; set; } = default!;
        public string Password { get; set; } = default!;
    }

    public class LoginResponseModel
    {
        public Guid Id { get; set; }
        public string UserName { get; set; } = default!;
        public string Role { get; set; } = default!;
    }
}
