using System.Linq;
using System.Text;
using TestTokenProvider;

var temp = new TokenTests();
Console.WriteLine(temp.IsValidToken() ? "True" : "False");
Console.WriteLine(temp.IsInvalidToken() ? "True" : "False");


