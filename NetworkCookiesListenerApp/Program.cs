using System.Net;
/*
Uri uri = new Uri(@"https://yandex");
Cookie nameCookie = new Cookie("name", "Bobby");
Cookie emailCookie = new Cookie("email", "bobby@gmail.com");
CookieContainer cookieContainer = new CookieContainer();
cookieContainer.Add(nameCookie);
cookieContainer.Add(emailCookie);

cookieContainer.SetCookies(uri, "city=Moscow");
*/


HttpClient client = new HttpClient();
Uri uri = new Uri("https://localhost:7278/user");
CookieContainer cookies = new CookieContainer();

/*
using var response = await client.GetAsync(uri);


foreach (var cookie in response.Headers.GetValues("Set-Cookie"))
    cookies.SetCookies(uri, cookie);

foreach(Cookie cookie in cookies.GetCookies(uri))
    Console.WriteLine($"{cookie.Name}: {cookie.Value}");
*/

Cookie nameCookie = new Cookie("name", "Bobby");
Cookie emailCookie = new Cookie("email", "bobby@gmail.com");
cookies.Add(uri, nameCookie);
cookies.Add(uri, emailCookie);
cookies.SetCookies(uri, "city=Moscow");

client.DefaultRequestHeaders.Add("cookie", cookies.GetCookieHeader(uri));

using var response = await client.GetAsync(uri);
string text = await response.Content.ReadAsStringAsync();
Console.WriteLine(text);


Console.ReadKey();
