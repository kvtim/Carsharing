using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Carsharing
{
    class UserActionsRealization : UserActions
    {
        public override void DeleteAccount()
        {
            using (ApplicationContextUser db = new ApplicationContextUser())
            {
                db.Users.Attach(CurrentUser.user);
                db.Users.Remove(CurrentUser.user);
                db.SaveChanges();
            }
        }

        public override bool ChangePassword(PasswordBox currentPasswordBox, PasswordBox newPasswordBox, PasswordBox newPasswordBoxRepeat)
        {
            string currentPassword = currentPasswordBox.Password;
            string newPassword = newPasswordBox.Password;
            string newPasswordRepeat = newPasswordBoxRepeat.Password;

            ChecksFactory checks = new ChecksFactory();

            bool currentPassEmpty = checks.EmptyChecks.PasswordBoxEmpty(currentPasswordBox, currentPassword);
            bool newPassEmpty = checks.EmptyChecks.PasswordBoxEmpty(newPasswordBox, newPassword);
            bool newPassRepeatEmpty = checks.EmptyChecks.PasswordBoxEmpty(newPasswordBoxRepeat, newPasswordRepeat);

            bool checkLengthCurrentPass = checks.PasswordChecks.CheckPasswordLength(currentPasswordBox, currentPassword);
            bool checkLengthNewPass = checks.PasswordChecks.CheckPasswordLength(newPasswordBox, newPassword);

            bool checkTheSamePass = checks.PasswordChecks.CheckTheSamePasswords(newPasswordBoxRepeat, newPassword, newPasswordRepeat);

            bool isValidPass = checks.PasswordChecks.IsValidPassword(currentPasswordBox, currentPassword);

            if (currentPassEmpty && newPassEmpty && newPassRepeatEmpty && checkLengthCurrentPass && checkLengthNewPass &&
                checkTheSamePass && isValidPass)
            {
                using (ApplicationContextUser db = new ApplicationContextUser())
                {
                    db.Users.Attach(CurrentUser.user);
                    CurrentUser.user.Password = newPassword;
                    db.SaveChanges();

                    return true;
                }
            }

            return false;
        }
    }
}
