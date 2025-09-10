using Microsoft.Exchange.WebServices.Data;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Configuration;

namespace EwsOAuth
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            string clientId = "79ed14e6-2f8f-4eaa-8065-f0c02ff80659";
            //string clientSecret = "CS.8Q~cPyz~goOL5BpyE8jdN4TCExYiRx02dCaWU";
            string tenantId = "8fe955fb-3e0e-4cda-96bb-2b64730477dd";
            string redirectUri = "http://localhost:63473";
            string authority = "https://login.microsoftonline.com/" + tenantId;
            string authorizationCode = "code";
            // Using Microsoft.Identity.Client 4.22.0
            var cca = ConfidentialClientApplicationBuilder
                .Create(clientId)
                .WithClientSecret("CS.8Q~cPyz~goOL5BpyE8jdN4TCExYiRx02dCaWU")
                .WithTenantId(tenantId)
                .Build();

            var ewsScopes = new string[] { "https://outlook.office365.com/.default" };

            try
            {
                var authResult = await cca.AcquireTokenForClient(ewsScopes)
                    .ExecuteAsync();

                // Configure the ExchangeService with the access token
                var ewsClient = new ExchangeService();
                ewsClient.Url = new Uri("https://outlook.office365.com/EWS/Exchange.asmx");
                ewsClient.Credentials = new OAuthCredentials(authResult.AccessToken);
                ewsClient.ImpersonatedUserId =
                    new ImpersonatedUserId(ConnectingIdType.SmtpAddress, "Blacksoil.Finance@blacksoil.co.in");

                //Include x-anchormailbox header
                //ewsClient.HttpHeaders.Add("X-AnchorMailbox", "meganb@contoso.onmicrosoft.com");

                // Make an EWS call
                var folders = ewsClient.FindFolders(WellKnownFolderName.SentItems, new FolderView(10));
                foreach (var folder in folders)
                {
                    Console.WriteLine($"Folder: {folder.DisplayName}");
                }
            }
            catch (MsalException ex)
            {
                Console.WriteLine($"Error acquiring access token: {ex}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
            }

            if (System.Diagnostics.Debugger.IsAttached)
            {
                Console.WriteLine("Hit any key to exit...");
                Console.ReadKey();
            }
        }
    }
}
