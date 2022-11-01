using JobPortalService.Models;
using System.Collections.Generic;

namespace JobPortalService.Library.Interface
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest authRequest);
        IEnumerable<UserModel> GetAll();
        UserModel GetById(int id);
    }
}
