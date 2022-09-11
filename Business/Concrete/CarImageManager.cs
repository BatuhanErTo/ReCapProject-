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
            var result = BusinessRules.Run(CheckCarImageCount(carImage.CarId));
            if (result != null)
            {
                return new ErrorResult(Messages.CarImageCountExceeded);
            }
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
        public IResult Update(IFormFile formFile, CarImage carImage)
        {
            carImage.ImagePath = _fileHelper.Update(formFile, PathConstants.ImagesRoot + carImage.ImagePath, PathConstants.ImagesRoot);
            carImage.Date = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImageUpdatedSuccesfully);
        }
        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            var result = BusinessRules.Run(CheckHaveCarImage(carId));
            if (result != null)
            {
                return new ErrorDataResult<List<CarImage>>(GetDefaultCarImage(carId).Data);
            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId));
        }

        public IDataResult<List<CarImage>> GetByImageId(int imageId)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.Id == imageId));
        }

        private IResult CheckCarImageCount(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId);
            if (result.Count >= 5)
            {
                return new ErrorResult();
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

        private IDataResult<List<CarImage>> GetDefaultCarImage(int carId)
        {
            List<CarImage> defaultCarImages = new List<CarImage>();
            defaultCarImages.Add(new CarImage { CarId = carId,Date = DateTime.Now,ImagePath = "DefaultImage.jpg"});
            return new SuccessDataResult<List<CarImage>>(defaultCarImages);
        }

    }
}
