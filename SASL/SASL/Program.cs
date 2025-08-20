using MailKit;
using MailKit.Net.Imap;
using MailKit.Security;
using Microsoft.Identity.Client;
using System;
using System.Threading.Tasks;

namespace SASL
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string clientId = "79ed14e6-2f8f-4eaa-8065-f0c02ff80659";
            //string clientSecret = "CS.8Q~cPyz~goOL5BpyE8jdN4TCExYiRx02dCaWU";
            string tenantId = "8fe955fb-3e0e-4cda-96bb-2b64730477dd";
            string redirectUri = "http://localhost:63473";
            string authority = "https://login.microsoftonline.com/" + tenantId;
            string authorizationCode = "code";
            var options = new PublicClientApplicationOptions
            {
                ClientId = clientId,
                TenantId = tenantId,
                RedirectUri = redirectUri
            };
            var publicClientApplication = PublicClientApplicationBuilder
    .CreateWithApplicationOptions(options)
    .Build();

            var scopes = new string[] { "email", "offline_access","https://outlook.office.com/IMAP.AccessAsUser.All"
};

            var authToken = await publicClientApplication.AcquireTokenInteractive(scopes).ExecuteAsync();

            var oauth2 = new SaslMechanismOAuth2(authToken.Account.Username, authToken.AccessToken);

            using (var client = new ImapClient())
            {
                await client.ConnectAsync("outlook.office365.com", 993, SecureSocketOptions.SslOnConnect);
                await client.AuthenticateAsync(oauth2);
                var sent = client.GetFolder("Sent Items");
                sent.Open(FolderAccess.ReadOnly);
                await client.DisconnectAsync(true);
            }
        }
    }
}
