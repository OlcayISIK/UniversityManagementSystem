using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.Client.Core.Enums;

namespace UMS.Client.Dtos.Shared
{
    public class Result<T>
    {
        public T Data { get; set; }
        public bool Success { get; set; }
        public ErrorCode ErrorCode { get; set; }

        public static Result<T> CreateSuccessResult(T data)
        {
            return new Result<T>
            {
                Data = data,
                Success = true
            };
        }

        public static Result<T> CreateErrorResult(ErrorCode errorCode)
        {
            return new Result<T>
            {
                ErrorCode = errorCode
            };
        }

    }
}
