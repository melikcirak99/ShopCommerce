using Microsoft.EntityFrameworkCore;
using ShopCommerce.DataAccessLayer.Abstract;
using ShopCommerce.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopCommerce.DataAccessLayer.EntityFramework
{
    public class EfAdminStatuRepository:EfGenericRepository<AdminStatu>,IAdminStatuDal
    {
        public override IEnumerable<AdminStatu> GetAll()
        {
            return dbset.Include(x => x.Admins).ToList();
        }

        public override IEnumerable<AdminStatu> GetAll(Expression<Func<AdminStatu, bool>> filter)
        {
            return dbset.Include(x => x.Admins).Where(filter).ToList();
        }
    }
}
