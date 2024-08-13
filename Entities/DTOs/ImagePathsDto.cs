using Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs {
    public class ImagePathsDto : IDto{
        public List<string> Paths { get; set; }
    }
}
