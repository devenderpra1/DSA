using System;
using MimeKit;
using MailKit.Net.Imap;
using MailKit.Net.Smtp;
using MailKit.Net.Pop3;
using MailKit.Security;
using MailKit;
using Microsoft.Identity.Client;
using System.Threading.Tasks;
using System.Net;
using Microsoft.Graph;
using Azure.Identity;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var username = "blacksoil.finance@blacksoil.co.in";
            var password = "Bsl@1203";

            string clientId = "79ed14e6-2f8f-4eaa-8065-f0c02ff80659";
            string clientSecret = "CS.8Q~cPyz~goOL5BpyE8jdN4TCExYiRx02dCaWU";
            string tenantId = "8fe955fb-3e0e-4cda-96bb-2b64730477dd";
            string redirectUri = "http://localhost:63473";
            string authority = "https://login.microsoftonline.com/" + tenantId;
            string authorizationCode = "code";


            var scopes = new string[] { "https://outlook.office365.com/.default" };
            //var options = new TokenCredentialOptions
            //{
            //    AuthorityHost = AzureAuthorityHosts.AzurePublicCloud
            //};

            //var clientSecretCredential = new ClientSecretCredential(tenantId, clientId, clientSecret, options);
            //var graphClient = new GraphServiceClient(clientSecretCredential, scopes);

            //        var messages = await graphClient.Users[username].MailFolders["SentItems"].Messages.Request().Top(6000)
            ///*.Select("internetMessageHeaders,body,from,ToRecipients").Filter("internetMessageHeaders.Value has <05fd01d88549$5878fae0$096af0a0$@brintonhealth.com>")*/.GetAsync();

            var options = new ConfidentialClientApplicationOptions
            {
                ClientId = clientId,
                TenantId = tenantId,
                RedirectUri = redirectUri,
                //RedirectUri = "msal79ed14e6-2f8f-4eaa-8065-f0c02ff80659://auth"
                //RedirectUri

            };
            var app = ConfidentialClientApplicationBuilder
                .CreateWithApplicationOptions(options).WithClientSecret(clientSecret).WithAuthority(authority)
                .Build();

            //AuthorizationCodeProvider auth = new AuthorizationCodeProvider(app, scopes);

            var authToken = await app.AcquireTokenForClient(scopes).ExecuteAsync();

            var oauth2 = new SaslMechanismOAuth2(username, authToken.AccessToken);
            //var oauth2 = new SaslMechanismOAuth2(authToken.Account.Username, authToken.AccessToken);

            using (var client = new ImapClient())
            {
                await client.ConnectAsync("outlook.office365.com", 993, SecureSocketOptions.SslOnConnect);
                client.AuthenticationMechanisms.Remove("PLAIN");
                await client.AuthenticateAsync(oauth2);
                var sent = client.GetFolder("Sent Items");
                sent.Open(FolderAccess.ReadOnly);
                await client.DisconnectAsync(true);
            }

    //        var messages1 = await graphClient.Users[username].MailFolders["SentItems"].Request()
    //.Select("*").GetAsync();

    //        foreach (var source in messages)
    //        {
    //            string references = null;
    //            if (source.InternetMessageHeaders == null)
    //                continue;
    //            foreach (var headerReferences in source.InternetMessageHeaders)
    //            {
    //                if (headerReferences.Name == "References")
    //                {
    //                    references = headerReferences.Value;
    //                    //var body = message.Body.ToString();
    //                    StringBuilder body = new StringBuilder();
    //                    if (body != null)
    //                    {
    //                        body.Append("<html><div>");

    //                        //body.AppendFormat("On {0}, ", source.Date.ToString(CultureInfo.InvariantCulture));

    //                        //if (!string.IsNullOrEmpty(source.From.ToString()))
    //                        //    body.Append(source.From.ToString() + ' ');
    //                        //body.AppendFormat("<a\"mailto:{0} </a> wrote:</br>", source.From.ToString());

    //                        //body.Append($"<p>Subject: {source.Subject}</p>");

    //                        //body.Append($"<p>To: {source.To.ToString()}</p>");
    //                        //body.Append($"<p>Cc: {source.Cc.ToString()}</p>");

    //                        if (!string.IsNullOrEmpty(source.Body.ToString()))
    //                        {
    //                            body.Append("<blockqoute style=\"margin: 0 0 0 5px;border-left:2px blue solid;padding-left:5px\">");
    //                            body.Append(source.Body);
    //                            body.Append("</blockquote>");
    //                        }
    //                        body.Append("</div></html>");
    //                    }
    //                    //reply = body.ToString();
    //                }

    //            }

    //            //List<MimeMessage> messages = new List<MimeMessage>();
    //            //var uids = sent.Search(SearchQuery.HeaderContains("References", reference));
    //            //if (uids.Count() == 0)
    //            //    ReturnTrailMails.Add(reference, "");
    //            //else
    //            //{
    //            //    messages.AddRange(uids.Select(a => sent.GetMessage(a)));
    //            //    MimeMessage latest = messages.OrderByDescending(a => a.Date).FirstOrDefault();
    //            //    ReturnTrailMails.Add(reference, TrailMailsBodyLatestMail(latest));
    //            //}
    //        }

            //[username].MailFolders["Inbox"].Messages
            //            .Request()
            //            .GetAsync();

            //var options = new ConfidentialClientApplicationOptions
            //{
            //    ClientId = clientId,
            //    TenantId = tenantId,
            //    RedirectUri = redirectUri,
            //    //RedirectUri = "msal79ed14e6-2f8f-4eaa-8065-f0c02ff80659://auth"
            //    //RedirectUri

            //};
            //var app = ConfidentialClientApplicationBuilder
            //    .CreateWithApplicationOptions(options).WithClientSecret(clientSecret).WithAuthority(authority)
            //    .Build();

            //AuthorizationCodeProvider auth = new AuthorizationCodeProvider(app, scopes);

            //var authToken = await app.AcquireTokenForClient(scopes).ExecuteAsync();

            //var oauth2 = new SaslMechanismOAuth2(username, authToken.AccessToken);


            //using (var client = new ImapClient())
            //{
            //    await client.ConnectAsync("outlook.office365.com", 993, SecureSocketOptions.SslOnConnect);
            //    await client.AuthenticateAsync(oauth2);
            //    await client.DisconnectAsync(true);
            //}


            //using (var imap = new ImapClient("outlook.office365.com"))
            //{
            //    //  Connect and sign to IMAP server using OAuth 2.0.
            //    imap.Connect();
            //    imap.Authenticate("<USERNAME>", "<ACCESS-TOKEN>", ImapAuthentication.XOAuth2);
            //    Console.WriteLine("Authenticated.");
            //}
            //var username1 = "devenderpra@outlook.com";
            //var password1 = "Devender1!";

            //ImapClient client1 = new ImapClient();
            //client1.Connect("outlook.com", 993);
            //client1.AuthenticationMechanisms.Remove("LOGIN");
            //client1.Authenticate(username1, password1);

            //SmtpClient client = new SmtpClient();
            //ImapClient client = new ImapClient();
            //client.Connect("outlook.office365.com", 993, SecureSocketOptions.SslOnConnect);
            ////client.AuthenticationMechanisms.Remove("PLAIN");

            //client.Authenticate(username, password);

        }
    }
}
