using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IResult Add(Rental rental);
        IDataResult<List<Rental>> GetAllRentals();
        IDataResult<List<Rental>> GetRentalsByCarId(int id);
        IDataResult<Rental> GetRental(DateTime returnDate);
    }
}
