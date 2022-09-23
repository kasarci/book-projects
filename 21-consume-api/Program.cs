using System.Net.Http.Json;
using Microsoft.Extensions.DependencyInjection;

IHttpClientFactory httpClientFactory = new ServiceCollection()
                                      .AddHttpClient()
                                      .BuildServiceProvider()
                                      .GetService<IHttpClientFactory>();

HttpClient httpClient = httpClientFactory.CreateClient();

HttpResponseMessage? response = await httpClient.GetAsync("https://www.boredapi.com/api/activity");

if (response is not null)
{
  var responseContent = await response.Content.ReadFromJsonAsync<BoredApi>();
  System.Console.WriteLine("APIS random suggestion is: ");
  System.Console.WriteLine(responseContent.Activity);
}

class BoredApi {
  public string Activity { get; set; }
  public string Type { get; set; }
  public int Participants { get; set; }
  public decimal Price { get; set; }
  public string Link { get; set; }
  public int Key { get; set; }
  public decimal Accessibility { get; set; }

}