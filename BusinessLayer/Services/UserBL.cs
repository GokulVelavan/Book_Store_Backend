using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Interfaces;
using CommonLayer.Model.UserModels;
using RepositaryLayer.Interfaces;
using RepositaryLayer.Services;

namespace BusinessLayer.Services
{
    public class UserBL:IUserBL
    {
        private IUserRL userRL;

        public UserBL(IUserRL userRL)
        {
            this.userRL = userRL;
        }
        public SignUpResponse Signup(SignUpModel model)
        {
            try
            {
                return this.userRL.Signup(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public string Login(LoginModel model)
        {
            try
            {
                return this.userRL.Login(model);
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public string ForgetPassword(ForgetPasswordModel model)
        {
            try
            {
                return this.userRL.ForgetPassword(model);
            }
            catch (Exception ex)
            {
                throw;
            }

        }

       public  bool ResetPassword(ResetPasswordModel model, string email)
        {
            try
            {
                return this.userRL.ResetPassword(model,email);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
