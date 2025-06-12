using Application.Interfaces.UnitOfWork;
using Infrastructure.Persistense.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistense.UnitOfWork
{
    public class UnitOfWork(AppDbContext context) : IUnitOfWork
    {
        public async Task<int> SaveChangesAsync()
        {
             return await context.SaveChangesAsync();
        }
    }
}
