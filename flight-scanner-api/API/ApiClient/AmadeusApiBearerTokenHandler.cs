using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using IdentityModel.Client;

namespace API.ApiClient
{
    public class AmadeusApiBearerTokenHandler : DelegatingHandler
    {
		private readonly IAmadeusServerClient _amadeusServerClient;

		public AmadeusApiBearerTokenHandler(
			IAmadeusServerClient amadeusServerClient)
		{
			_amadeusServerClient = amadeusServerClient
				?? throw new ArgumentNullException(nameof(amadeusServerClient));
		}

		protected override async Task<HttpResponseMessage> SendAsync(
			HttpRequestMessage request,
			CancellationToken cancellationToken)
		{
			// request the access token
			var accessToken = await _amadeusServerClient.RequestClientCredentialsTokenAsync();

			// set the bearer token to the outgoing request
			request.SetBearerToken(accessToken);

			return await base.SendAsync(request, cancellationToken);
		}
	}
}
