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
        /// 保存角色请求处理接口
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        Task<ReturnResult> Save(RoleParameter parameter);
    }
}
