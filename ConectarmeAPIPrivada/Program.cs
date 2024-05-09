// See https://aka.ms/new-console-template for more information

HttpClient client = new HttpClient
{
    BaseAddress = new Uri("https://localhost:44348/")
};

Console.Write("Usuario: ");
string username = Console.ReadLine() ?? "";

Console.Write("Contraseña: ");
string password = Console.ReadLine() ?? "";

var response = client.PostAsync($"api/login?username={username}&password={password}", null).Result;

var token = response.Content.ReadAsStringAsync().Result;

Console.WriteLine(token);

HttpRequestMessage rm = new();
rm.RequestUri = new Uri(client.BaseAddress + "api/saludos");
rm.Method = HttpMethod.Get;
rm.Headers.Add("Authorization", $"Bearer {token}");

var resp = client.SendAsync(rm).Result;
resp.EnsureSuccessStatusCode();

if (resp.StatusCode == System.Net.HttpStatusCode.Forbidden)
{
    Console.WriteLine("Acceso Denegado");
}
else
{
    var saludo = resp.Content.ReadAsStringAsync().Result;




    Console.WriteLine(saludo);
}
Console.ReadLine();