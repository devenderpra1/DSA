using Dependency_Injection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dependency_Injection
{
    public interface IDateTimeProvider
    {
        DateTime Now { get; }
    }

    public interface IEncryptor
    {
        public string Encrypt(string input);
        public string Decrypt(string input);

    }

    public class ActualDateTimeProvider : IDateTimeProvider
    {
        public DateTime Now => DateTime.Now;
    }

    public class TokenEncryptor : IEncryptor
    {
        public string Decrypt(string input)
        {
            return "Decrypt";
        }

        public string Encrypt(string input)
        {
            return "Encrypt";
        }
    }

    class LoginToken
    {
        public LoginToken(DateTime time)
        {
            this.TokenID = new Guid().ToString();
            this.LoginTime = time;
        }
        public string TokenID { get; set; }
        public DateTime LoginTime { get; set; }
    }

    public class TokenProvider
    {
        public TokenProvider(IDateTimeProvider dateTimeProvider, IEncryptor encryptor)
        {
            this.dateTimeProvider = dateTimeProvider;
            this.encryptor = encryptor;

        }

        private IDateTimeProvider dateTimeProvider;

        IEncryptor encryptor;

        public string CreateToken()
        {
            var token = new LoginToken(dateTimeProvider.Now);
            return JsonConvert.SerializeObject(token);
            //encryptor.Encrypt(serialisedToken);
        }
        public bool ValidateToken(string token)
        {
            //var decryptedToken = encryptor.Decrypt(token);
            var deserialisedToken = JsonConvert.DeserializeObject<LoginToken>(token);
            return deserialisedToken.LoginTime.AddMinutes(2) >= dateTimeProvider.Now;// We could have directly used DateTime.Now
        }
    }
}

namespace TestTokenProvider
{
    public class TestDateProvider : IDateTimeProvider
    {
        public TestDateProvider()
        {
            nowProvider = DateTime.Now;
        }
        public DateTime nowProvider;
        public DateTime Now => nowProvider;

        public void AdvanceTime(TimeSpan time)
        {
            nowProvider.AddMinutes(time.TotalMinutes);
        }
    }

    public class TokenTests
    {
        public bool IsValidToken()
        {
            var tokenProvider = new TokenProvider(new TestDateProvider(), new TokenEncryptor());
            var token = tokenProvider.CreateToken();
            return tokenProvider.ValidateToken(token);
        }

        public bool IsInvalidToken()
        {
            var dateProvider = new TestDateProvider();
            dateProvider.AdvanceTime(new TimeSpan(1000000));
            var tokenProvider = new TokenProvider(dateProvider, new TokenEncryptor());
            var token = tokenProvider.CreateToken();
            return tokenProvider.ValidateToken(token);
        }
    }

}