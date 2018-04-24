using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zal.Beauty.Base.Models;
using Zal.Beauty.Interface.Models.Parameters.Commons;
using Zal.Beauty.Interface.Models.Results.Commons;

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

        /// <summary>
        /// 上传素材
        /// </summary>
        /// <returns></returns>
       Task AddFileAsync(FileParameter file);
        /// <summary>
        /// 获取全部素材分类
        /// </summary>
        /// <returns></returns>
        Task<List<TagResult>> GetTagAllAsync();
        /// <summary>
        /// 根据素材分类ID获取全部素材
        /// </summary>
        /// <returns></returns>
        Task<EntitySet<FileResult>> GetAllFileAsync(long tagId,int page);
        /// <summary>
        /// 根据OSSkey判断文件是否存在
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<int> GetFileCountByOssKey(String key);
        /// <summary>
        /// 更新素材创建时间
        /// </summary>
        /// <returns></returns>
        Task UpdateTime(String osskey);
        /// <summary>
        /// 修改素材名称
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        Task ModifyFileName(long id, String name);
        /// <summary>
        /// 删除素材
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteFile(long id);
    }
}
