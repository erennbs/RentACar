using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase {
        IRentalService _rentalService;

        public RentalsController(IRentalService rentalService) {
            _rentalService = rentalService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll() {
            var result = _rentalService.GetAll();
            if (result.Success) {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
        [HttpGet("getalldetails")]
        public IActionResult GetAllWithDetails() {
            var result = _rentalService.GetAllWithDetails();
            if (result.Success) {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
        [HttpGet("getavailabledate")]
        public IActionResult GetAvailablaDate(int carId) {
            var result = _rentalService.GetAvailableDate(carId);
            if (result.Success) {
                return Ok(result);
            }
            return BadRequest(result);
        }



        [HttpPost("add")]
        public IActionResult Add(Rental rental) {
            var result = _rentalService.Add(rental);
            if (result.Success) {
                return Ok(result);
            }
            return NotFound(result);
        }

        [HttpPut]
        public IActionResult Update(Rental rental) {
            var result = _rentalService.Update(rental);
            if (result.Success) {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete]
        public IActionResult Delete(int id) {
            var result = _rentalService.Delete(new Rental { Id = id });
            if (result.Success) {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
