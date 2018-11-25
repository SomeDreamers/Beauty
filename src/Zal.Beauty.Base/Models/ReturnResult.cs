using System;
using System.Collections.Generic;
using System.Text;

namespace Zal.Beauty.Base.Models
{
    /// <summary>
    /// 公共结果对象
    /// </summary>
    public class ReturnResult
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// 信息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 主键ID
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 错误码
        /// </summary>
        public string ErrCode { get; set; }

        public ReturnResult()
        {
            IsSuccess = true;
        }

        public ReturnResult(bool isSuccess, string message, string errCode = "")
        {
            IsSuccess = isSuccess;
            Message = message;
            ErrCode = errCode;
        }
    }

    public class ReturnResult<T>
    {
        public T Data { get; set; }
    }
}
