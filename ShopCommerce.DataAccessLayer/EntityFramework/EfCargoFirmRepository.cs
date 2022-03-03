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
    public class EfCargoFirmRepository : EfGenericRepository<CargoFirm>,ICargoFirmDal
    {
        public override IEnumerable<CargoFirm> GetAll()
        {
            return dbset.ToList();
        }

        public override IEnumerable<CargoFirm> GetAll(Expression<Func<CargoFirm, bool>> filter)
        {
            return dbset.Where(filter).ToList();
        }
    }
}
