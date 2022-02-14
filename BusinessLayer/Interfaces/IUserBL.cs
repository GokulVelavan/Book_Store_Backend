using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLayer.Model.UserModels;

namespace BusinessLayer.Interfaces
{
    public interface IUserBL
    {
        SignUpResponse Signup(SignUpModel model);
        string Login(LoginModel model);
        string ForgetPassword(ForgetPasswordModel model);
        bool ResetPassword(ResetPasswordModel model, string email);
    }
}
