using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.DTOs;
using Core.Utilities.Results;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;
using Core.Aspects.Autofac.Validation;
using Core.Aspects.Autofac.Caching;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Insert(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }
        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarListed);
        }
        [CacheAspect]
        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == brandId),Messages.CarListed);
        }
        [CacheAspect]
        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == colorId),Messages.CarListed);
        }
        [CacheAspect]
        public IDataResult<Car> GetCarsById(int Id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(p => p.Id == Id), Messages.CarListed);
        }

        [CacheAspect]
        public IDataResult<List<CarDetailsDto>> GetCarsDetails()
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetCarDetails(),Messages.CarListed);
        }
        [CacheAspect]
        public IDataResult<List<CarDetailsDto>> GetCarDetailsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetCarDetails(b => b.BrandId == brandId));
        }
        [CacheAspect]
        public IDataResult<List<CarDetailsDto>> GetCarDetailsByColorId(int colorId)
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetCarDetails(c => c.ColorId == colorId));
        }
        [CacheAspect]
        public IDataResult<CarDetailsDto> GetCarsDetailsByCarId(int carId)
        {
            return new SuccessDataResult<CarDetailsDto>(_carDal.GetCarDetails(c => c.CarId == carId).SingleOrDefault());
        }
        [CacheAspect]
        public IDataResult<List<CarDetailsDto>> GetCarDetailsByBothColorBrandId(int colorId, int brandId)
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetCarDetails(c => c.ColorId == colorId && c.BrandId == brandId));
        }
    }

}
