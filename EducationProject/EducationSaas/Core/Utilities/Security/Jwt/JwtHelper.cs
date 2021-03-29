using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Security.Encyption;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Core.Extensions;

namespace Core.Utilities.Security.Jwt
{
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configuration { get; }
        private TokenOptions _tokenOptions;
        private DateTime _accessTokenExpiration;

        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions = configuration.GetSection("TokenOptions").Get<TokenOptions>();
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
        }

        public AccessToken CreateToken(User user, List<RoleDetail> roles)
        {
            //new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenOptions.SecurityKey));

            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            throw new NotImplementedException();
        }

        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions,
            User user, SigningCredentials signingCredentials, List<RoleDetail> roleDetails)
        {
            throw new NotImplementedException();
            //var jwt =new JwtSecurityTokenHandler(
            //{

            //});
            //var tokenDescriptor = new SecurityTokenDescriptor
            //{
            //    Issuer = tokenOptions.Issuer,
            //    Audience = tokenOptions.Audience

            //}



            //var jwt = new JwtSecurityToken(
            //    //Issuer: tokenDescriptor.Issuer,
            //    //audience: tokenOptions.Audience,
            //    expires: _accessTokenExpiration,
            //    notBefore: DateTime.Now,
            //    claims: SetClaims(user,roleDetails),
            //    signingCredentials = signingCredentials

            //    );
        }

        private IEnumerable<Claim> SetClaims(User user, List<RoleDetail> rollsDetails)
        {
            var claims = new List<Claim>();
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddEmail(user.LoginName);
            claims.AddName(user.FullName);
            claims.AddRoleDetail(rollsDetails.Select(x=>x.Description).ToArray());
            return claims;
        }
    }
}
