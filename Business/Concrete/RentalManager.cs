using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager:IRentalService
    {
        IRentalDal _rentalDal;
        ICarService _carService;
        ICustomerService _customerService;

        public RentalManager(IRentalDal rentalDal, ICarService carService, ICustomerService customerService)
        {
            _rentalDal = rentalDal;
            _carService = carService;
            _customerService = customerService;
        }

        public IResult Add(Rental rental)
        {
            if (rental.ReturnDate == null)
            {
                return new ErrorResult(Messages.CarNotAvailable);
            }
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.GetAll(rn => rn.RentalId == rental.RentalId);
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<Rental> FindByID(int id)
        {
            Rental rental = new Rental();
            if (_rentalDal.GetAll().Any(r=>r.RentalId==id))
            {
                rental = _rentalDal.GetAll().FirstOrDefault(r => r.RentalId == r.RentalId);
            }
            else Console.WriteLine("Bulunamadı!");
            return new SuccessDataResult<Rental>(rental);
        }

        public IDataResult<Rental> Get(Rental rental)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.RentalId == rental.RentalId));
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.Updated);
        }

        public IResult CheckIfFindeks(int carId, int customerId)
        {
            var customer = _customerService.FindByID(customerId).Data;
            var car = _carService.FindByID(carId).Data;
            if (customer.Findex < car.MinFindex)
            {
                return new ErrorResult(Messages.NotEngouhFindex);
            }
            return new SuccessResult(Messages.EngouhFindex);
        }
    }
}
