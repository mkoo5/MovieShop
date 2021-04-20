using ApplicationCore.Entities;
using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;
using ApplicationCore.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IUserService
    {
        Task<UserRegisterResponseModel> RegisterUser(UserRegisterRequestModel registerRequestModel);
        Task<LoginResponseModel> ValidateUser(string email, string password);
        Task<UserRegisterResponseModel> GetUserDetails(int id);
        Task<User> GetUser(string email);

    }
}
