using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using IdentityModel.Client;

namespace API.ApiClient
{
    public class AmadeusApiClient : IAmadeusApiClient
    {
		private readonly HttpClient _httpClient;

		public AmadeusApiClient(HttpClient httpClient)
		{
			_httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
		}

		public async Task<string> PostProtectedResources(string json, string url)
		{
			var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

			var response = await _httpClient.PostAsync(url, httpContent);
			if (!response.IsSuccessStatusCode)
			{
				Console.WriteLine(response.StatusCode);
				throw new Exception("Failed to get resources.");
			}
			return await response.Content.ReadAsStringAsync();
		}
	}
}
