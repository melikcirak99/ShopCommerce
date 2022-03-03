using Microsoft.EntityFrameworkCore;
using ShopCommerce.DataAccessLayer.Abstract;
using ShopCommerce.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ShopCommerce.DataAccessLayer.EntityFramework
{
    public class EfShipStatuRepository : EfGenericRepository<ShipStatu>,IShipStatuDal
    {

    }
}
