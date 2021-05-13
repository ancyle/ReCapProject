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
    public class CarsController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet("cars")]
        public IActionResult Cars()
        {
            var result = _carService.GetAll();
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("get-car")]
        public IActionResult GetCar(int id)
        {
            var result = _carService.GetCar(id);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("car-details")]
        public IActionResult CarDetails()
        {
            var result = _carService.GetCarDetails();
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("get-car-by-color-id")]
        public IActionResult GetCarsByColorId(int id)
        {
            var result = _carService.GetCarsByBrandId(id);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("get-car-by-brand-id")]
        public IActionResult GetCarsByBrandId(int id)
        {
            var result = _carService.GetCarsByColorId(id);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Car car)
        {
            var result = _carService.Add(car);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
    }
}
