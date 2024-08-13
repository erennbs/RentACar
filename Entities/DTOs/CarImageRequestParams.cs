using Core.Entites;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs {
    public class CarImageRequestParams : IDto{
        public int CarId{ get; set; }
        public IFormFile File { get; set; }
    }
}
