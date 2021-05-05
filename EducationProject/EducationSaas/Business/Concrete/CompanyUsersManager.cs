using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constant;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CompanyUsersManager : ICompanyUserService
    {
        private readonly ICompanyUserDal _userDal;

        public CompanyUsersManager(ICompanyUserDal userDal)
        {
            _userDal = userDal;
        }
        public IResult Add(CompanyUser user)
        {
            _userDal.Add(user);
            return new SuccessResult(message: Messages.UsersAdded);
        }

        public IResult Delete(CompanyUser user)
        {
            _userDal.Delete(user);
            return new SuccessResult(message: Messages.UsersDeleted);
        }

        public IDataResult<CompanyUser> GetById(int userId)
        {
            return new SuccessDataResult<CompanyUser>(_userDal.Get(p => p.Id == userId));
        }

        public CompanyUser GetByMail(string mail)
        {
            return _userDal.Get(p => p.Email == mail);
        }

        public List<CompanyOperationClaim> GetClaims(CompanyUser user)
        {
            return _userDal.GetClaims(user);
        }

        public IDataResult<List<CompanyUser>> GetList()
        {
            return new SuccessDataResult<List<CompanyUser>>(_userDal.GetList());
        }

        public IResult Update(CompanyUser user)
        {
            _userDal.Update(user);
            return new SuccessResult(message: Messages.UsersUpdated);
        }
    }
}
