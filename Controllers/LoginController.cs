using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PCF_POC.Models;
using System;
using System.Threading.Tasks;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace PCF_POC.Controllers
{
    [ApiController]
    [Route("Login")]
    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;

        private readonly Service _service;

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
            _service = new Service();
        }

        /// <summary>
        /// Validates user credentials
        /// </summary>
        /// <param name="userData"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("ValidateUser")]
        public async Task<ReturnData> ValidateUser(UserModel userData)
        {
            var data = new ReturnData();
            try
            {
                var result = await _service.ValidateUser(userData);
                if (result)
                {
                    data.Code = ReturnCodes.Success;
                    data.Message = "Valid user credentials";
                }
                else
                {
                    data.Message = "Invalid user credentials";
                    data.Code = ReturnCodes.Success;
                }
            }
            catch (Exception ex)
            {
                data.Code = ReturnCodes.Error;
                data.Message = ex.Message;

                throw;
            }
            return data;
        }
    }
}
