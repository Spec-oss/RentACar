using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BrandManager:IBrandService
    {
        IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand brand)
        {
            _brandDal.Add(brand);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Brand brand)
        {
            _brandDal.GetAll(b=>b.BrandId == brand.BrandId);
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<Brand> FindById(int id)
        {
            Brand brand = new Brand();
            if (_brandDal.GetAll().Any(b => b.BrandId == id))
            {
                brand = _brandDal.GetAll().FirstOrDefault(b => b.BrandId == id);
            }
            else Console.WriteLine("No such brand was found.");
            return new SuccessDataResult<Brand>(brand);
        }

        public IDataResult<Brand> Get(Brand brand)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(b => b.BrandId == brand.BrandId));
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll());
        }

        public IDataResult<List<Brand>> GeyById(int brandId)
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(b => b.BrandId == brandId));
        }

        public IResult Update(Brand brand)
        {
            _brandDal.Update(brand);
            return new SuccessResult(Messages.Updated);
        }
    }
}
