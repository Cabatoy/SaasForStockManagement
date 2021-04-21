using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constant;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autfac.Transaction;
using Core.Aspect.Autfac.Validation;
using Core.Aspect.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.CrossCuttingConcerns.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashıng;
using Core.Utilities.Security.Jwt;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Identity;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly IUserService _userService;
        private readonly ITokenHelper _tokenHelper;
        private readonly ILocalDal _localDal;
        private readonly ICompanyDal _companyDal;

        public AuthManager(IUserService usersService, ITokenHelper tokenHelper, ILocalDal localDal, ICompanyDal companyDal)
        {
            _userService = usersService;
            _tokenHelper = tokenHelper;
            _localDal = localDal;
            _companyDal = companyDal;
        }

        [LogAspect(typeof(DatabaseLogger))]
        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PassWordHash, userToCheck.PassWordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }

            return new SuccessDataResult<User>(userToCheck, Messages.SuccessfullLogin);


        }

        public IResult UserExist(string Email)
        {
            if (_userService.GetByMail(Email) != null)
            {
                return new ErrorResult(Messages.UserAlreadyExist);
            }

            return new SuccessResult();
        }

        [LogAspect(typeof(DatabaseLogger))]
        [TransactionScopeAspect]
        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto)
        {
            //byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out byte[] passwordHash, out byte[] passwordSalt);
            var usr = new User
            {
                CompanyId = userForRegisterDto.CompanyId,
                LocalId = userForRegisterDto.LocalId,
                Email = userForRegisterDto.Email,
                FullName = userForRegisterDto.FullName,
                PassWordHash = passwordHash,
                PassWordSalt = passwordSalt,
                Deleted = false
            };
            _userService.Add(usr);
            return new SuccessDataResult<User>(usr, Messages.UsersAdded);
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accesstoken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accesstoken, Messages.AccessTokenCreated);
        }

        [ValidationAspect(typeof(AuthValidator), Priority = 1)]
        [LogAspect(typeof(DatabaseLogger))]
        [TransactionScopeAspect]
        public IResult RegisterForCompany(UserForRegisterDto dt)
        {
            IResult result = BusinessRules.Run(CheckCompanyTaxNumberExist(dt.TaxNumber));
            if (result != null)
                return result;
            Company company = new()
            {
                TaxNumber = dt.TaxNumber,
                Adress = dt.Adress,
                FullName = dt.FullName,
            };
            _companyDal.Add(company);

            Local loc = new()
            {
                CompanyId = company.Id,
                FullName = "Merkez"
            };
            _localDal.Add(loc);

            dt.CompanyId = company.Id;
            dt.LocalId = loc.Id;
            dt.Password = GenerateRandomPassword(new PasswordOptions()
            {
                RequireDigit = true,
                RequireUppercase = true,
                RequiredLength = 5
            });
            Register(dt);

            //Login(new UserForLoginDto()
            //{
            //    Email = dt.Email,
            //    Password = dt.Password
            //});
            return new SuccessResult(message: Messages.CompanyAdded);
        }
        /// <summary>
        /// Generates a Random Password
        /// respecting the given strength requirements.
        /// </summary>
        /// <param name="opts">A valid PasswordOptions object
        /// containing the password strength requirements.</param>
        /// <returns>A random password</returns>
        public static string GenerateRandomPassword(PasswordOptions opts = null)
        {
            if (opts == null) opts = new PasswordOptions()
            {
                RequiredLength = 8,
                RequiredUniqueChars = 4,
                RequireDigit = true,
                RequireLowercase = true,
                RequireNonAlphanumeric = true,
                RequireUppercase = true
            };

            string[] randomChars = new[] {
            "ABCDEFGHJKLMNOPQRSTUVWXYZ",    // uppercase 
            "abcdefghijkmnopqrstuvwxyz",    // lowercase
            "0123456789",                   // digits
            "!@$?_-"                        // non-alphanumeric
        };

            Random rand = new(Environment.TickCount);
            List<char> chars = new();

            if (opts.RequireUppercase)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[0][rand.Next(0, randomChars[0].Length)]);

            if (opts.RequireLowercase)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[1][rand.Next(0, randomChars[1].Length)]);

            if (opts.RequireDigit)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[2][rand.Next(0, randomChars[2].Length)]);

            if (opts.RequireNonAlphanumeric)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[3][rand.Next(0, randomChars[3].Length)]);

            for (int i = chars.Count; i < opts.RequiredLength
                || chars.Distinct().Count() < opts.RequiredUniqueChars; i++)
            {
                string rcs = randomChars[rand.Next(0, randomChars.Length)];
                chars.Insert(rand.Next(0, chars.Count),
                    rcs[rand.Next(0, rcs.Length)]);
            }

            return new string(chars.ToArray());
        }
        private IResult CheckCompanyTaxNumberExist(string companyTaxNumber)
        {
            if (_companyDal.GetList(p => p.TaxNumber == companyTaxNumber).Count != 0)
            {
                return new ErrorResult(message: Messages.CompanyTaxNumberExistError);
            }
            return new SuccessResult();
        }


    }
}
