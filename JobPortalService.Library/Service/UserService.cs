using JobPortalService.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using JobPortalService.Service.Helper;
using System.Linq;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace JobPortalService.Library.Interface
{
    public class UserService : IUserService
    {
        private List<UserModel> _userModels = new List<UserModel>
        {
            new UserModel
            {
                 Id=1,
                 FirstName="Ayan",
                 LastName ="Sahoo",
                 UserName="ayansahoo",
                 Password ="ayan"
            }
        };

        private readonly AppSettings _appSettings;
        public UserService(IOptions<AppSettings> options)
        {
            _appSettings = options.Value;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest authRequest)
        {
            var user = _userModels.SingleOrDefault(x => x.UserName == authRequest.UserName && x.Password == authRequest.Password);

            if (user == null) return null;

            var token = GenerateJwtToken(user);
            return new AuthenticateResponse(user, token);
        }

        private string GenerateJwtToken(UserModel user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokendescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokendescriptor);
            return tokenHandler.WriteToken(token);
        }

        public IEnumerable<UserModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public UserModel GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
