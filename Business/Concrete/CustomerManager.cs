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
    public class CustomerManager:ICustomerService
    {
        ICustomerDal _customerDal;
        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult Add(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Customer customer)
        {
            _customerDal.GetAll(cs => cs.CustomerId == customer.CustomerId);
            _customerDal.Delete(customer);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<Customer> FindByID(int id)
        {
            Customer customer = new Customer();
            if (_customerDal.GetAll().Any(cs=> cs.CustomerId==id))
            {
                customer = _customerDal.GetAll().FirstOrDefault(cs => cs.CustomerId == id);
            }
            else Console.WriteLine(Messages.CustomerNotExist);
            return new SuccessDataResult<Customer>(customer);
        }

        public IDataResult<Customer> Get(Customer customer)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(cs => cs.CustomerId == customer.CustomerId));
        }

        public IDataResult<List<Customer>> GetAll()
        { 
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll());
        }

        public IDataResult<CustomerDetailDto> GetCustomerDetailByMail(string mail)
        {
            return new SuccessDataResult<CustomerDetailDto>(_customerDal.GetCustomerDetails().Where(cs => cs.Email == mail).FirstOrDefault());
        }

        public IDataResult<List<CustomerDetailDto>> GetCustomerDetails()
        {
            return new SuccessDataResult<List<CustomerDetailDto>>(_customerDal.GetCustomerDetails());
        }

        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult(Messages.Updated);
        }
    }
}
