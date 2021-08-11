using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carsharing
{
    interface IChecksFactory
    {
        EmptyChecks EmptyChecks { get; }

        EmailChecks CheckEmailValid { get; }

        EmailCheckAdapter CheckEmailUnique { get; }

        PasswordChecks PasswordChecks { get; }

        OtherChecks OtherChecks { get; }
    }
}
