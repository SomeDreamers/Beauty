using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zal.Beauty.Interface.Models.Parameters;
using Zal.Beauty.Interface.Models.Results;

namespace Zal.Beauty.Interface.IManager
{
    /// <summary>
    /// 用户管理接口
    /// </summary>
    public interface IUserManager
    {
        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task CreateAsync(UserParameter user);

        /// <summary>
        /// 查
        /// </summary>
        /// <returns></returns>
        Task<List<UserResult>> QueryAsync();

        /// <summary>
        /// 根据用户名获取用户
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<UserResult> GetUserByNameAsync(string name);

        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task RegisterAsync(UserParameter user);
    }
}
