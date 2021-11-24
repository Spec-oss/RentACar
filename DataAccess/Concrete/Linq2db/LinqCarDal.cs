using Core.DataAccess.Linq2db;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Linq2db
{
    public class LinqCarDal : LinqEntityRepositoryBase<Car,RentACarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in context.Cars
                             join cl in context.Colors
                             on c.ColorId equals cl.ColorId
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             select new CarDetailDto { CarId = c.CarId, BrandName = b.BrandName, ColorName = cl.ColorName, DailyPrice = c.DailyPrice, Description = c.Description, ModelYear = c.ModelYear };
                return result.ToList();
            }
        }
    }
}
