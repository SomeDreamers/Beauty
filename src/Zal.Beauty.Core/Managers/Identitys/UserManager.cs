﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zal.Beauty.Base.Models;
using Zal.Beauty.Base.Utils;
using Zal.Beauty.Core.Common;
using Zal.Beauty.Core.ORM;
using Zal.Beauty.Core.ORM.Identitys;
using Zal.Beauty.Interface.Enums.Identitys;
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
            if (tmpUser != null)
            {
                result.IsSuccess = false;
                result.Message = "用户名不能重复";
                return result;
            }
            //验证密码
            if (userEntity.Password.Length < 6)
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

        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<ReturnResult> UpdateAsync(UserParameter user)
        {
            ReturnResult result = new ReturnResult();
            var userEntity = Mapper.Map<User>(user);
            //验证用户ID
            var oldUser = await context.Users.Where(c => c.Id == user.Id).FirstOrDefaultAsync();
            if(oldUser == null)
            {
                result.IsSuccess = false;
                result.Message = "用户名不存在";
                return result;
            }
            //验证用户名
            user.Name = user.Name?.Trim();
            if (string.IsNullOrEmpty(user.Name))
            {
                result.IsSuccess = false;
                result.Message = "用户名不能为空";
                return result;
            }
            var tmpUser = await GetUserByExactNameAsync(user.Name);
            if (tmpUser != null && tmpUser.Id != user.Id)
            {
                result.IsSuccess = false;
                result.Message = "用户名不能重复";
                return result;
            }
            //更新用户
            oldUser.Name = user.Name;
            oldUser.TrueName = user.TrueName;
            oldUser.Phone = user.Phone;
            oldUser.Mail = user.Mail;
            oldUser.Address = user.Address;
            await context.SaveChangesAsync();
            return result;
        }

        /// <summary>
        /// 根据ID获取用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<UserResult> GetUserByIdAsync(long id)
        {
            var user = await context.Users.Where(c => c.Id == id).FirstOrDefaultAsync();
            return Mapper.Map<UserResult>(user);
        }

        /// <summary>
        /// 获取用户集合
        /// </summary>
        /// <param name="queryParameter"></param>
        /// <returns></returns>
        public async Task<EntitySet<UserResult>> GetUserSetAsync(UserQuery queryParameter)
        {
            var query = context.Users.AsQueryable();
            if (!string.IsNullOrEmpty(queryParameter.Address))
                query = query.Where(c => c.Address.Contains(queryParameter.Address));
            if (queryParameter.CreateBegin != DateTime.MinValue)
                query = query.Where(c => c.CreateTime >= queryParameter.CreateBegin);
            if (queryParameter.CreateEnd != DateTime.MinValue)
                query = query.Where(c => c.CreateTime <= queryParameter.CreateEnd);
            if (!string.IsNullOrEmpty(queryParameter.Mail))
                query = query.Where(c => c.Mail.Contains(queryParameter.Mail));
            if (!string.IsNullOrEmpty(queryParameter.Name))
                query = query.Where(c => c.Name.Contains(queryParameter.Name));
            if (!string.IsNullOrEmpty(queryParameter.Phone))
                query = query.Where(c => c.Phone.Contains(queryParameter.Phone));
            if (Enum.IsDefined(typeof(EUserStatus), queryParameter.Status))
                query = query.Where(c => c.Status == queryParameter.Status);
            if (!string.IsNullOrEmpty(queryParameter.TrueName))
                query = query.Where(c => c.TrueName.Contains(queryParameter.TrueName));
            if (Enum.IsDefined(typeof(EUserType), queryParameter.Type))
                query = query.Where(c => c.Type == queryParameter.Type);
            var userSet = await query.ToEntitySetAsync(queryParameter);
            return Mapper.Map<EntitySet<UserResult>>(userSet);
        }

        /// <summary>
        /// 更新用户状态
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public async Task<ReturnResult> UpdateUserStatusAsync(long id, EUserStatus status)
        {
            ReturnResult result = new ReturnResult();
            //验证状态
            if(!Enum.IsDefined(typeof(EUserStatus), status))
            {
                result.IsSuccess = false;
                result.Message = "状态无效";
                return result;
            }
            //验证用户
            var user = await context.Users.Where(c => c.Id == id).FirstOrDefaultAsync();
            if(user == null)
            {
                result.IsSuccess = false;
                result.Message = "用户已删除";
                return result;
            }
            switch (status)
            {
                case EUserStatus.Enabled:
                    user.Status = EUserStatus.Enabled;
                    break;
                case EUserStatus.Disabled:
                    user.Status = EUserStatus.Disabled;
                    break;
                default:
                    break;
            }
            //更新
            await context.SaveChangesAsync();
            return result;
        }

        /// <summary>
        /// 更新用户类型
        /// </summary>
        /// <param name="id"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public async Task<ReturnResult> UpdateUserTypeAsync(long id, EUserType type)
        {
            ReturnResult result = new ReturnResult();
            //验证类型
            if (!Enum.IsDefined(typeof(EUserType), type))
            {
                result.IsSuccess = false;
                result.Message = "类型无效";
                return result;
            }
            //验证用户
            var user = await context.Users.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (user == null)
            {
                result.IsSuccess = false;
                result.Message = "用户已删除";
                return result;
            }
            switch (type)
            {
                case EUserType.Customer:
                    user.Type = EUserType.Customer;
                    break;
                case EUserType.Admin:
                    user.Type = EUserType.Admin;
                    break;
                default:
                    break;
            }
            //更新
            await context.SaveChangesAsync();
            return result;
        }


        /// <summary>
        /// 根据用户ID获取用户权限keys
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<List<string>> GetPermissionKeysByUserIdAsync(long userId)
        {
            List<string> permissionKeys = new List<string>();
            var roleUsers = await context.RoleUsers.Where(c => c.UserId == userId).ToListAsync();
            foreach (var item in roleUsers)
            {
                //已删除角色舍弃
                var role = await context.Roles.Where(c => c.Id == item.RoleId).FirstOrDefaultAsync();
                if (role == null || role.IsDel) continue;
                //获取角色权限
                var rolePermissions = await context.RolePermissions.Where(c => c.RoleId == role.Id).ToListAsync();
                foreach (var rolePermission in rolePermissions)
                {
                    if (!permissionKeys.Contains(rolePermission.PermissionKey))
                        permissionKeys.Add(rolePermission.PermissionKey);
                }
            }
            return permissionKeys;
        }
    }
}
