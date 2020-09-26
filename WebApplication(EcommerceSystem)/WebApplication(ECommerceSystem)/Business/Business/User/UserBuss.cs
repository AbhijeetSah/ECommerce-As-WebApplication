using Reposatory.Repository.User;
using Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Business.User
{
    public class UserBuss : IUserBuss
    {
        IUserRepo repo;
        public UserBuss(UserRepo _repo)
        {
            repo = _repo;
        }

        public DbResponse SignUp(UserCommon model)
        {
            return repo.SignUp(model);
        }
        public UserCommon SignIn(string User, string Password)
        {
            return repo.SignIn(User, Password);
        }
        public DbResponse Verify(string Email, string VerificationCode)
        {
            return repo.Verify(Email, VerificationCode);
        }
        public DbResponse ForgotPassword(UserCommon Common)
        {
            return repo.ForgotPassword(Common);
        }
        public List<NotificationCommon> ShowNotification(string user)
        {
            return repo.ShowNotification(user);
        }
        public string NotificationCount(string user)
        {
            return repo.NotificationCount(user);
        }



    }
}
