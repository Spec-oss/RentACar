﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
     public interface ICarDal
    {
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);
        List<Car> GetById(int CarId);
        List<Car> GetAll();
    }
}
