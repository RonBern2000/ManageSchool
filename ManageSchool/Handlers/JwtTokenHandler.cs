using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageSchool.Handlers
{
    class JwtTokenHandler : DelegatingHandler 
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var token = await SecureStorage.GetAsync("jwt_token");

            if (!string.IsNullOrEmpty(token))
            {
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }
            return await base.SendAsync(request, cancellationToken);
        }
    }
}
