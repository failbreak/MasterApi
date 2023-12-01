using MasterApi.Models;
using Microsoft.AspNetCore.Mvc;
using Sop.MasterApi.Service.Interfaces;
using Sop.MasterApi.Service.Services;
using System.Net;
using System.Net.Http.Headers;
using System.Reflection.Metadata;

namespace MasterApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class DeploymentManagerController : Controller
    {
        //static readonly HttpClient ApiCall = new HttpClient();
        private readonly IApiService _apiService;
        public DeploymentManagerController(IApiService apiService) => _apiService = apiService;


        [HttpPost]
        [Route("DeployManager/Create")]
        public async Task<HttpStatusCode> Create<T>(string server, int port, T Entity, ApiService.Selection selection) where T : class
        {
            try
            {
                var RequestObject = Entity;
                string ApiLocation = server + ":" + port;
                HttpStatusCode apicall = await _apiService.PostAsync(ApiLocation, ApiService.Crud.Create, selection, RequestObject);
                return apicall;
            }
            catch (Exception)
            {
                return HttpStatusCode.InternalServerError;

            }

        }
        [HttpPost]
        [Route("DeployManager/Stop")]
        public async Task<HttpStatusCode> Stop(string server, int port, ApiService.Selection selection, string name)
        {
            try
            {
                string ApiLocation = server + ":" + port;
                HttpStatusCode apicall = await _apiService.PostAsync(server, ApiService.Crud.Stop, selection, name);
                return apicall;
            }
            catch (Exception)
            {
                return HttpStatusCode.InternalServerError;

            }
        }

        [HttpPost]
        [Route("DeployManager/Start")]
        public async Task<HttpStatusCode> Start(string server, int port, ApiService.Selection selection, string name)
        {
            try
            {
                string ApiLocation = server + ":" + port;
                HttpStatusCode apicall = await _apiService.PostAsync(server, ApiService.Crud.Start, selection, name);
                return apicall;
            }
            catch (Exception)
            {
                return HttpStatusCode.InternalServerError;

            }


        }
        [HttpPost]
        [Route("DeployManager/Delete")]
        public async Task<HttpStatusCode> Delete(string server, int port, ApiService.Selection selection, string name, bool deletePool)
        {
            try
            {
                string ApiLocation = server + ":" + port;
                   return await _apiService.PostAsync(server, ApiService.Crud.Delete, selection, name, deletePool);

             
            }
            catch (Exception)
            {
                return HttpStatusCode.InternalServerError;

            }
        }        [HttpPost]
        [Route("DeployManager/Delete")]
        public async Task<HttpStatusCode> Delete(string server, int port, ApiService.Selection selection, string name)
        {
            try
            {
                string ApiLocation = server + ":" + port;
                   return await _apiService.PostAsync(server, ApiService.Crud.Delete, selection, name);
             
            }
            catch (Exception)
            {
                return HttpStatusCode.InternalServerError;

            }
        }
        [HttpPost]
        [Route("DeployManager/WebBinding/Update")]
        public async Task<HttpStatusCode> WebBindingUpdate(string server, int port, string name)
        {
            try
            {
                string ApiLocation = server + ":" + port;
                return await _apiService.PostAsync(server, ApiService.Crud.Update, ApiService.Selection.Website, name);
            }
            catch (Exception)
            {
                return HttpStatusCode.InternalServerError;

            }


        }

    }

}
