using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zal.Beauty.Base.Models;
using Zal.Beauty.Base.Utils;
using Zal.Beauty.Core.ORM;
using Zal.Beauty.Core.ORM.Identitys;
using Zal.Beauty.Interface.IManager;
using Zal.Beauty.Interface.IManager.Identitys;
using Zal.Beauty.Interface.Models.Parameters;
using Zal.Beauty.Interface.Models.Parameters.Identitys;
using Zal.Beauty.Interface.Models.Results;
using Zal.Beauty.Interface.Models.Results.Identitys;

namespace Zal.Beauty.Core.Managers.Identitys
{
    /// <summary>
    /// 用户管理manager
    /// </summary>
    public class UserManager : IUserManager
    {
        private readonly ApplicationDbContext context;

        public UserManager(ApplicationDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// 根据用户名精确查找用户
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<UserResult> GetUserByExactNameAsync(string name)
        {
            var user = await context.Users.Where(c => c.Name == name).FirstOrDefaultAsync();
            if (user == null) return null;
            return Mapper.Map<UserResult>(user);
        }

        public Task<List<UserResult>> QueryAsync()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<ReturnResult> RegisterAsync(UserParameter user)
        {
            ReturnResult result = new ReturnResult();
            var userEntity = Mapper.Map<User>(user);
            //验证用户名
            user.Name = user.Name?.Trim();
            if (string.IsNullOrEmpty(user.Name))
            {
                result.IsSuccess = false;
                result.Message = "用户名不能为空";
                return result;
            }
            var tmpUser = await GetUserByExactNameAsync(user.Name);
            if(tmpUser != null)
            {
                result.IsSuccess = false;
                result.Message = "用户名不能重复";
                return result;
            }
            //验证密码
            if(userEntity.Password.Length < 6)
            {
                result.IsSuccess = false;
                result.Message = "密码不能小于6位";
                return result;
            }
            userEntity.CreateTime = DateTime.Now;
            userEntity.Password = CommonUtil.MD5(userEntity.Password);
            await context.Users.AddAsync(userEntity);
            await context.SaveChangesAsync();
            result.Id = userEntity.Id;
            return result;
        }
    }
}
