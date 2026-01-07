using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class BaseResponse<T>
    {
        public bool Status { get; set; }
        public string Message { get; set; } = default!;
        public T? Data { get; set; }
    }
}
