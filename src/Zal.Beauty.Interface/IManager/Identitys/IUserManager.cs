using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zal.Beauty.Base.Models;
using Zal.Beauty.Interface.Enums.Identitys;
using Zal.Beauty.Interface.Models.Parameters.Identitys;
using Zal.Beauty.Interface.Models.Results.Identitys;

namespace Zal.Beauty.Interface.IManager.Identitys
{
    /// <summary>
    /// 用户管理接口
    /// </summary>
    public interface IUserManager
    {
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
        Task<UserResult> GetUserByExactNameAsync(string name);

        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<ReturnResult> RegisterAsync(UserParameter user);

        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<ReturnResult> UpdateAsync(UserParameter user);

        /// <summary>
        /// 根据ID获取用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<UserResult> GetUserByIdAsync(long id);

        /// <summary>
        /// 获取用户集合
        /// </summary>
        /// <param name="queryParameter"></param>
        /// <returns></returns>
        Task<EntitySet<UserResult>> GetUserSetAsync(UserQuery queryParameter);

        /// <summary>
        /// 更新用户状态
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        Task<ReturnResult> UpdateUserStatusAsync(long id, EUserStatus status);

        /// <summary>
        /// 更新用户类型
        /// </summary>
        /// <param name="id"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        Task<ReturnResult> UpdateUserTypeAsync(long id, EUserType type);

        /// <summary>
        /// 根据用户ID获取用户权限keys
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<List<string>> GetPermissionKeysByUserIdAsync(long userId);
    }
}
