using System;
using System.Collections.Generic;
using System.Text;

namespace Crowdfund_TeamProject.Core
{
   public class ApiResult<T>
    {
        public StatusCode ErrorCode { get; set; }

        public string ErrorText { get; set; }

        public T Data { get; set; }

        public bool Success => ErrorCode == StatusCode.OK;

        public ApiResult()
        {

        }

        public ApiResult(StatusCode errorCode, string errorMsg)
        {
            ErrorCode = errorCode;
            ErrorText = errorMsg;
        }

        public ApiResult<U> GetApi<U>()
        {

            return new ApiResult<U>()
            {
                ErrorCode = ErrorCode,
                ErrorText = ErrorText
            };
        }

        public static ApiResult<T> CreateSuccess(T data)
        {
            return new ApiResult<T>()
            {
                ErrorCode = StatusCode.OK,
                ErrorText = "OK",
                Data = data
            };

        }




    }
}
