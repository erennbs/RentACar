using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract {
    public interface ICarManager {
        void Add(Car car);
        void Delete(Car car);
        void Update(Car car);
        public List<Car> GetCarsByBrandId(int id);
        public List<Car> GetCarsByColorId(int id);
    }
}
