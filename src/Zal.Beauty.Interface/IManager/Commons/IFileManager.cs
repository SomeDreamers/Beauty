using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zal.Beauty.Base.Models;
using Zal.Beauty.Interface.Models.Parameters.Commons;

namespace Zal.Beauty.Interface.IManager.Commons
{
    /// <summary>
    /// 素材分类管理接口
    /// </summary>
    public interface IFileManager
    {
        /// <summary>
        ///创建素材分类
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        Task<ReturnResult> AddTagAsync(String name, int weight);
    }
}
