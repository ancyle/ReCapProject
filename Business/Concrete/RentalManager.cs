using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            var result = _rentalDal.Get(x=>x.CarId==1&&x.ReturnDate==null||(x.ReturnDate>DateTime.Now));
            if (result!=null) return new ErrorResult(Messages.RentalFailures);
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.Success);
        }

        public IDataResult<List<Rental>> GetAllRentals()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(),Messages.Success);
        }

        public IDataResult<Rental> GetRental(DateTime returnDate)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(x=>x.ReturnDate==returnDate),Messages.Success);
        }

        public IDataResult<List<Rental>> GetRentalsByCarId(int id)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(x=>x.CarId==id),Messages.Success);
        }
    }
}
