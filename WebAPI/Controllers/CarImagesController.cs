using Business.Abstract;
using Entities.Concrete;
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
        public IActionResult Upload(int carId, IFormFile file) {
            var result = _carImageService.Add(carId, file);
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
        public IActionResult Update(int id, IFormFile file) {
            var result = _carImageService.Update(id, file);
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
    }
}
