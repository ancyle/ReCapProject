using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Business.Abstract;
using Core.Utilities.Helpers;
using Entities.Concrete;
using Microsoft.AspNetCore.Hosting;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        private readonly ICarImageService _carImageService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IFileHelper _file;

        public CarImagesController(IFileHelper file,ICarImageService carImageService,IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            _carImageService = carImageService;
            _file=file;
        }
        [HttpPost("add")]
        public IActionResult Add([FromForm] CarImage carImage, IFormFile file)
        {
            var imageResult = _file.Upload(file, _webHostEnvironment.WebRootPath + "\\uploads\\");
            if (imageResult.IsFaulted||imageResult.IsCanceled) return BadRequest(imageResult.Result.Message);
            carImage.ImagePath = imageResult.Result.Message;
            var result = _carImageService.Add(carImage);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(IFormFile file, [FromForm] CarImage carImage)
        {
            var imageResult = _file.Update(file, carImage.ImagePath, _webHostEnvironment.WebRootPath + "\\uploads\\");
            if (!imageResult.Success) return BadRequest(imageResult);
            carImage.ImagePath = imageResult.Message;
            var result = _carImageService.Modify(carImage);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("getone")]
        public IActionResult GetOne(int id)
        {
            var result = _carImageService.GetCarImage(id);
            if (result.Data.ImagePath == null || !System.IO.File.Exists(result.Data.ImagePath))
                result.Data.ImagePath = _webHostEnvironment.WebRootPath + "\\uploads\\" + "default.jpg";
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
    }
}
