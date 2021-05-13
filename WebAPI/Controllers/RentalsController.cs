using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        private readonly IRentalService _rentalService;

        public RentalsController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpPost("add")]
        public IActionResult Add(Rental rental)
        {
            var result = _rentalService.Add(rental);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("get-all-rentals")]
        public IActionResult GetAllRentals()
        {
            var result = _rentalService.GetAllRentals();
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("get-rental-by-return-date")]
        public IActionResult GetRentalByReturnDate(DateTime date)
        {
            //search query by ?date=yyyy-mm-ddT00:00:00
            var result = _rentalService.GetRental(date);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("get-rentals-by-car-id")]
        public IActionResult GetRentalById(int id)
        {
            var result = _rentalService.GetRentalsByCarId(id);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
    }
}
