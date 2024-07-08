using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete {
    public class UserManager : IUserService {

        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal) {
            _userDal = userDal;
        }

        public IResult Add(User user) {
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult Delete(User user) {
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

        public IDataResult<List<User>> GetAll() {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.UsersListed);
        }

        public IDataResult<User> GetByMail(string email) {
            var result = _userDal.Get(user => user.Email == email);
            if (result == null) {
                return new ErrorDataResult<User>();
            }
            return new SuccessDataResult<User>(result);
        }

        public List<OperationClaim> GetClaims(User user) {
            return _userDal.GetClaims(user);
        }

        public IResult Update(User user) {
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }
    }
}
