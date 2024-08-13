using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase {

        private readonly ICarImageService _carImageService;

        public CarImagesController(ICarImageService carImageService) {
            _carImageService = carImageService;
        }

        [HttpPost("upload")]
        public IActionResult Upload(CarImageRequestParams reqParams) {
            CarImage carImage = new CarImage { CarId = reqParams.CarId, Date = DateTime.Now};
            var result = _carImageService.Add(carImage, reqParams.File);
            if (result.Success) {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbycarid")]
        public IActionResult Get(int carId) {
            var result = _carImageService.GetImagesByCarId(carId);
            if (result.Success) {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("update")]
        public IActionResult Update(CarImage carImage, IFormFile file) {
            var result = _carImageService.Update(carImage, file);
            if (result.Success) {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete]
        public IActionResult Delete(int id) {
            var result = _carImageService.Delete(id);
            if (result.Success) {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
        [HttpDelete("deletebycarid")]
        public IActionResult DeleteByCarId(int carId) {
            var result = _carImageService.DeleteByCarId(carId);
            if (result.Success) {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
