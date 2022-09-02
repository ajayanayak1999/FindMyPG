using FindMyPG.Core.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindMyPG.Data
{
    public interface IDbContext
    {
        int SaveChange();

        DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity;
    }
}
