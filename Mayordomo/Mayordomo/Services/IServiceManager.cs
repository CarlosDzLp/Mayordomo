using System;
using System.Threading.Tasks;
using Mayordomo.Models.User;
using Mayordomo.Models.WSResponse;

namespace Mayordomo.Services
{
    public interface IServiceManager
    {
        //GET
        Task<Response<bool>> ValidateEmail(string email);


        //POST
        Task<Response<bool>> InsertUser(UserModel user);
    }
}
