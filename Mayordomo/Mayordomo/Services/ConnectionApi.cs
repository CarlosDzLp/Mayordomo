using System;
using System.Threading.Tasks;
using Mayordomo.Models.User;
using Mayordomo.Models.WSResponse;
using Refit;

namespace Mayordomo.Services
{
    [Headers("Content-Type: application/json;", "Content-Type: application/octet-stream")]
    public interface ConnectionApi
    {
        //GET
        [Get("/api/authenticate/validateemail?email={email}")]
        Task<ApiResponse<Response<bool>>> ValidateEmail(string email);


        //POST
        //[Multipart]
        //[Post("/api/authenticate/insertuser")]
        //Task<ApiResponse<Response<bool>>> InsertUser([Body] UserModel user);
    }
}
