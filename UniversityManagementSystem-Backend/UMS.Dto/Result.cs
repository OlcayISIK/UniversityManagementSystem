using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.Core.Enums;

namespace UMS.Dto
{
    public class Result<T>
    {
        public Result()
        {

        }

        public T Data { get; set; }
        public object ErrorData { get; set; }
        public bool Success { get; set; }
        public ErrorCode ErrorCode { get; set; }

        public static Result<T> CreateSuccessResult(T data)
        {
            return new Result<T>
            {
                Data = data,
                Success = true,
            };
        }

        public static Result<T> CreateErrorResult(ErrorCode errorCode, object data = default)
        {
            return new Result<T>
            {
                ErrorCode = errorCode,
                ErrorData = data
            };
        }
    }
}
