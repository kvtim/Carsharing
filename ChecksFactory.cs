using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carsharing
{
    class ChecksFactory : IChecksFactory
    {
        public EmptyChecks EmptyChecks => new EmptyChecks();

        public EmailChecks CheckEmailValid => new EmailChecks();

        public EmailCheckAdapter CheckEmailUnique => new EmailCheckAdapter();

        public PasswordChecks PasswordChecks => new PasswordChecks();

        public OtherChecks OtherChecks => new OtherChecks();
    }
}
