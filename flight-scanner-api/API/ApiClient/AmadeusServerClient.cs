using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel.Client;

namespace API.ApiClient
{
    public class AmadeusServerClient : IAmadeusServerClient
    {
		private readonly HttpClient _httpClient;
		private readonly ClientCredentialsTokenRequest _tokenRequest;
		//private readonly ILogger<AmadeusServerClient> _logger;

		public AmadeusServerClient(HttpClient httpClient, ClientCredentialsTokenRequest tokenRequest)
		{
			_httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
			_tokenRequest = tokenRequest ?? throw new ArgumentNullException(nameof(tokenRequest));
			//_logger = logger ?? throw new ArgumentNullException(nameof(logger));
		}

		public async Task<string> RequestClientCredentialsTokenAsync()
		{
			// request the access token token
			var tokenResponse = await _httpClient.RequestClientCredentialsTokenAsync(_tokenRequest);
			if (tokenResponse.IsError)
			{
				//_logger.LogError(tokenResponse.Error);
				throw new HttpRequestException("Something went wrong while requesting the access token");
			}
			return tokenResponse.AccessToken;
		}
	}
}
