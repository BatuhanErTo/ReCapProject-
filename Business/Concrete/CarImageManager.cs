using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        IFileHelper _fileHelper;
        public CarImageManager(ICarImageDal carImageDal,IFileHelper fileHelper)
        {
            _carImageDal = carImageDal;
            _fileHelper = fileHelper;
        }

        public IResult Add(IFormFile formFile, CarImage carImage)
        {
            BusinessRules.Run(CheckCarImageCount(carImage.CarId));
            carImage.ImagePath = _fileHelper.Add(formFile, PathConstants.ImagesRoot);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.SuccessUploadOfCarImage);
        }

        public IResult Delete(CarImage carImage)
        {
            _fileHelper.Delete(PathConstants.ImagesRoot+carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImageDeletedSuccessfully);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            _carImageDal.GetAll();
            return new SuccessDataResult<List<CarImage>>();
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId));
        }


        public IResult Update(IFormFile formFile, CarImage carImage)
        {
            carImage.ImagePath = _fileHelper.Update(formFile,PathConstants.ImagesRoot+carImage.ImagePath,PathConstants.ImagesRoot);
            carImage.Date = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImageUpdatedSuccesfully);
            // after the update operations carId become 0.Solve that.
        }

        private IResult CheckCarImageCount(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result > 5)
            {
                return new ErrorResult(Messages.CarImageCountExceeded);
            }
            return new SuccessResult();
        }

        private IResult CheckHaveCarImage(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result > 0)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }
    }
}
