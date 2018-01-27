using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zal.Beauty.Core.ORM;
using Zal.Beauty.Interface.IManager;
using Zal.Beauty.Interface.Models.Parameters;
using Zal.Beauty.Interface.Models.Results;

namespace Zal.Beauty.Core.Managers
{
    /// <summary>
    /// 用户管理manager
    /// </summary>
    public class UserManager : IUserManager
    {
        public Task CreateAsync(UserParameter user)
        {
            throw new NotImplementedException();
        }

        public Task<UserResult> GetUserByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserResult>> QueryAsync()
        {
            throw new NotImplementedException();
        }

        public Task RegisterAsync(UserParameter user)
        {
            throw new NotImplementedException();
        }
    }
}
