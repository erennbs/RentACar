using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract {
    public interface IUserService {
        IResult Add(User user);
        IResult Delete(User user);
        IResult Update(UserDto user);
        IDataResult<List<User>> GetAll();
        IDataResult<UserDto> GetById(int id);
        List<OperationClaim> GetClaims(User user);
        IDataResult<User> GetByMail(string email);
    }
}
