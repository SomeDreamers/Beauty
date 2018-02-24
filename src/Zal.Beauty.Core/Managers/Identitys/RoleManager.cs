using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zal.Beauty.Base.Models;
using Zal.Beauty.Core.ORM.Identitys;
using Zal.Beauty.Interface.IManager.Identitys;
using Zal.Beauty.Interface.Models.Parameters.Identitys;
using Zal.Beauty.Interface.Models.Results.Identitys;

namespace Zal.Beauty.Core.Managers.Identitys
{
    /// <summary>
    /// 用户角色manager
    /// </summary>
    public class RoleManager : IRoleManager
    {
        private readonly ApplicationDbContext context;
        private readonly IUserManager userManager;
        public RoleManager(ApplicationDbContext context, IUserManager userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        /// <summary>
        /// 获取角色列表
        /// </summary>
        /// <returns></returns>
        public async Task<List<RoleResult>> GetRolesAsync()
        {
            var roles = await context.Roles.Where(c=>c.IsDel == false).OrderBy(c => c.Id).ToListAsync();
            return Mapper.Map<List<RoleResult>>(roles);
        }

        /// <summary>
        /// 获取角色列表(包含角色用户信息)
        /// </summary>
        /// <returns></returns>
        public async Task<List<RoleInfoResult>> GetRoleInfosAsync()
        {
            var roles = await context.Roles.Where(c => c.IsDel == false).OrderBy(c => c.Id).ToListAsync();
            var infos = Mapper.Map<List<RoleInfoResult>>(roles);
            foreach (var item in infos)
            {
                item.Users = await GetUsersOfRoleAsync(item.Id);
            }
            return infos;
        }

        /// <summary>
        /// 根据角色ID获取用户信息
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public async Task<List<UserResult>> GetUsersOfRoleAsync(long roleId)
        {
            var roleUsers = await context.RoleUsers.Where(c => c.RoleId == roleId).ToListAsync();
            List<UserResult> users = new List<UserResult>();
            foreach (var item in roleUsers)
            {
                users.Add(await userManager.GetUserByIdAsync(item.UserId));
            }
            return users;
        }

        /// <summary>
        /// 保存角色请求处理接口
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public async Task<ReturnResult> SaveAsync(RoleParameter parameter)
        {
            ReturnResult result = new ReturnResult();
            var role = Mapper.Map<Role>(parameter);
            //新建角色
            if (role.Id <= 0)
            {
                role.Name = role.Name?.Trim();
                //验证角色名
                if (string.IsNullOrEmpty(role.Name))
                {
                    result.IsSuccess = false;
                    result.Message = "角色名不能为空";
                    return result;
                }
                var tmpRole = await context.Roles.Where(c => c.Name == role.Name && c.IsDel == false).FirstOrDefaultAsync();
                if (tmpRole != null)
                {
                    result.IsSuccess = false;
                    result.Message = "角色名重复";
                    return result;
                }
                //创建
                context.Roles.Add(role);
                await context.SaveChangesAsync();
            }
            //编辑角色
            else
            {
                var oldRole = await context.Roles.Where(c => c.Id == role.Id).FirstOrDefaultAsync();
                //验证角色ID
                if(oldRole == null || oldRole.IsDel)
                {
                    result.IsSuccess = false;
                    result.Message = "角色已删除";
                    return result;
                }
                //验证角色名
                role.Name = role.Name?.Trim();
                if (string.IsNullOrEmpty(role.Name))
                {
                    result.IsSuccess = false;
                    result.Message = "角色名不能为空";
                    return result;
                }
                var tmpRole = await context.Roles.Where(c => c.Name == role.Name && c.IsDel == false).FirstOrDefaultAsync();
                if(tmpRole != null && tmpRole.Id != oldRole.Id)
                {
                    result.IsSuccess = false;
                    result.Message = "角色名重复";
                    return result;
                }
                //更新角色
                oldRole.Name = role.Name;
                oldRole.Memo = role.Memo;
                await context.SaveChangesAsync();
            }
            return result;
        }

        /// <summary>
        /// 根据ID获取角色信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<RoleResult> GetRoleByIdAsync(long id)
        {
            var role = await context.Roles.Where(c => c.Id == id).FirstOrDefaultAsync();
            return Mapper.Map<RoleResult>(role);
        }

        /// <summary>
        /// 根据ID删除角色信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ReturnResult> DeleteByIdAsync(long id)
        {
            var result = new ReturnResult();
            //验证角色是否存在
            var role = await context.Roles.Where(c => c.Id == id).FirstOrDefaultAsync();
            if(role == null || role.IsDel)
            {
                result.IsSuccess = false;
                result.Message = "角色已被删除";
                return result;
            }
            //验证角色下是否包含用户
            var count = await context.RoleUsers.Where(c => c.RoleId == id).CountAsync();
            if(count > 0)
            {
                result.IsSuccess = false;
                result.Message = "角色下包含用户，不能被删除";
                return result;
            }
            //更新角色位已删除
            role.IsDel = true;
            await context.SaveChangesAsync();
            return result;
        }

        /// <summary>
        /// 从角色中移除用户
        /// </summary>
        /// <returns></returns>
        public async Task<ReturnResult> RemoveUserOfRoleAsync(long roleId, long userId)
        {
            var result = new ReturnResult();
            //验证用户是否属于该角色
            var roleUser = await context.RoleUsers.Where(c => c.RoleId == roleId && c.UserId == userId).FirstOrDefaultAsync();
            if(roleUser == null)
            {
                result.IsSuccess = false;
                result.Message = "用户不属于该角色";
                return result;
            }
            //删除记录
            context.RoleUsers.Remove(roleUser);
            await context.SaveChangesAsync();
            return result;
        }

        /// <summary>
        /// 为角色添加用户
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<ReturnResult> AddUserOfRoleAsync(long roleId, long userId)
        {
            var result = new ReturnResult();
            //验证角色是否存在
            var role = await context.Roles.Where(c => c.Id == roleId).FirstOrDefaultAsync();
            if (role == null || role.IsDel)
            {
                result.IsSuccess = false;
                result.Message = "角色已被删除";
                return result;
            }
            //验证用户是否存在
            var user = await context.Users.Where(c => c.Id == userId).FirstOrDefaultAsync();
            if (user == null)
            {
                result.IsSuccess = false;
                result.Message = "用户不存在";
                return result;
            }
            //用户已属于该角色
            var roleUser = await context.RoleUsers.Where(c => c.RoleId == roleId && c.UserId == userId).FirstOrDefaultAsync();
            if (roleUser != null)
            {
                return result;
            }
            //添加记录
            context.RoleUsers.Add(new RoleUser { RoleId = roleId, UserId = userId });
            await context.SaveChangesAsync();
            return result;
        }
    }
}
