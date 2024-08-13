﻿using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase {
        private IPaymentService _paymentService;
        public PaymentsController(IPaymentService paymentService) {
            _paymentService = paymentService;
        }

        [HttpPost("makepayment")]
        public IActionResult MakePayment(Payment payment) { 
            var result = _paymentService.MakePayment(payment);
            if (result.Success) {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
