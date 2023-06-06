using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FYS_SDK.src
{
    public class ApiResponse<T>
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public ApiResponse()
        {
            // Default constructor
        }

        public ApiResponse(int statusCode, string message, T data)
        {
            StatusCode = statusCode;
            Message = message;
            Data = data;
        }

        public bool IsSuccess()
        {
            return StatusCode >= 200 && StatusCode < 300;
        }

        public bool HasData()
        {
            return Data != null;
        }

        public T DeserializeData()
        {
            // Implement deserialization logic here
            // For example, using Newtonsoft.Json:
            return JsonConvert.DeserializeObject<T>(Data.ToString());
        }

        public static ApiResponse<T> FromError(string errorMessage)
        {
            return new ApiResponse<T>
            {
                StatusCode = 500,
                Message = errorMessage
            };
        }
    }

}
