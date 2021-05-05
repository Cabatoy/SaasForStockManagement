using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Jwt;
using Entities.Dtos;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<CompanyUser> Register(UserForRegisterDto userForRegisterDto);
        IDataResult<CompanyUser> Login(UserForLoginDto userForLoginDto);

        IResult RegisterForCompany(UserForRegisterDto userForRegisterDto);
        IResult UserExist(string Email);
        IDataResult<AccessToken> CreateAccessToken(CompanyUser user);
        
    }
}
