using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zal.Beauty.Base.Models;
using Zal.Beauty.Interface.Models.Parameters.Identitys;
using Zal.Beauty.Interface.Models.Results.Identitys;

namespace Zal.Beauty.Interface.IManager.Identitys
{
    /// <summary>
    /// 用户角色管理接口
    /// </summary>
    public interface IRoleManager
    {
        /// <summary>
        /// 获取角色列表
        /// </summary>
        /// <returns></returns>
        Task<List<RoleResult>> GetRolesAsync();

        /// <summary>
        /// 获取角色列表(包含角色用户信息)
        /// </summary>
        /// <returns></returns>
        Task<List<RoleInfoResult>> GetRoleInfosAsync();

        /// <summary>
        /// 根据角色ID获取用户信息
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        Task<List<UserResult>> GetUsersOfRoleAsync(long roleId);

        /// <summary>
        /// 保存角色请求处理接口
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        Task<ReturnResult> SaveAsync(RoleParameter parameter);

        /// <summary>
        /// 根据ID获取角色信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<RoleResult> GetRoleByIdAsync(long id);

        /// <summary>
        /// 根据ID删除角色信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ReturnResult> DeleteByIdAsync(long id);

        /// <summary>
        /// 从角色中移除用户
        /// </summary>
        /// <returns></returns>
        Task<ReturnResult> RemoveUserOfRoleAsync(long roleId, long userId);

        /// <summary>
        /// 为角色添加用户
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<ReturnResult> AddUserOfRoleAsync(long roleId, long userId);
    }
}
