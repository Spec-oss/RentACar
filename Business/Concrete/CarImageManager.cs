using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;


        public CarImageManager(ICarImageDal carimageDal)
        {
            _carImageDal = carimageDal;
        }
        //[ValidationAspect(typeof(CarImageValidator))]
        //[CacheRemoveAspect("ICarImageService.Get")]
        public IResult Add(CarImage carImage, IFormFile file)
        {
            var result = BusinessRules.Run(CheckCarImageCount(carImage.CarId));

            if (result != null)
            {
                return result;
            }

            carImage.Date = DateTime.Now;
            carImage.ImagePath = FileOperationsHelper.AddFile(file);

            _carImageDal.Add(carImage);

            return new SuccessResult();
        }


        //[SecuredOperation("admin,carimage.delete")]
        //[CacheRemoveAspect("ICarImageService.Get")]
        public IResult Delete(CarImage carImage)
        {
            var image = _carImageDal.Get(c => c.PhotoId == carImage.PhotoId);

            if (image == null)
            {
                return new ErrorResult();
            }

            FileOperationsHelper.DeleteFile(image.ImagePath);

            _carImageDal.Delete(carImage);

            return new SuccessResult();
        }


        //[SecuredOperation("admin,carimage.update")]
        //ValidationAspect(typeof(CarImageValidator))]
        //[CacheRemoveAspect("ICarImageService.Get")]
        public IResult Update(CarImage carImage, IFormFile file)
        {
            var oldImage = _carImageDal.Get(c => c.PhotoId == carImage.PhotoId);

            if (oldImage == null)
            {
                return new ErrorResult();
            }

            carImage.Date = DateTime.Now;
            carImage.ImagePath = FileOperationsHelper.UpdateFile(file, oldImage.ImagePath);

            _carImageDal.Update(carImage);

            return new SuccessResult();
        }


        //[CacheAspect]
        //[PerformanceAspect(5)]
        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }


        //[CacheAspect]
        //[PerformanceAspect(5)]
        public IDataResult<CarImage> GetById(int carImageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(ci => ci.PhotoId == carImageId));
        }


        // Business Rules Methods
        private IResult CheckCarImageCount(int carId)
        {
            if (_carImageDal.GetAll(ci => ci.CarId == carId).Count >= 5)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
    }
}
