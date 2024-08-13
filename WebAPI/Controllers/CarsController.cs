using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace WebAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase {
        ICarService _carService;

        public CarsController(ICarService carService) {
            _carService = carService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll() {
            var result = _carService.GetAll();
            if (result.Success) {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
        [HttpGet("getalldetails")]
        public IActionResult GetAllWithDetails(string brand = "", string color = "", string startDate = "", string endDate = "") {
            var result = _carService.GetCarsWithDetails(brand, color, startDate, endDate);

            if (result.Success) {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id) {
            var result = _carService.GetById(id);
            if (result.Success) {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
        [HttpGet("getdetailsbyid")]
        public IActionResult GetDetailsById(int id) {
            var result = _carService.GetDetailsById(id);
            if (result.Success) {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
        [HttpGet("getbybrand")]
        public IActionResult GetCarsByBrand(int brandId) {
            var result = _carService.GetCarsByBrandId(brandId);
            if (result.Success) {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
        [HttpGet("getbycolor")]
        public IActionResult GetCarsByColor(int colorId) {
            var result = _carService.GetCarsByColorId(colorId);
            if (result.Success) {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Car car) {
            var result = _carService.Add(car);
            if (result.Success) {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete]
        public IActionResult Delete(int id) {
            var result = _carService.Delete(new Car { Id = id });
            if (result.Success) {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut]
        public IActionResult Put(Car car) {
            var result = _carService.Update(car);
            if (result.Success) {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
