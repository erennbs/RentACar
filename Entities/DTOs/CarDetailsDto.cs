﻿using Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs {
    public class CarDetailsDto : IDto{
        public int Id { get; set; }
        public string CarName { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public int ModelYear {  get; set; }
        public decimal DailyPrice { get; set; }
        public string ImagePath { get; set; }
        public bool IsAvailable { get; set; }
    }
}
