using System;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Zaolazi.EntityFramework.Core.Extensions
{
    public class DbSetEntension
    {
        public async Task SaveAsync(this DbSet<TEntity> dbSet) 
        {
            
        }
    }
}
