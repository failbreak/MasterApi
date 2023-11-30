using System.Net.Http.Headers;
using System.Net;
using MasterApi.Models;
using Microsoft.OpenApi.Extensions;

namespace MasterApi
{
    public class ApiCall
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ApiCall (IHttpClientFactory httpClientFactory) => _httpClientFactory = httpClientFactory;

        public async Task<HttpStatusCode> CallApi(string uri)
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                var response = await client.GetAsync(uri);
                return response.StatusCode;
            }
            catch (Exception)
            {
                return HttpStatusCode.InternalServerError;
               
            }
        }
        

    }
}
