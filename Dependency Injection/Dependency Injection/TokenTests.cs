using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dependency_Injection;

namespace Dependency_InjectionTests
{
    public class TokenTests
    {
        public DummyDateTimeProvider DateTimeProvider;

        public Container Container;

        public void SetupSerialization()
        {
            Container = new Container();
            Container.Register<IEncryptor>(new Encryptor());
            DateTimeProvider = new DummyDateTimeProvider();
            Container.Register<IDateTimeProvider>(DateTimeProvider);
        }

        public bool IsTokenValidAtCreation()
        {
            //var tokenProvider = new TokenProvider(new DummyDateTimeProvider(), new Encryptor());
            var tokenProvider = Container.Resolve<TokenProvider>();
            var loginToken = tokenProvider.CreateToken();
            return tokenProvider.IsValidToken(loginToken);
        }

        public bool IsTokenValidAfterTwoMinutes()
        {
            //var tokenProvider = new TokenProvider(DateTimeProvider = new DummyDateTimeProvider(), new Encryptor());
            var tokenProvider = Container.Resolve<TokenProvider>();
            var loginToken = tokenProvider.CreateToken();
            DateTimeProvider.AdvanceTime(new TimeSpan(3000));
            return tokenProvider.IsValidToken(loginToken);
        }

        public class DummyDateTimeProvider : IDateTimeProvider
        {
            public DummyDateTimeProvider()
            {
                now = DateTime.Now;
            }
            private DateTime now;

            public DateTime Now => now;

            public void AdvanceTime(TimeSpan timeSpan)
            {
                now = now.AddMinutes(timeSpan.Minutes);
            }
        }
    }
}