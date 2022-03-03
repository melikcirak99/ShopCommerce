using Microsoft.EntityFrameworkCore;
using ShopCommerce.DataAccessLayer.Abstract;
using ShopCommerce.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ShopCommerce.DataAccessLayer.EntityFramework
{
    public class EfShipRepository : EfGenericRepository<Ship>,IShipDal
    {
        public override Ship Get(int id)
        {
            return dbset.Where(x => x.ShipId.Equals(id))
                .Include(x => x.Adress)
                .Include(x => x.CargoFirm)
                .Include(x => x.Order)
                .Include(x => x.Product)
                .Include(x => x.Seller)
                .Include(x => x.ShipStatu)
                .Include(x => x.User)
                .FirstOrDefault();
        }
        public override Ship Get(Expression<Func<Ship, bool>> filter)
        {
            return dbset
                .Where(filter)
                .Include(x => x.Adress)
                .Include(x => x.CargoFirm)
                .Include(x => x.Order)
                .Include(x => x.Product)
                .Include(x => x.Seller)
                .Include(x => x.ShipStatu)
                .Include(x => x.User)
                .FirstOrDefault();
        }
        public override IEnumerable<Ship> GetAll()
        {
            return dbset
                .Include(x => x.Adress)
                .Include(x => x.CargoFirm)
                .Include(x => x.Order)
                .Include(x => x.Product)
                .Include(x => x.Seller)
                .Include(x => x.ShipStatu)
                .Include(x => x.User)
                .ToList();
        }
        public override IEnumerable<Ship> GetAll(Expression<Func<Ship, bool>> filter)
        {
            return dbset
                .Where(filter)
                .Include(x => x.Adress)
                .Include(x => x.CargoFirm)
                .Include(x => x.Order)
                .Include(x => x.Product)
                .Include(x => x.Seller)
                .Include(x => x.ShipStatu)
                .Include(x => x.User)
                .ToList();
        }
    }
}
