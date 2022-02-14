using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BusinessLayer.Interfaces;
using CommonLayer.Model.UserModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Book_Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserBL userBL;

        public UserController(IUserBL userBL)
        {
            this.userBL = userBL;
        }
        [HttpPost("signup")]
        public IActionResult SignupUser(SignUpModel model)
        {
            try
            {
                if(model==null)
                {
                return NotFound(new {Success=false,message="Credentials missing" });

                }
                SignUpResponse user = userBL.Signup(model);
                return Ok(new { Success = true, message = "Registration Successfull ", user });
            }   catch(Exception e)
            {
                return NotFound(new { message = e.Message });
            }
        }

        [HttpPost("login")]
        public IActionResult LoginUser(LoginModel model)
        {
            try
            {
                string token = userBL.Login(model);
                if (token == null)
                {
                    return NotFound(new { Success = false, message = "Not an autanticated user" });

                }
                return Ok(new { Success = true, message = "Login Successfull ", Token=token});
            }
            catch (Exception e)
            {
                return NotFound(new { message = e.Message });
            }
        }

        [HttpPost("forgetpassword")]
        public IActionResult ForgetPassword(ForgetPasswordModel model)
        {
            try
            {
                string forgetPassword = userBL.ForgetPassword(model);
                if (forgetPassword == null)
                {
                    return NotFound(new { Success = false, message = "Email is not present!" });
                }
                return Ok(new { Success = true, message = "Mail has been send",forgetPassword });
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }


        [HttpPut("resetPassword")]
        public IActionResult ResetPassword(ResetPasswordModel model)
        {
            try
            {
                //string email = User.FindFirst(ClaimTypes.Email).Value.ToString();
                bool resetPassword = userBL.ResetPassword(model,"gokulvelavans@gmail.com");
                if (resetPassword)
                {
                    return Ok(new { Success = true, message = "Password Reset Successful" });
                }
                return NotFound(new { Success = false, message = "New Password not match with confirm password" });
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }


    }
}
