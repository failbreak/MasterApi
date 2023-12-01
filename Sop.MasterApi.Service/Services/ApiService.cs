﻿using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Xml.Linq;
using Microsoft.Extensions.Configuration;
using Sop.MasterApi.Domain.Models;
using Sop.MasterApi.Service.Interfaces;
using static System.Net.Mime.MediaTypeNames;
using static Sop.MasterApi.Domain.Models.Powershell;

namespace Sop.MasterApi.Service.Services
{
    public class ApiService : IApiService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public enum Crud
        {
            Create,
            Start,
            Update,
            Stop,
            Delete
        }
        public enum Selection
        {
            Website,
            Applicationpool,
            Server,
        }

        public async Task<HttpStatusCode> GetAsync(string server,string name, Powershell.State state)
        {
            try
            {
                string UrlQuery = $"https://{server}/GetState/?name={Uri.EscapeDataString(name)}&Option={state}";
                HttpClient httpClient = _httpClientFactory.CreateClient();
                using HttpResponseMessage responseMessage =
                    await httpClient.GetAsync(UrlQuery);

                if (!responseMessage.IsSuccessStatusCode)
                    return HttpStatusCode.Conflict;
                else
                    return HttpStatusCode.OK;

            }
            catch (Exception)
            {
                return HttpStatusCode.InternalServerError;

            }
        }


        /// <summary>
        ///  Generic PostAsync.
        /// </summary>
        /// <typeparam name="Tentity"></typeparam>
        /// <param name="uri"></param>
        /// <param name="entity"></param>
        /// <returns>HttpSatusCode</returns>
        public async Task<HttpStatusCode> PostAsync<T>(string server, Crud action, Selection select, string uri, T entity) where T : class
        {
            try
            {
                StringContent entityJson = new StringContent(
                    JsonSerializer.Serialize(entity),
                    Encoding.UTF8,
                    Application.Json
                    );

                string UrlQuery = $"https://{server}/{Enum.GetName(select)+"/"+ Enum.GetName(action)}/";
                HttpClient httpClient = _httpClientFactory.CreateClient();
                using HttpResponseMessage responseMessage =
                    await httpClient.PostAsync(uri, entityJson);
                if (!responseMessage.IsSuccessStatusCode)
                    return HttpStatusCode.Conflict;
                else
                    return HttpStatusCode.OK;

            }
            catch (Exception)
            {
                return HttpStatusCode.InternalServerError;

            }
        }

    }
}
