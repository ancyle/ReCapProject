using System;
using System.Collections.Generic;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CarImageManager:ICarImageService
    {
        private readonly ICarImageDal _carImageDal;
        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        //[ValidationAspect(typeof(CarImageValidator))]
        public IResult Add( CarImage carImage)
        {
            BusinessRules.Run(CheckIfImageOverLimit(carImage.CarId));
            carImage.Date=DateTime.Now.Date;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.Success);
        }

        public IResult Delete(CarImage carImage)
        {
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.Success);
        }

        public IDataResult<List<CarImage>> GetAllCarImages()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<CarImage> GetCarImage(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(x => x.Id == id),Messages.Success);
        }

        public IDataResult<List<CarImage>> GetCarImageByCarId(int carId)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(x => x.CarId == carId), Messages.Success);
        }

        public IResult Modify(CarImage carImage)
        {
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.Success);
        }

        private IResult CheckIfImageOverLimit(int id)
        {
            var result = _carImageDal.GetAll(x => x.CarId == id).Count;
            if (result >= 5) return new ErrorResult(Messages.Failed);
            return new SuccessResult();
        }
    }
}
