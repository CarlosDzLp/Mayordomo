using System;
using System.Threading.Tasks;
using Mayordomo.Models.Authenticate;
using Mayordomo.Models.User;
using Mayordomo.Models.WSResponse;
using Refit;

namespace Mayordomo.Services
{
    [Headers("application/json;")]
    public interface ConnectionApi
    {
        //GET
        [Get("/api/authenticate/validateemail?email={email}")]
        Task<ApiResponse<Response<bool>>> ValidateEmail(string email);


        //POST
        [Post("/api/authenticate/aoth")]
        Task<ApiResponse<TokenResponse>> Authenticate([Body] UserModel user);

        [Post("/api/authenticate/dologin")]
        [Headers("Content-Type: application/octet-stream")]
        Task<ApiResponse<Response<UserModel>>> DoLogin([Body] UserModel user);
    }
}
