using BlazorWasmAuthentication.Services;
using System.Net.Http.Headers;

namespace BlazorWasmAuthentication.Handlers
{
    public class AuthenticationHandler : DelegatingHandler
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IConfiguration _configuration;

        public AuthenticationHandler(IAuthenticationService authenticationService, IConfiguration configuration)
        {
            _authenticationService = authenticationService;
            _configuration = configuration;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var jwt = await _authenticationService.GetJwtAsync();
            var isToServer = request.RequestUri?.AbsoluteUri.StartsWith(_configuration["ServerUrl"] ?? "") ?? false;

            if (isToServer && !string.IsNullOrEmpty(jwt))
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", jwt);

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
