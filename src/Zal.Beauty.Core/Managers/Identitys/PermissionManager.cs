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
    /// 权限管理manager
    /// </summary>
    public class PermissionManager : IPermissionManager
    {
        private readonly ApplicationDbContext context;
        public PermissionManager(ApplicationDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// 根据角色ID获取权限信息
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public async Task<List<RolePermissionResult>> GetPermissionsByRoleIdAsync(long roleId)
        {
            var rolePermissions = await context.RolePermissions.Where(c => c.RoleId == roleId).ToListAsync();
            return Mapper.Map<List<RolePermissionResult>>(rolePermissions);
        }

        /// <summary>
        /// 更新角色权限
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<ReturnResult> UpdateRolePermissionsAsync(long roleId, List<string> permissionKeys)
        {
            ReturnResult result = new ReturnResult();
            //验证角色ID
            var role = await context.Roles.Where(c => c.Id == roleId).FirstOrDefaultAsync();
            if(role == null || role.IsDel)
            {
                result.IsSuccess = false;
                result.Message = "角色已被删除";
                return result;
            }
            //获取角色原有权限
            var rolePermissions = await context.RolePermissions.Where(c => c.RoleId == roleId).ToListAsync();
            //记录删除的权限
            List<RolePermission> delRolePermissions = new List<RolePermission>();
            foreach (var item in rolePermissions)
            {
                if (!permissionKeys.Contains(item.PermissionKey))
                    delRolePermissions.Add(item);
            }
            //记录新增的权限
            List<RolePermission> newRolePermissions = new List<RolePermission>();
            foreach (var item in permissionKeys)
            {
                if (rolePermissions.Find(c => c.PermissionKey == item) == null)
                    newRolePermissions.Add(new RolePermission { RoleId = roleId, PermissionKey = item });
            }
            //删除之前的权限
            context.RolePermissions.RemoveRange(delRolePermissions);
            //记录新增的权限
            context.RolePermissions.AddRange(newRolePermissions);
            await context.SaveChangesAsync();
            return result;
        }
    }
}
