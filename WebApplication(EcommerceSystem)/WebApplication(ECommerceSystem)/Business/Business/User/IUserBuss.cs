using Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Business.User
{
    public interface IUserBuss
    {
        DbResponse SignUp(UserCommon model);
        UserCommon SignIn(string User, string password);
        DbResponse Verify(string Email, string VerificationCode);
        DbResponse ForgotPassword(UserCommon common);

        List<NotificationCommon> ShowNotification(string User);
        string NotificationCount(string User);

    }
}
