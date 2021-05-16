using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IResult Add(CarImage carImage);
        IResult Modify(CarImage carImage);
        IResult Delete(CarImage carImage);
        IDataResult<List<CarImage>> GetAllCarImages();
        IDataResult<CarImage> GetCarImage(int id);
        IDataResult<List<CarImage>> GetCarImageByCarId(int carId);
    }
}
