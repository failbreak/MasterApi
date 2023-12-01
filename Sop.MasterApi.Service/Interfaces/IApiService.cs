using Sop.MasterApi.Domain.Models;
using Sop.MasterApi.Service.Services;
using System.Net;

namespace Sop.MasterApi.Service.Interfaces
{
    public interface IApiService
    {
        Task<HttpStatusCode> GetAsync(string server, string name, Powershell.State state);
        Task<HttpStatusCode> PostAsync(string server, ApiService.Crud action, ApiService.Selection select, string name);
        Task<HttpStatusCode> PostAsync(string server, ApiService.Crud action, ApiService.Selection select, string name, bool deletepool);
        Task<HttpStatusCode> PostAsync<T>(string server, ApiService.Crud action, ApiService.Selection select, T entity) where T : class;
    }
}