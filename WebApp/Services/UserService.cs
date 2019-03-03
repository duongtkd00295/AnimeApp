using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Constants;
using Entities;
using Helpers;
using Repositories;
using Services.Interfaces;

namespace Services
{
    public enum MailStatus
    {
        NotExist,Exist,Send
    }
    public class UserService : IUserService
    {
        private readonly IUnitOfWork<DatabaseContext> _unitOfWork;


        public UserService(IUnitOfWork<DatabaseContext> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public User CheckLogin(string username, string password)
        {
            User result = null;
            try
            {
                var user = _unitOfWork.GetRepository<User>().Find(u => u.UserName == username);
                var userPassword = user != null ? _unitOfWork.GetRepository<UserPassword>().Find(u => u.UserId == user.UserId) : null;
                var decrypt = userPassword != null ? HashingHelper.DecryptString(userPassword.Password, AppSetting.PasswordHash) : null;
                result = decrypt != null ? (decrypt == password ? user : null) : null;
            }
            catch (Exception e)
            {

            }
            return result;
        }

        public MailStatus ForgotPassword(string email)
        {
            var status = MailStatus.NotExist;
            var user = _unitOfWork.GetRepository<User>().Find(u => u.Email == email);
            if (user != null)
            {
                var code = HashingHelper.Encode(HashingHelper.EncryptString(string.Format("{0}-{1}", email, DateTime.Now.AddDays(1)),
                    AppSetting.PasswordHash));
            }
            return status;
        }
    }
}
