using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.Dtos
{
    public class BaseResponse<T>
    {
        public bool IsSuccessful { get; set; }
        public string Message { get; set; } = default!;
        public T? Data { get; set; }

        public static BaseResponse<T> Success(T? data, string message)
        {
            return new BaseResponse<T>
            {
                IsSuccessful = true,
                Message = message,
                Data = data,
            };

        }
        public static BaseResponse<T> Failure(string message)
        {
            return new BaseResponse<T>
            {
                IsSuccessful = false,
                Message = message
            };
        }
    }
}
