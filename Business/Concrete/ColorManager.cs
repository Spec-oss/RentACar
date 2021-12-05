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
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Color color)
        {
            _colorDal.Add(color);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Color color)
        {
            _colorDal.GetAll(cl => cl.ColorId == color.ColorId);
            _colorDal.Delete(color);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<Color> FindById(int id)
        {
            Color color = new Color();
            if (_colorDal.GetAll().Any(cl => cl.ColorId == id))
            {
                color = _colorDal.GetAll().FirstOrDefault(cl => cl.ColorId == id);
            }
            else Console.WriteLine("No such color was found.");
            return new SuccessDataResult<Color>(color);
        }

        public IDataResult<Color> Get(Color color)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(cl => cl.ColorId == color.ColorId));
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll());
        }

        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new SuccessResult(Messages.Updated);
        }
    }
}
