﻿using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("getbyid")]
        public IActionResult GetById(int id) {
            var result = _carService.GetById(id);
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
