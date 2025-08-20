// See https://aka.ms/new-console-template for more information
using Dependency_Injection;
using Dependency_InjectionTests;

Console.WriteLine("Hello, World!");
//var tokenProvider = new TokenProvider();
//var token = tokenProvider.CreateToken();
//token.LoginID.ToString();
//tokenProvider.IsValidToken(token);

var tokenTest = new TokenTests();
tokenTest.SetupSerialization();
Console.WriteLine(tokenTest.IsTokenValidAtCreation() ? "Yes" : "No");
Console.WriteLine(tokenTest.IsTokenValidAfterTwoMinutes() ? "No" : "Yes");