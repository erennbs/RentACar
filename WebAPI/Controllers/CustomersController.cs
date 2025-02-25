﻿using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase {
        ICustomerService _customerService;

        public CustomersController(ICustomerService customerService) {
            _customerService = customerService;
        }

        [HttpGet]
        public IActionResult GetAll() {
            var result = _customerService.GetAll();
            if (result.Success) {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Customer customer) {
            var result = _customerService.Add(customer);
            if (result.Success) {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut]
        public IActionResult Update(Customer customer) {
            var result = _customerService.Update(customer);
            if (result.Success) {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete]
        public IActionResult Delete(int id) {
            var result = _customerService.Delete(new Customer { Id = id });
            if (result.Success) {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
