using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constant;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class UsersManager : IUsersService
    {
        private IUserDal _userDal;

        public UsersManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public IResult Add(Users user)
        {
            _userDal.Add(user);
            return new SuccessResult(message: Messages.usersAdded);
        }

        public IResult Delete(Users user)
        {
            _userDal.Delete(user);
            return new SuccessResult(message: Messages.usersDeleted);
        }

        public IDataResult<Users> GetById(int userId)
        {
            return  new SuccessDataResult<Users>(_userDal.Get(p => p.Id == userId));
        }

        public IDataResult<List<Users>> GetList()
        {
            return new SuccessDataResult<List<Users>>(_userDal.GetList());
        }

        public IResult Update(Users user)
        {
            _userDal.Update(user);
            return new SuccessResult(message: Messages.usersUpdated);
        }
    }
}
