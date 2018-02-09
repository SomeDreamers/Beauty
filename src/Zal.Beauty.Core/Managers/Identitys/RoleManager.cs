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
        public RoleManager(ApplicationDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// 获取角色列表
        /// </summary>
        /// <returns></returns>
        public async Task<List<RoleResult>> GetRolesAsync()
        {
            var roles = await context.Roles.OrderBy(c => c.Id).ToListAsync();
            return Mapper.Map<List<RoleResult>>(roles);
        }

        /// <summary>
        /// 保存角色请求处理接口
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public async Task<ReturnResult> Save(RoleParameter parameter)
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
    }
}
