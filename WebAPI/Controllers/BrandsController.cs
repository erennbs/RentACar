﻿using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase {

        IBrandService _brandService;

        public BrandsController(IBrandService brandService) {
            _brandService = brandService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll() {
            var result = _brandService.GetAll();
            if (result.Success) {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Brand brand) {
            var result = _brandService.Add(brand);
            if (result.Success) {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut]
        public IActionResult Update(Brand brand) {
            var result = _brandService.Update(brand);
            if (result.Success) {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete]
        public IActionResult Delete(int id) {
            var result = _brandService.Delete(new Brand { Id = id });
            if (result.Success) {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
