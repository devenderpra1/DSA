using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dependency_Injection
{
    public class TokenProvider
    {
        public TokenProvider(IDateTimeProvider dateTimeProvider, IEncryptor encryptor)
        {
            this.dateProvider = dateTimeProvider;
            this.encryptor = encryptor;
        }

        IDateTimeProvider dateProvider;

        IEncryptor encryptor;

        public LoginToken CreateToken()
        {
            var lt = new LoginToken(dateProvider);
            return lt;
        }

        public bool IsValidToken(LoginToken loginToken)
        {
            return loginToken.LoginTime >= DateTime.Now.AddMinutes(-2) ? true : false;
        }

    }

    public class ActualDateTimeProvider : IDateTimeProvider
    {
        public DateTime Now => DateTime.Now;
    }

    public class Encryptor : IEncryptor
    {
        public string Decrypt(LoginToken lt)
        {
            return string.Empty;
        }

        public string Encrypt(LoginToken lt)
        {
            return string.Empty;
        }
    }

    public class LoginToken
    {
        public LoginToken(IDateTimeProvider dateTimeProvider)
        {
            LoginTime = dateTimeProvider.Now;
            LoginID = new Guid();
        }

        public DateTime LoginTime;
        public Guid LoginID;
    }

    public interface IEncryptor
    {
        public string Encrypt(LoginToken lt);

        public string Decrypt(LoginToken lt);
    }

    public interface IDateTimeProvider
    {
        public DateTime Now { get; }
    }
}
