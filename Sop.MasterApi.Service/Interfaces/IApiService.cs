using Sop.MasterApi.Domain.Models;
using System.Net;
using static Sop.MasterApi.Service.Services.ApiService;

namespace Sop.MasterApi.Service.Interfaces
{
    public interface IApiService
    {
        Task<HttpStatusCode> GetAsync(string server, string name, Powershell.State state);
        Task<HttpStatusCode> PostAsync<T>(string server, Crud action, Selection select, string uri, T entity) where T : class;
    }
}