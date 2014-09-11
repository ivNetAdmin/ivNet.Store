using System;
using System.Web.Mvc;
using Orchard.Users.Services;

namespace PJS.Bootstrap.Controllers
{
    public class ValidateController : Controller
    {
        private readonly IUserService _userService;

        public ValidateController(IUserService userService) {
            _userService = userService;
        }

        [HttpGet]
        public String ValidateUserName(string fieldId, string fieldValue) {
            bool available = _userService.VerifyUserUnicity(fieldValue, "NONE");

            string response = "[\"" + fieldId + "\"," + available.ToString().ToLower() + "]";

            return response;
        }

        [HttpGet]
        public String ValidateUserEmail(string fieldId, string fieldValue) {
            bool available = _userService.VerifyUserUnicity(string.Empty, fieldValue);

            string response = "[\"" + fieldId + "\"," + available.ToString().ToLower() + "]";

            return response;
        }

        [HttpGet]
        public String ValidateUserNameEmail(string fieldId, string fieldValue) {
            bool available = _userService.VerifyUserUnicity(fieldValue, fieldValue);

            available = !available;

            string response = "[\"" + fieldId + "\"," + available.ToString().ToLower() + "]";

            return response;
        }
	}
}