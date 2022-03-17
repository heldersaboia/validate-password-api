using Microsoft.AspNetCore.Mvc;
using System;
using ValidatePasswordAPI.Domain;
using ValidatePasswordAPI.Domain.Models;

namespace ValidatePasswordAPI.Controllers
{
    [ApiController]
    [Route("api/user-access")]
    public class UserAccessController : ControllerBase
    {
        [HttpPost("password-validate")]
        public IActionResult PasswordValidate([FromServices] INotificationUtil notificationUtil, User user)
        {
            try
            {
                var validations = user.ValidatePassword(notificationUtil);

                return validations.Count > 0 ? base.BadRequest(new { success = false, validations })
                : (IActionResult)base.Ok(new { success = true, validations });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
